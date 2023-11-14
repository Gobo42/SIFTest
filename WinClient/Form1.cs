using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace SIFTestWinClient
{
    public partial class Form1 : Form
    {
        // P/Invoke constants
        private const int WM_SYSCOMMAND = 0x112;
        private const int MF_STRING = 0x0;
        private const int MF_SEPARATOR = 0x800;

        // P/Invoke declarations
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool AppendMenu(IntPtr hMenu, int uFlags, int uIDNewItem, string lpNewItem);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool InsertMenu(IntPtr hMenu, int uPosition, int uFlags, int uIDNewItem, string lpNewItem);

        // ID for the About item on the system menu
        private int SYSMENU_ABOUT_ID = 0x1;

        private bool Connected = false;
        const string myVer = "1.0.1";

        private Socket client { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            // Get a handle to a copy of this form's system (window) menu
            IntPtr hSysMenu = GetSystemMenu(this.Handle, false);

            // Add a separator
            AppendMenu(hSysMenu, MF_SEPARATOR, 0, string.Empty);

            // Add the About menu item
            AppendMenu(hSysMenu, MF_STRING, SYSMENU_ABOUT_ID, "&About…");
            label4.Text = "v" + myVer + " by matt.hum@hpe.com";
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            // Test if the About item was selected from the system menu
            if ((m.Msg == WM_SYSCOMMAND) && ((int)m.WParam == SYSMENU_ABOUT_ID))
            {
                string message = "Server Initiated Flow Test\r\n     v" + myVer + " by Matt Hum\r\n    matt.hum@hpe.com";
                string title = "About SIFTest";
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var ServerAddr = string.Empty;
            var ServerPort = string.Empty;

            ServerAddr = textBox1.Text.Trim();
            ServerPort = textBox2.Text.Trim();
            textBox3.AppendText("Connecting to " + ServerAddr + ":" + ServerPort + "\r\n");
            button1.Enabled = false;
            IPAddress rServerIP = IPAddress.None;

            try
            {
                if (!IPAddress.TryParse(ServerAddr, out rServerIP))
                {
                    IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync(ServerAddr);
                    rServerIP = ipHostInfo.AddressList[0];
                    textBox3.AppendText("Resolved " + ServerAddr + " to " + rServerIP.ToString() + "\r\n");
                }
                IPEndPoint ServerIP = new(rServerIP, Int32.Parse(ServerPort));

                client = new Socket(ServerIP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                client.Connect(ServerIP);
                byte[] messageBytes = Encoding.ASCII.GetBytes("Hi\n");
                _ = client.Send(messageBytes);

                client.ReceiveTimeout = 5000;
                byte[] buffer = new byte[1024];
                int byterecv = client.Receive(buffer);
                var resp = Encoding.ASCII.GetString(buffer, 0, byterecv);

                if (resp.StartsWith("Hello"))
                {
                    Connected = true;
                    button2.Enabled = true;
                    textBox3.AppendText("Control channel Established.\r\n");
                    textBox4.Enabled = true;
                    button3.Enabled = true;
                    textBox4.Select();
                }
                else
                {
                    button1.Enabled = true;
                    textBox3.AppendText("Couldn't connect to " + textBox1.Text.Trim() + "\r\n");
                    client.Shutdown(SocketShutdown.Both);
                    client.Close();
                }
            }
            catch (FormatException err)
            {
                button1.Enabled = true;
                textBox3.AppendText("Error: " + err.ToString() + "\r\n");
            }
            catch (ArgumentNullException err)
            {
                button1.Enabled = true;
                textBox3.AppendText("Argument Null Exception: " + err.ToString() + "\r\n");
            }
            catch (SocketException err)
            {
                button1.Enabled = true;
                textBox3.AppendText($"Socket Error: {err.Message}\r\n");
                textBox3.AppendText("tried: " + rServerIP.ToString() + ":" + ServerPort + "\r\n");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            byte[] messageBytes = Encoding.ASCII.GetBytes("exit\n");
            _ = client.Send(messageBytes);
            client.Shutdown(SocketShutdown.Both);
            client.Close();
            textBox3.AppendText("Closed Control Channel\r\n");
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var command = textBox4.Text.Trim().ToLower();
            if (command != "")
            {
                textBox4.Text = "";
                if (command.StartsWith("connect"))
                {
                    var lport = command.Split(' ')[1];
                    textBox3.AppendText("Trying to open local port " + lport + "\r\n");
                    var udpport = Int32.Parse(lport.Trim());
                    Socket udpsock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    EndPoint epFrom = new IPEndPoint(IPAddress.Any, udpport);
                    udpsock.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.ReuseAddress, true);
                    udpsock.Bind(epFrom);
                    textBox3.AppendText("Opened data channel on UDP" + lport + "\r\n");
                    byte[] messageBytes = Encoding.ASCII.GetBytes(command + "\n");
                    _ = client.Send(messageBytes);
                    textBox3.AppendText("Sending: " + command + "\r\n");
                    try
                    {
                        while (true)
                        {
                            byte[] rdata = new byte[1024];
                            udpsock.ReceiveFrom(rdata, ref epFrom);
                            string recvd = Encoding.ASCII.GetString(rdata);
                            if (recvd.StartsWith("EXIT"))
                            {
                                break;
                            }
                            textBox3.AppendText("Got [" + epFrom.ToString() + "]: " + recvd);
                            textBox3.AppendText("\r\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        textBox3.AppendText("Error:" + ex.Message + "\r\n");
                    }
                    finally
                    {
                        textBox3.AppendText("Closed data channel on UDP" + lport + "\r\n");
                        udpsock.Close();
                    }

                }
                else if (command.StartsWith("exit"))
                {
                    button2_Click(this, new EventArgs());
                }
                else
                {

                    try
                    {
                        byte[] messageBytes = Encoding.ASCII.GetBytes(command + "\n");
                        _ = client.Send(messageBytes);
                        textBox3.AppendText("Sending: " + command + "\r\n");

                        byte[] buffer = new byte[1024];
                        int byterecv = client.Receive(buffer);
                        var resp = Encoding.ASCII.GetString(buffer, 0, byterecv);
                        textBox3.AppendText("Got response: " + resp + "\r\n");
                    }
                    catch (FormatException err)
                    {
                        button1.Enabled = true;
                        textBox3.AppendText("Error: " + err.ToString() + "\r\n");
                    }
                    catch (ArgumentNullException err)
                    {
                        button1.Enabled = true;
                        textBox3.AppendText("Argument Null Exception: " + err.ToString() + "\r\n");
                    }
                    catch (SocketException err)
                    {
                        button1.Enabled = true;
                        textBox3.AppendText($"Socket Error: {err.Message}\r\n");
                    }
                }
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button3_Click(this, new EventArgs());
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                button1_Click(this, new EventArgs());
                e.Handled = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            try
            {
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "https://arubanetworks.com";
                myProcess.Start();
            }
            catch (Exception err)
            {
                textBox4.AppendText(err.Message + "\r\n");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process myProcess = new Process();
            try
            {
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "https://axissecurity.com";
                myProcess.Start();
            }
            catch (Exception err)
            {
                textBox4.AppendText(err.Message + "\r\n");
            }
        }
    }
}