namespace TxtDictionary
{
    partial class Form2
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
            this.cb_IsHaveHeader = new System.Windows.Forms.CheckBox();
            this.btn_Brower = new System.Windows.Forms.Button();
            this.lbl_filename = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cb_IsHaveHeader
            // 
            this.cb_IsHaveHeader.AutoSize = true;
            this.cb_IsHaveHeader.Location = new System.Drawing.Point(15, 41);
            this.cb_IsHaveHeader.Name = "cb_IsHaveHeader";
            this.cb_IsHaveHeader.Size = new System.Drawing.Size(72, 16);
            this.cb_IsHaveHeader.TabIndex = 0;
            this.cb_IsHaveHeader.Text = "有标题行";
            this.cb_IsHaveHeader.UseVisualStyleBackColor = true;
            // 
            // btn_Brower
            // 
            this.btn_Brower.Location = new System.Drawing.Point(12, 12);
            this.btn_Brower.Name = "btn_Brower";
            this.btn_Brower.Size = new System.Drawing.Size(75, 23);
            this.btn_Brower.TabIndex = 1;
            this.btn_Brower.Text = "浏览...";
            this.btn_Brower.UseVisualStyleBackColor = true;
            this.btn_Brower.Click += new System.EventHandler(this.btn_Brower_Click);
            // 
            // lbl_filename
            // 
            this.lbl_filename.AutoSize = true;
            this.lbl_filename.Location = new System.Drawing.Point(93, 17);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(11, 12);
            this.lbl_filename.TabIndex = 2;
            this.lbl_filename.Text = "-";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 480);
            this.Controls.Add(this.lbl_filename);
            this.Controls.Add(this.btn_Brower);
            this.Controls.Add(this.cb_IsHaveHeader);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cb_IsHaveHeader;
        private System.Windows.Forms.Button btn_Brower;
        private System.Windows.Forms.Label lbl_filename;
    }
}