namespace WebServerWithGui
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
            btnStart = new Button();
            btnStop = new Button();
            tbServerIp = new TextBox();
            tbPort = new TextBox();
            labelServerIp = new Label();
            labelPort = new Label();
            tbContent = new TextBox();
            labelContent = new Label();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(84, 139);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(200, 139);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // tbServerIp
            // 
            tbServerIp.Location = new Point(67, 110);
            tbServerIp.Name = "tbServerIp";
            tbServerIp.ReadOnly = true;
            tbServerIp.Size = new Size(112, 23);
            tbServerIp.TabIndex = 2;
            tbServerIp.Text = "https://localhost:";
            // 
            // tbPort
            // 
            tbPort.Location = new Point(180, 110);
            tbPort.MaxLength = 5;
            tbPort.Name = "tbPort";
            tbPort.Size = new Size(114, 23);
            tbPort.TabIndex = 3;
            // 
            // labelServerIp
            // 
            labelServerIp.AutoSize = true;
            labelServerIp.Location = new Point(97, 92);
            labelServerIp.Name = "labelServerIp";
            labelServerIp.Size = new Size(52, 15);
            labelServerIp.TabIndex = 4;
            labelServerIp.Text = "Server IP";
            // 
            // labelPort
            // 
            labelPort.AutoSize = true;
            labelPort.Location = new Point(223, 92);
            labelPort.Name = "labelPort";
            labelPort.Size = new Size(29, 15);
            labelPort.TabIndex = 5;
            labelPort.Text = "Port";
            // 
            // tbContent
            // 
            tbContent.Location = new Point(67, 48);
            tbContent.Name = "tbContent";
            tbContent.Size = new Size(227, 23);
            tbContent.TabIndex = 6;
            // 
            // labelContent
            // 
            labelContent.AutoSize = true;
            labelContent.Location = new Point(142, 30);
            labelContent.Name = "labelContent";
            labelContent.Size = new Size(77, 15);
            labelContent.TabIndex = 7;
            labelContent.Text = "Content path";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(341, 249);
            Controls.Add(labelContent);
            Controls.Add(tbContent);
            Controls.Add(labelPort);
            Controls.Add(labelServerIp);
            Controls.Add(tbPort);
            Controls.Add(tbServerIp);
            Controls.Add(btnStart);
            Controls.Add(btnStop);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnStop;
        private TextBox tbServerIp;
        private TextBox tbPort;
        private Label labelServerIp;
        private Label labelPort;
        private TextBox tbContent;
        private Label labelContent;
    }
}