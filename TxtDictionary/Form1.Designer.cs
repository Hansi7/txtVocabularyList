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
            this.txt_result = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_result
            // 
            this.txt_result.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txt_result.Location = new System.Drawing.Point(0, 159);
            this.txt_result.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_result.Multiline = true;
            this.txt_result.Name = "txt_result";
            this.txt_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_result.Size = new System.Drawing.Size(871, 417);
            this.txt_result.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(124, 50);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(723, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(121, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            // 
            // btn_onlyword
            // 
            this.btn_onlyword.Location = new System.Drawing.Point(14, 13);
            this.btn_onlyword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_onlyword.Name = "btn_onlyword";
            this.btn_onlyword.Size = new System.Drawing.Size(101, 31);
            this.btn_onlyword.TabIndex = 8;
            this.btn_onlyword.Text = "打开单词表...";
            this.btn_onlyword.UseVisualStyleBackColor = true;
            this.btn_onlyword.Click += new System.EventHandler(this.btn_onlyword_Click);
            // 
            // lbl_n
            // 
            this.lbl_n.AutoSize = true;
            this.lbl_n.Location = new System.Drawing.Point(790, 76);
            this.lbl_n.Name = "lbl_n";
            this.lbl_n.Size = new System.Drawing.Size(44, 16);
            this.lbl_n.TabIndex = 11;
            this.lbl_n.Text = "label4";
            // 
            // txt_numberPerPage
            // 
            this.txt_numberPerPage.Location = new System.Drawing.Point(32, 19);
            this.txt_numberPerPage.Name = "txt_numberPerPage";
            this.txt_numberPerPage.Size = new System.Drawing.Size(100, 26);
            this.txt_numberPerPage.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_removeP);
            this.groupBox1.Controls.Add(this.txt_FileName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_numberPerPage);
            this.groupBox1.Location = new System.Drawing.Point(14, 79);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(727, 57);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // cb_removeP
            // 
            this.cb_removeP.AutoSize = true;
            this.cb_removeP.Checked = true;
            this.cb_removeP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_removeP.Location = new System.Drawing.Point(532, 21);
            this.cb_removeP.Name = "cb_removeP";
            this.cb_removeP.Size = new System.Drawing.Size(147, 20);
            this.cb_removeP.TabIndex = 17;
            this.cb_removeP.Text = "忽略带‘(单引号)的单词";
            this.cb_removeP.UseVisualStyleBackColor = true;
            // 
            // txt_FileName
            // 
            this.txt_FileName.Location = new System.Drawing.Point(322, 19);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.Size = new System.Drawing.Size(204, 26);
            this.txt_FileName.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(260, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "文件名为";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(138, 22);
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
            this.btn_Info.Location = new System.Drawing.Point(747, 94);
            this.btn_Info.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Info.Name = "btn_Info";
            this.btn_Info.Size = new System.Drawing.Size(87, 31);
            this.btn_Info.TabIndex = 14;
            this.btn_Info.Text = "使用说明";
            this.btn_Info.UseVisualStyleBackColor = true;
            this.btn_Info.Click += new System.EventHandler(this.btn_Info_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Location = new System.Drawing.Point(14, 42);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(101, 31);
            this.btn_Stop.TabIndex = 15;
            this.btn_Stop.Text = "停止";
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 576);
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
        private System.Windows.Forms.Label label1;
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
    }
}

