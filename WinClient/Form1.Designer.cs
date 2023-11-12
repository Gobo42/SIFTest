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
            textBox1.Location = new Point(83, 52);
            textBox1.Margin = new Padding(2);
            textBox1.MinimumSize = new Size(100, 30);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(130, 30);
            textBox1.TabIndex = 0;
            toolTip1.SetToolTip(textBox1, "This is the IP or hostname of the server to connect to");
            textBox1.WordWrap = false;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBox2.Location = new Point(256, 52);
            textBox2.Margin = new Padding(2);
            textBox2.MaxLength = 5;
            textBox2.MinimumSize = new Size(50, 30);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(80, 30);
            textBox2.TabIndex = 1;
            textBox2.Text = "8080";
            toolTip1.SetToolTip(textBox2, "This is the port of the server to connect to");
            textBox2.WordWrap = false;
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 55);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(66, 20);
            label1.TabIndex = 2;
            label1.Text = "Server IP";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(217, 55);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(35, 20);
            label2.TabIndex = 3;
            label2.Text = "Port";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.Location = new Point(340, 50);
            button1.Margin = new Padding(2);
            button1.MinimumSize = new Size(90, 30);
            button1.Name = "button1";
            button1.Size = new Size(100, 30);
            button1.TabIndex = 4;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Location = new Point(11, 157);
            textBox3.Margin = new Padding(2);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(560, 233);
            textBox3.TabIndex = 5;
            textBox3.TabStop = false;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Enabled = false;
            button2.Location = new Point(444, 50);
            button2.Margin = new Padding(2);
            button2.MinimumSize = new Size(90, 30);
            button2.Name = "button2";
            button2.Size = new Size(100, 30);
            button2.TabIndex = 6;
            button2.Text = "Disconnect";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.Enabled = false;
            button3.Location = new Point(384, 84);
            button3.Margin = new Padding(2);
            button3.MinimumSize = new Size(150, 30);
            button3.Name = "button3";
            button3.Size = new Size(160, 30);
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
            textBox4.Location = new Point(16, 86);
            textBox4.Margin = new Padding(2);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "connect 2000";
            textBox4.Size = new Size(364, 27);
            textBox4.TabIndex = 7;
            toolTip1.SetToolTip(textBox4, "Use \"Connect <port>\" where port is between 1024 and 65535");
            textBox4.WordWrap = false;
            textBox4.TextChanged += textBox4_TextChanged;
            textBox4.KeyDown += textBox4_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 115);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(440, 40);
            label3.TabIndex = 9;
            label3.Text = "use the command \"connect <port>\"\r\n<port> is the port that you want to listen to between 1024-65535";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 5F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(455, 390);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(123, 12);
            label4.TabIndex = 10;
            label4.Text = "v1.0.0 by matt.hum@hpe.com";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(456, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(68, 33);
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
            pictureBox2.Location = new Point(530, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(41, 33);
            pictureBox2.TabIndex = 12;
            pictureBox2.TabStop = false;
            toolTip1.SetToolTip(pictureBox2, "Axis Security");
            pictureBox2.Click += pictureBox2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 403);
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
            Margin = new Padding(2);
            MinimumSize = new Size(600, 450);
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