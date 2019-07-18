namespace TxtDictionary
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txt_result = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_onlyword = new System.Windows.Forms.Button();
            this.lbl_n = new System.Windows.Forms.Label();
            this.txt_numberPerPage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_removeP = new System.Windows.Forms.CheckBox();
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Info = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.txt_messageBox = new System.Windows.Forms.TextBox();
            this.btn_QuickStart = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(0, 148);
            this.txt_result.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_result.Size = new System.Drawing.Size(730, 428);
            this.txt_result.TabIndex = 4;
            this.txt_result.Text = "在此处输入要添加的单词，每个单词之间用回车分隔";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(226, 47);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(723, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // btn_onlyword
            // 
            this.btn_onlyword.Location = new System.Drawing.Point(14, 13);
            this.btn_onlyword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_onlyword.Name = "btn_onlyword";
            this.btn_onlyword.Size = new System.Drawing.Size(163, 31);
            this.btn_onlyword.TabIndex = 8;
            this.btn_onlyword.Text = "处理txt单词列表文件";
            this.btn_onlyword.UseVisualStyleBackColor = true;
            this.btn_onlyword.Click += new System.EventHandler(this.btn_onlyword_Click);
            // 
            // lbl_n
            // 
            this.lbl_n.AutoSize = true;
            this.lbl_n.Location = new System.Drawing.Point(905, 84);
            this.lbl_n.Name = "lbl_n";
            this.lbl_n.Size = new System.Drawing.Size(44, 16);
            this.lbl_n.TabIndex = 11;
            this.lbl_n.Text = "label4";
            // 
            // txt_numberPerPage
            // 
            this.txt_numberPerPage.Location = new System.Drawing.Point(32, 19);
            this.txt_numberPerPage.Name = "txt_numberPerPage";
            this.txt_numberPerPage.Size = new System.Drawing.Size(69, 26);
            this.txt_numberPerPage.TabIndex = 12;
            this.txt_numberPerPage.Text = "99999";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_removeP);
            this.groupBox1.Controls.Add(this.txt_FileName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_numberPerPage);
            this.groupBox1.Location = new System.Drawing.Point(226, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 57);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // cb_removeP
            // 
            this.cb_removeP.AutoSize = true;
            this.cb_removeP.Checked = true;
            this.cb_removeP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_removeP.Location = new System.Drawing.Point(421, 21);
            this.cb_removeP.Name = "cb_removeP";
            this.cb_removeP.Size = new System.Drawing.Size(147, 20);
            this.cb_removeP.TabIndex = 17;
            this.cb_removeP.Text = "忽略带‘(单引号)的单词";
            this.cb_removeP.UseVisualStyleBackColor = true;
            // 
            // txt_FileName
            // 
            this.txt_FileName.Location = new System.Drawing.Point(291, 19);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.Size = new System.Drawing.Size(124, 26);
            this.txt_FileName.TabIndex = 16;
            this.txt_FileName.Text = "Grace English";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "文件名为";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "单词保存成一个文件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "每";
            // 
            // btn_Info
            // 
            this.btn_Info.Location = new System.Drawing.Point(14, 103);
            this.btn_Info.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Info.Name = "btn_Info";
            this.btn_Info.Size = new System.Drawing.Size(74, 31);
            this.btn_Info.TabIndex = 14;
            this.btn_Info.Text = "使用说明";
            this.btn_Info.UseVisualStyleBackColor = true;
            this.btn_Info.Click += new System.EventHandler(this.btn_Info_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(955, 47);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(41, 23);
            this.btn_Stop.TabIndex = 15;
            this.btn_Stop.Text = "停止";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // txt_messageBox
            // 
            this.txt_messageBox.Location = new System.Drawing.Point(736, 148);
            this.txt_messageBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_messageBox.Multiline = true;
            this.txt_messageBox.Name = "txt_messageBox";
            this.txt_messageBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_messageBox.Size = new System.Drawing.Size(314, 428);
            this.txt_messageBox.TabIndex = 16;
            // 
            // btn_QuickStart
            // 
            this.btn_QuickStart.Location = new System.Drawing.Point(14, 47);
            this.btn_QuickStart.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_QuickStart.Name = "btn_QuickStart";
            this.btn_QuickStart.Size = new System.Drawing.Size(163, 53);
            this.btn_QuickStart.TabIndex = 17;
            this.btn_QuickStart.Text = "以下面文本框内容\r\n为单词列表进行处理";
            this.btn_QuickStart.UseVisualStyleBackColor = true;
            this.btn_QuickStart.Click += new System.EventHandler(this.btn_QuickStart_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 103);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 31);
            this.button1.TabIndex = 18;
            this.button1.Text = "清空";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(223, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "欢迎使用单词表制作工具--Grace定制版";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 576);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_QuickStart);
            this.Controls.Add(this.txt_messageBox);
            this.Controls.Add(this.btn_Stop);
            this.Controls.Add(this.btn_Info);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbl_n);
            this.Controls.Add(this.btn_onlyword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.txt_result);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "单词表制作工具";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btn_onlyword;
        private System.Windows.Forms.Label lbl_n;
        private System.Windows.Forms.TextBox txt_numberPerPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_FileName;
        private System.Windows.Forms.Button btn_Info;
        private System.Windows.Forms.CheckBox cb_removeP;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.TextBox txt_messageBox;
        private System.Windows.Forms.Button btn_QuickStart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

