using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SIFTestWinClient
{
    public partial class Form1 : Form
    {
        private bool Connected;
        private Socket client { get; set; }

        public Form1()
        {
            InitializeComponent();
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

            try
            {
                IPHostEntry ipHostInfo = await Dns.GetHostEntryAsync(ServerAddr);
                IPAddress rServerIP = ipHostInfo.AddressList[0];
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
                textBox3.AppendText("Error: " + err.ToString());
            }
            catch (ArgumentNullException err)
            {
                button1.Enabled = true;
                textBox3.AppendText("Argument Null Exception: " + err.ToString());
            }
            catch (SocketException err)
            {
                button1.Enabled = true;
                textBox3.AppendText($"Socket Error: {err.Message}");
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
            var command = textBox4.Text.Trim();
            if (command != "")
            {
                textBox4.Text = "";
                if (command.StartsWith("connect"))
                {
                    var lport = command.Split(' ')[1];
                    textBox3.AppendText("Trying to open local port " + lport + "\r\n");
                    var udpport = Int32.Parse(lport.Trim());
                    UdpClient udpserver = new UdpClient(udpport);
                    udpserver.Client.ReceiveTimeout = 5000;
                    textBox3.AppendText("Opened data channel on UDP" + lport + "\r\n");

                    byte[] messageBytes = Encoding.ASCII.GetBytes(command + "\n");
                    _ = client.Send(messageBytes);
                    textBox3.AppendText("Sending: " + command + "\r\n");
                    try
                    {
                        while (true)
                        {
                            var remote = new IPEndPoint(IPAddress.Any, udpport);
                            byte[] rdata = udpserver.Receive(ref remote);
                            string recvd = Encoding.ASCII.GetString(rdata);
                            textBox3.AppendText("Got: " + recvd + "\r\n");
                            // udpserver.Send(new byte[] { 1 }, 1, remote);
                            if (recvd.StartsWith("EXIT"))
                            {
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        textBox3.AppendText("Error:" + ex.Message);
                    }
                    udpserver.Close();
                    textBox3.AppendText("Closed data channel on UDP" + lport + "\r\n");
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
                        textBox3.AppendText("Error: " + err.ToString());
                    }
                    catch (ArgumentNullException err)
                    {
                        button1.Enabled = true;
                        textBox3.AppendText("Argument Null Exception: " + err.ToString());
                    }
                    catch (SocketException err)
                    {
                        button1.Enabled = true;
                        textBox3.AppendText($"Socket Error: {err.Message}");
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
    }
}