namespace CcbitsSerialAssistants
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.combComList = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labBit0 = new System.Windows.Forms.Label();
            this.btnOpenCom = new System.Windows.Forms.Button();
            this.labStopBit = new System.Windows.Forms.Label();
            this.labVerifyBit = new System.Windows.Forms.Label();
            this.labBaud = new System.Windows.Forms.Label();
            this.labDataBit = new System.Windows.Forms.Label();
            this.labComList = new System.Windows.Forms.Label();
            this.combStopbitList = new System.Windows.Forms.ComboBox();
            this.combParityList = new System.Windows.Forms.ComboBox();
            this.combDataBit = new System.Windows.Forms.ComboBox();
            this.combBaudList = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslLabStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtReceived = new System.Windows.Forms.TextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radStringRecerived = new System.Windows.Forms.RadioButton();
            this.radHexRecerived = new System.Windows.Forms.RadioButton();
            this.btnReveCls = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radStringSend = new System.Windows.Forms.RadioButton();
            this.radHEXSend = new System.Windows.Forms.RadioButton();
            this.btnSendCls = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // combComList
            // 
            this.combComList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combComList.FormattingEnabled = true;
            this.combComList.Location = new System.Drawing.Point(66, 20);
            this.combComList.Name = "combComList";
            this.combComList.Size = new System.Drawing.Size(83, 20);
            this.combComList.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labBit0);
            this.groupBox1.Controls.Add(this.btnOpenCom);
            this.groupBox1.Controls.Add(this.labStopBit);
            this.groupBox1.Controls.Add(this.labVerifyBit);
            this.groupBox1.Controls.Add(this.labBaud);
            this.groupBox1.Controls.Add(this.labDataBit);
            this.groupBox1.Controls.Add(this.labComList);
            this.groupBox1.Controls.Add(this.combStopbitList);
            this.groupBox1.Controls.Add(this.combParityList);
            this.groupBox1.Controls.Add(this.combDataBit);
            this.groupBox1.Controls.Add(this.combBaudList);
            this.groupBox1.Controls.Add(this.combComList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(166, 206);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "串口设置";
            // 
            // labBit0
            // 
            this.labBit0.AutoSize = true;
            this.labBit0.Location = new System.Drawing.Point(117, 77);
            this.labBit0.Name = "labBit0";
            this.labBit0.Size = new System.Drawing.Size(23, 12);
            this.labBit0.TabIndex = 3;
            this.labBit0.Text = "bit";
            // 
            // btnOpenCom
            // 
            this.btnOpenCom.Location = new System.Drawing.Point(14, 160);
            this.btnOpenCom.Name = "btnOpenCom";
            this.btnOpenCom.Size = new System.Drawing.Size(135, 32);
            this.btnOpenCom.TabIndex = 2;
            this.btnOpenCom.Text = "连接";
            this.btnOpenCom.UseVisualStyleBackColor = true;
            this.btnOpenCom.Click += new System.EventHandler(this.btnOpenCom_Click);
            // 
            // labStopBit
            // 
            this.labStopBit.AutoSize = true;
            this.labStopBit.Location = new System.Drawing.Point(12, 128);
            this.labStopBit.Name = "labStopBit";
            this.labStopBit.Size = new System.Drawing.Size(53, 12);
            this.labStopBit.TabIndex = 1;
            this.labStopBit.Text = "停止位：";
            // 
            // labVerifyBit
            // 
            this.labVerifyBit.AutoSize = true;
            this.labVerifyBit.Location = new System.Drawing.Point(12, 102);
            this.labVerifyBit.Name = "labVerifyBit";
            this.labVerifyBit.Size = new System.Drawing.Size(53, 12);
            this.labVerifyBit.TabIndex = 1;
            this.labVerifyBit.Text = "校验位：";
            // 
            // labBaud
            // 
            this.labBaud.AutoSize = true;
            this.labBaud.Location = new System.Drawing.Point(12, 50);
            this.labBaud.Name = "labBaud";
            this.labBaud.Size = new System.Drawing.Size(53, 12);
            this.labBaud.TabIndex = 1;
            this.labBaud.Text = "波特率：";
            // 
            // labDataBit
            // 
            this.labDataBit.AutoSize = true;
            this.labDataBit.Location = new System.Drawing.Point(12, 76);
            this.labDataBit.Name = "labDataBit";
            this.labDataBit.Size = new System.Drawing.Size(53, 12);
            this.labDataBit.TabIndex = 1;
            this.labDataBit.Text = "数据位：";
            // 
            // labComList
            // 
            this.labComList.AutoSize = true;
            this.labComList.Location = new System.Drawing.Point(12, 24);
            this.labComList.Name = "labComList";
            this.labComList.Size = new System.Drawing.Size(53, 12);
            this.labComList.TabIndex = 1;
            this.labComList.Text = "端口号：";
            // 
            // combStopbitList
            // 
            this.combStopbitList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combStopbitList.FormattingEnabled = true;
            this.combStopbitList.Location = new System.Drawing.Point(66, 124);
            this.combStopbitList.Name = "combStopbitList";
            this.combStopbitList.Size = new System.Drawing.Size(83, 20);
            this.combStopbitList.TabIndex = 0;
            // 
            // combParityList
            // 
            this.combParityList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combParityList.FormattingEnabled = true;
            this.combParityList.Location = new System.Drawing.Point(66, 98);
            this.combParityList.Name = "combParityList";
            this.combParityList.Size = new System.Drawing.Size(83, 20);
            this.combParityList.TabIndex = 0;
            // 
            // combDataBit
            // 
            this.combDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combDataBit.FormattingEnabled = true;
            this.combDataBit.Location = new System.Drawing.Point(66, 72);
            this.combDataBit.Name = "combDataBit";
            this.combDataBit.Size = new System.Drawing.Size(45, 20);
            this.combDataBit.TabIndex = 0;
            // 
            // combBaudList
            // 
            this.combBaudList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combBaudList.FormattingEnabled = true;
            this.combBaudList.Location = new System.Drawing.Point(66, 46);
            this.combBaudList.Name = "combBaudList";
            this.combBaudList.Size = new System.Drawing.Size(83, 20);
            this.combBaudList.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslLabStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 470);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(870, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tsslLabStatus
            // 
            this.tsslLabStatus.Name = "tsslLabStatus";
            this.tsslLabStatus.Size = new System.Drawing.Size(32, 17);
            this.tsslLabStatus.Text = "断开";
            // 
            // txtReceived
            // 
            this.txtReceived.Location = new System.Drawing.Point(194, 12);
            this.txtReceived.Multiline = true;
            this.txtReceived.Name = "txtReceived";
            this.txtReceived.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtReceived.Size = new System.Drawing.Size(532, 206);
            this.txtReceived.TabIndex = 3;
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(194, 224);
            this.txtSend.Multiline = true;
            this.txtSend.Name = "txtSend";
            this.txtSend.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSend.Size = new System.Drawing.Size(532, 80);
            this.txtSend.TabIndex = 3;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(616, 316);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(110, 50);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radStringRecerived);
            this.groupBox2.Controls.Add(this.radHexRecerived);
            this.groupBox2.Controls.Add(this.btnReveCls);
            this.groupBox2.Location = new System.Drawing.Point(732, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(126, 206);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "收码区";
            // 
            // radStringRecerived
            // 
            this.radStringRecerived.AutoSize = true;
            this.radStringRecerived.Location = new System.Drawing.Point(9, 57);
            this.radStringRecerived.Name = "radStringRecerived";
            this.radStringRecerived.Size = new System.Drawing.Size(59, 16);
            this.radStringRecerived.TabIndex = 0;
            this.radStringRecerived.Text = "字符串";
            this.radStringRecerived.UseVisualStyleBackColor = true;
            // 
            // radHexRecerived
            // 
            this.radHexRecerived.AutoSize = true;
            this.radHexRecerived.Checked = true;
            this.radHexRecerived.Location = new System.Drawing.Point(9, 35);
            this.radHexRecerived.Name = "radHexRecerived";
            this.radHexRecerived.Size = new System.Drawing.Size(53, 16);
            this.radHexRecerived.TabIndex = 0;
            this.radHexRecerived.TabStop = true;
            this.radHexRecerived.Text = "HEX码";
            this.radHexRecerived.UseVisualStyleBackColor = true;
            // 
            // btnReveCls
            // 
            this.btnReveCls.Location = new System.Drawing.Point(9, 150);
            this.btnReveCls.Name = "btnReveCls";
            this.btnReveCls.Size = new System.Drawing.Size(52, 27);
            this.btnReveCls.TabIndex = 2;
            this.btnReveCls.Text = "清除";
            this.btnReveCls.UseVisualStyleBackColor = true;
            this.btnReveCls.Click += new System.EventHandler(this.btnReveCls_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radStringSend);
            this.groupBox3.Controls.Add(this.radHEXSend);
            this.groupBox3.Controls.Add(this.btnSendCls);
            this.groupBox3.Location = new System.Drawing.Point(732, 225);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(126, 151);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "发码区";
            // 
            // radStringSend
            // 
            this.radStringSend.AutoSize = true;
            this.radStringSend.Location = new System.Drawing.Point(9, 44);
            this.radStringSend.Name = "radStringSend";
            this.radStringSend.Size = new System.Drawing.Size(59, 16);
            this.radStringSend.TabIndex = 0;
            this.radStringSend.Text = "字符串";
            this.radStringSend.UseVisualStyleBackColor = true;
            // 
            // radHEXSend
            // 
            this.radHEXSend.AutoSize = true;
            this.radHEXSend.Checked = true;
            this.radHEXSend.Location = new System.Drawing.Point(9, 22);
            this.radHEXSend.Name = "radHEXSend";
            this.radHEXSend.Size = new System.Drawing.Size(53, 16);
            this.radHEXSend.TabIndex = 0;
            this.radHEXSend.TabStop = true;
            this.radHEXSend.Text = "HEX码";
            this.radHEXSend.UseVisualStyleBackColor = true;
            // 
            // btnSendCls
            // 
            this.btnSendCls.Location = new System.Drawing.Point(7, 86);
            this.btnSendCls.Name = "btnSendCls";
            this.btnSendCls.Size = new System.Drawing.Size(52, 23);
            this.btnSendCls.TabIndex = 2;
            this.btnSendCls.Text = "清除";
            this.btnSendCls.UseVisualStyleBackColor = true;
            this.btnSendCls.Click += new System.EventHandler(this.btnSendCls_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(194, 312);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(416, 54);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "快速设置";
            // 
            // txtLogs
            // 
            this.txtLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtLogs.Location = new System.Drawing.Point(194, 392);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogs.Size = new System.Drawing.Size(532, 62);
            this.txtLogs.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 373);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "设置日志：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 492);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReceived);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ccbits串口助手";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combComList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labBaud;
        private System.Windows.Forms.Label labComList;
        private System.Windows.Forms.ComboBox combBaudList;
        private System.Windows.Forms.Label labVerifyBit;
        private System.Windows.Forms.Label labDataBit;
        private System.Windows.Forms.ComboBox combParityList;
        private System.Windows.Forms.ComboBox combDataBit;
        private System.Windows.Forms.Label labStopBit;
        private System.Windows.Forms.ComboBox combStopbitList;
        private System.Windows.Forms.Button btnOpenCom;
        private System.Windows.Forms.Label labBit0;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslLabStatus;
        private System.Windows.Forms.TextBox txtReceived;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radHexRecerived;
        private System.Windows.Forms.RadioButton radStringRecerived;
        private System.Windows.Forms.RadioButton radStringSend;
        private System.Windows.Forms.RadioButton radHEXSend;
        private System.Windows.Forms.Button btnReveCls;
        private System.Windows.Forms.Button btnSendCls;
    }
}

