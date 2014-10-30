namespace UDP_TCP_Sender
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ePort = new System.Windows.Forms.NumericUpDown();
            this.eDest = new System.Windows.Forms.TextBox();
            this.eData = new System.Windows.Forms.TextBox();
            this.eLog = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ePort)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Destination:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Data:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(509, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Port:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Send TCP";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(177, 209);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(164, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Send UDP";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ePort
            // 
            this.ePort.Location = new System.Drawing.Point(550, 12);
            this.ePort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.ePort.Name = "ePort";
            this.ePort.Size = new System.Drawing.Size(101, 20);
            this.ePort.TabIndex = 1;
            this.ePort.Value = new decimal(new int[] {
            2222,
            0,
            0,
            0});
            // 
            // eDest
            // 
            this.eDest.Location = new System.Drawing.Point(81, 12);
            this.eDest.Name = "eDest";
            this.eDest.Size = new System.Drawing.Size(422, 20);
            this.eDest.TabIndex = 0;
            // 
            // eData
            // 
            this.eData.Location = new System.Drawing.Point(12, 51);
            this.eData.Multiline = true;
            this.eData.Name = "eData";
            this.eData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.eData.Size = new System.Drawing.Size(639, 152);
            this.eData.TabIndex = 2;
            // 
            // eLog
            // 
            this.eLog.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eLog.Location = new System.Drawing.Point(15, 238);
            this.eLog.Multiline = true;
            this.eLog.Name = "eLog";
            this.eLog.ReadOnly = true;
            this.eLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.eLog.Size = new System.Drawing.Size(761, 121);
            this.eLog.TabIndex = 5;
            this.eLog.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(657, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 32);
            this.button3.TabIndex = 11;
            this.button3.Text = "Start TCP Server";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(701, 209);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 12;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(701, 180);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 13;
            this.button5.Text = "About";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 371);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.eLog);
            this.Controls.Add(this.eData);
            this.Controls.Add(this.eDest);
            this.Controls.Add(this.ePort);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ePort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown ePort;
        private System.Windows.Forms.TextBox eDest;
        private System.Windows.Forms.TextBox eData;
        private System.Windows.Forms.TextBox eLog;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}

