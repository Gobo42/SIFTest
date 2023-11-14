namespace SIFTestWinClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            textBox3 = new TextBox();
            button2 = new Button();
            button3 = new Button();
            textBox4 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.CharacterCasing = CharacterCasing.Lower;
            textBox1.Location = new Point(156, 96);
            textBox1.Margin = new Padding(4);
            textBox1.MinimumSize = new Size(184, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 43);
            textBox1.TabIndex = 0;
            toolTip1.SetToolTip(textBox1, "This is the IP or hostname of the server to connect to");
            textBox1.WordWrap = false;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox2.Location = new Point(480, 96);
            textBox2.Margin = new Padding(4);
            textBox2.MaxLength = 5;
            textBox2.MinimumSize = new Size(90, 30);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(146, 43);
            textBox2.TabIndex = 1;
            textBox2.Text = "8080";
            toolTip1.SetToolTip(textBox2, "This is the port of the server to connect to");
            textBox2.WordWrap = false;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 102);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(119, 37);
            label1.TabIndex = 2;
            label1.Text = "Server IP";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(407, 102);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(65, 37);
            label2.TabIndex = 3;
            label2.Text = "Port";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(638, 92);
            button1.Margin = new Padding(4);
            button1.MinimumSize = new Size(169, 56);
            button1.Name = "button1";
            button1.Size = new Size(188, 56);
            button1.TabIndex = 4;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Location = new Point(21, 290);
            textBox3.Margin = new Padding(4);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.ScrollBars = ScrollBars.Vertical;
            textBox3.Size = new Size(1046, 428);
            textBox3.TabIndex = 5;
            textBox3.TabStop = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Enabled = false;
            button2.Location = new Point(832, 92);
            button2.Margin = new Padding(4);
            button2.MinimumSize = new Size(169, 56);
            button2.Name = "button2";
            button2.Size = new Size(188, 56);
            button2.TabIndex = 6;
            button2.Text = "Disconnect";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Enabled = false;
            button3.Location = new Point(720, 155);
            button3.Margin = new Padding(4);
            button3.MinimumSize = new Size(281, 56);
            button3.Name = "button3";
            button3.Size = new Size(300, 56);
            button3.TabIndex = 8;
            button3.Text = "Send Command";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox4.CharacterCasing = CharacterCasing.Lower;
            textBox4.Enabled = false;
            textBox4.Location = new Point(30, 159);
            textBox4.Margin = new Padding(4);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "connect 2000";
            textBox4.Size = new Size(679, 43);
            textBox4.TabIndex = 7;
            toolTip1.SetToolTip(textBox4, "Use \"Connect <port>\" where port is between 1024 and 65535");
            textBox4.WordWrap = false;
            textBox4.TextChanged += textBox4_TextChanged;
            textBox4.KeyDown += textBox4_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 213);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(796, 74);
            label3.TabIndex = 9;
            label3.Text = "use the command \"connect <port>\"\r\n<port> is the port that you want to listen to between 1024-65535";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.Font = new Font("Segoe UI", 5F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(860, 722);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(204, 20);
            label4.TabIndex = 10;
            label4.Text = "v1.0.1 by matt.hum@hpe.com";
            label4.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(855, 22);
            pictureBox1.Margin = new Padding(6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 61);
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            toolTip1.SetToolTip(pictureBox1, "HPE Aruba");
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(994, 22);
            pictureBox2.Margin = new Padding(6);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(77, 61);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            toolTip1.SetToolTip(pictureBox2, "Axis Security");
            pictureBox2.Click += pictureBox2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 746);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            ForeColor = SystemColors.ControlText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4);
            MinimumSize = new Size(1100, 765);
            Name = "Form1";
            Text = "SIF Test Client";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button button1;
        private TextBox textBox3;
        private Button button2;
        private Button button3;
        private TextBox textBox4;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private ToolTip toolTip1;
    }
}