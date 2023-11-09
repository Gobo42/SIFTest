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
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(164, 88);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(240, 43);
            textBox1.TabIndex = 0;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(496, 85);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(95, 43);
            textBox2.TabIndex = 1;
            textBox2.Text = "8080";
            textBox2.KeyPress += textBox2_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(39, 91);
            label1.Name = "label1";
            label1.Size = new Size(119, 37);
            label1.TabIndex = 2;
            label1.Text = "Server IP";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(425, 91);
            label2.Name = "label2";
            label2.Size = new Size(65, 37);
            label2.TabIndex = 3;
            label2.Text = "Port";
            // 
            // button1
            // 
            button1.Location = new Point(634, 80);
            button1.Name = "button1";
            button1.Size = new Size(186, 51);
            button1.TabIndex = 4;
            button1.Text = "Connect";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(24, 357);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ReadOnly = true;
            textBox3.Size = new Size(1035, 372);
            textBox3.TabIndex = 5;
            // 
            // button2
            // 
            button2.Enabled = false;
            button2.Location = new Point(844, 77);
            button2.Name = "button2";
            button2.Size = new Size(186, 51);
            button2.TabIndex = 6;
            button2.Text = "Disconnect";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(565, 176);
            button3.Name = "button3";
            button3.Size = new Size(231, 54);
            button3.TabIndex = 7;
            button3.Text = "Send Command";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox4
            // 
            textBox4.Enabled = false;
            textBox4.Location = new Point(62, 182);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(497, 43);
            textBox4.TabIndex = 8;
            textBox4.KeyDown += textBox4_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(62, 251);
            label3.Name = "label3";
            label3.Size = new Size(534, 74);
            label3.TabIndex = 9;
            label3.Text = "use the command \"connect <port>\"\r\n<port> is the port that you want to listen to";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1094, 760);
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
            Name = "Form1";
            Text = "SIF Test Client";
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
    }
}