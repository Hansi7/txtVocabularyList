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

namespace TxtDictionary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ProgressBar.CheckForIllegalCrossThreadCalls = false;
        }

        string filename = "";
        iciba ciba = new iciba();
        int CountInPage = 0;
        string subDirName;
        Thread th;
        List<Word> l_result = new List<Word>();
        List<Word> l_ignore = new List<Word>();

        void reset()
        {
            progressBar1.Value = 0;
            txt_result.Text = "";
            l_result.Clear();
            l_ignore.Clear();
            subDirName = AppDomain.CurrentDomain.BaseDirectory + @"生成结果" + DateTime.Now.ToString("yyyyMMddHHmmss");
        }
        private void btn_onlyword_Click(object sender, EventArgs e)
        {
            reset();

            if (!int.TryParse(txt_numberPerPage.Text, out CountInPage))
            {
                MessageBox.Show("请填写设置每个文件的单词数");
                return;
            }
            if (txt_FileName.Text == "")
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
            this.label1.Text = ofd.FileName;
            this.Update();


            th = new Thread(process);
            th.IsBackground = true;
            th.Start();

        }
        private void process()
        {
            var s1 = System.IO.File.ReadAllText(label1.Text);
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"[a-zA-Z'-]+");
            var ms = r.Matches(s1);
            this.progressBar1.Maximum = ms.Count;
            int numberInPage = 0;
            int A = 0;
            int B = 0;
            StringBuilder sbNotFound = new StringBuilder();
            StringBuilder sbIgnore = new StringBuilder();
            StringBuilder sbResult = new StringBuilder();
            foreach (System.Text.RegularExpressions.Match w in ms)
            {
                var wd = ciba.QueryWord(w.ToString());
                if (wd != null)
                {
                    if (wd.Text.Contains('\'') && cb_removeP.Checked)
                    {
                        sbIgnore.Append(wd.ToString());
                        l_ignore.Add(wd);
                    }
                    else
                    {
                        txt_result.AppendText(wd.ToString());
                        sbResult.Append(wd.ToString());
                        l_result.Add(wd);
                        numberInPage++;
                    }
                }
                else
                {
                    sbNotFound.AppendLine(w.ToString());
                }

                this.progressBar1.Value = this.progressBar1.Value + 1;
                this.lbl_n.Text = this.progressBar1.Value.ToString() + "/" + this.progressBar1.Maximum.ToString();
                this.Update();

                if (CountInPage == numberInPage)
                {
                    B = B + CountInPage;
                    Save(filename + "_" + (A + 1) + "-" + B, sbResult.ToString());
                    txt_result.Text = "";
                    sbResult.Clear();
                    numberInPage = 0;
                    A = B;
                }
            }
            StringBuilder sbWords = new StringBuilder();
            foreach (System.Text.RegularExpressions.Match item in ms)
            {
                sbWords.AppendLine(item.ToString());
            }
            Save("除杂的单词表", sbWords.ToString());
            Save(filename + "_" + (A + 1) + "-" + (A + numberInPage), txt_result.Text);
            Save("未找到的单词", sbNotFound.ToString());
            Save("已忽略的单词", sbIgnore.ToString());
            new ExcelTool().Save(subDirName + "\\Result.xlsx", l_result,CountInPage);
            MessageBox.Show("完成！结果文件在程序所在的目录！ 确定后打开目录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            System.Diagnostics.Process.Start("explorer", subDirName);
        }
        private void btn_Info_Click(object sender, EventArgs e)
        {
            this.txt_result.Text = @"
1.填写设置,写入每个文件的单词数,如果只要一个文件,请填写一个足够大的数字，比如99999.写入文件名。
2.选择导入文件，导入文件为单词列表，支持空格、符号分割、干扰字符可以在整理过程中去除。
3.使用wap.iciba.com网站作为数据源。
4.全选、复制、粘贴到Excel中可以多列显示。

                        ---作者：Hansi
                           2014年11月5日
";



        }
        private void Save(string fileName, string content)
        {
            string f = System.IO.Path.Combine(subDirName, fileName + ".txt");
            if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(f)))
            {
                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(f));
            }

            System.IO.File.WriteAllText(f, content);
            //System.Diagnostics.Process.Start(f);
        }
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            if (th!=null)
            {
                this.th.Abort();
                this.txt_result.AppendText("\r\n用户终止！");
            }
        }

    }
}
