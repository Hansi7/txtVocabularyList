using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace 单词处理
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Save(string fileName, string content)
        {
            string f = AppDomain.CurrentDomain.BaseDirectory + fileName + ".txt";
            System.IO.File.WriteAllText(f, content);
            //System.Diagnostics.Process.Start(f);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        int number = 0;
        string filename = "";
        iciba ciba = new iciba();

        private void btn_onlyword_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txt_numberPerPage.Text,out number))
	        {
                MessageBox.Show("请填写设置每个文件的单词数");
                return;
	        }
            if (txt_FileName.Text=="")
            {
                MessageBox.Show("请填写文件名");
                return;
            }
            else
            {
                filename = txt_FileName.Text;
            }
            
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.Multiselect = false;

            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string fi = ofd.FileName;
            this.label1.Text = fi;
            this.Update();
            var s1 = System.IO.File.ReadAllText(fi);

            for (int i = 1; i < 7000; i++)
            {

            }


            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"[a-zA-Z'-]+");
            
            var ms = r.Matches(s1);


            StringBuilder sb = new StringBuilder();
            foreach (System.Text.RegularExpressions.Match item in ms)
            {
                sb.AppendLine(item.ToString());

            }
            Save("去除杂项的单词表", sb.ToString());

            // var kkk = r.Replace(s1, "");

            //MessageBox.Show(kkk);
            
            
            this.progressBar1.Maximum = ms.Count;
//            StringBuilder sb = new StringBuilder();

            int startNumber = 0;
            foreach (System.Text.RegularExpressions.Match w in ms)
            {
                var wd =  ciba.QueryWord(w.ToString());
                if (wd!=null)
                {
                    txt_result.AppendText(wd.ToString());
                }
                this.progressBar1.Value = this.progressBar1.Value + 1;
                this.lbl_n.Text = this.progressBar1.Value.ToString() + "/" + this.progressBar1.Maximum.ToString();
                this.Update();
                if (progressBar1.Value % number == 0)
                {
                    Save(filename + (progressBar1.Value-499) + "-" + this.progressBar1.Value.ToString(), txt_result.Text);
                    txt_result.Text = "";
                    startNumber = progressBar1.Value;
                }
            }
            Save(filename + number.ToString() + "-" + progressBar1.Value, txt_result.Text);

            MessageBox.Show("完成！结果文件在程序所在的目录！");
            System.Diagnostics.Process.Start("explorer", AppDomain.CurrentDomain.BaseDirectory);
        }


    }
}
