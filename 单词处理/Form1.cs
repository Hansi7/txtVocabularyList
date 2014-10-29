using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace 单词处理
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            ofd.Multiselect = false;

            if (ofd.ShowDialog()!= System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            string fi = ofd.FileName;
            this.label1.Text = fi;
            this.Update();
            var s1 = System.IO.File.ReadAllLines(fi);
            string[] result = new string[s1.Count()];

            for (int i = 0; i < s1.Count(); i++)
            {
                result[i] = s1[i].TrimStart(' ');
            }
            //两个意思的单词
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(@"(\w+)\s+((n|adj|vt|adv|vi|prep|abbr)\.\s*\&*\s*(n|adj|vt|adv|vi|prep|abbr)\.)\s*(.+)");
            //一个意思的单词
            System.Text.RegularExpressions.Regex r2 = new System.Text.RegularExpressions.Regex(@"(\w+)\s+((n|adj|vt|adv|vi|prep|abbr)\.)\s*(.+)");
            //短语
            System.Text.RegularExpressions.Regex r3 = new System.Text.RegularExpressions.Regex(@"((\w+\s+)+)([^a-zA-Z()]+\w+)");
            //续上一个单词的解释
            System.Text.RegularExpressions.Regex r4 = new System.Text.RegularExpressions.Regex(@"^((n|adj|vt|adv|vi|prep|abbr)\.).*?(?=[（\(|\u4e00-\u9fa5])");

            System.Text.RegularExpressions.Regex rWord = new System.Text.RegularExpressions.Regex(@"[a-zA-Z]+");

            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            StringBuilder sb3 = new StringBuilder();
            StringBuilder sb4 = new StringBuilder();
            this.progressBar1.Maximum = s1.Count();
            for (int i = 0; i < s1.Count(); i++)
            {
                if (r.IsMatch(result[i]))
                {
                    var m = r.Match(result[i]);
                    sb.Append("1\t" + m.Groups[1] + "\t" + m.Groups[2] + "\t" +  m.Groups[5]);
                    if (rWord.IsMatch(m.Groups[1].ToString())&&checkBox1.Checked)
                    {
                        sb.AppendLine("\t" + GetPhonetic(m.Groups[1].ToString(), false));
                    }
                    else
                    {
                        sb.AppendLine();
                    }
                }
                else if (r2.IsMatch(result[i]))
                {
                    var m2 = r2.Match(result[i]);
                    sb.Append("2\t" + m2.Groups[1] + "\t" + m2.Groups[2] + "\t" + m2.Groups[4]);
                    if (rWord.IsMatch(m2.Groups[1].ToString()) && checkBox1.Checked)
                    {
                        sb.AppendLine("\t" + GetPhonetic(m2.Groups[1].ToString(), false));
                    }
                    else
                    {
                        sb.AppendLine();
                    }
                }
                else if (r3.IsMatch(result[i]))
                {
                    var m = r3.Match(result[i]);
                    sb.AppendLine("3\t" + m.Groups[1].ToString().TrimStart(' ') + "\t\t" + m.Groups[3]);
                }
                else if (r4.IsMatch(result[i]))
                {
                    var m =r4.Match(result[i]);
                    sb.AppendLine("4\t\t"  + m.Groups[0] + "\t" +  result[i].Replace(m.Groups[0].ToString(),"").Trim());
                }
                else
                {
                    sb.AppendLine("5\t" + result[i]);
                }

                this.progressBar1.Value = i+1;
                this.txt_result.AppendText(sb.ToString());
                sb2.Append(sb.ToString());
                sb.Clear();
                //if (i==40)
                //{
                //    break;
                //}
            }

            Save("r1", sb2.ToString());
            MessageBox.Show("Done!");
            //Save("r3", sb3.ToString());
            //Application.Exit();

        }

        private void Save(string fileName, string content)
        {
            string f = AppDomain.CurrentDomain.BaseDirectory + fileName + ".txt";
            System.IO.File.WriteAllText(f, content);
            System.Diagnostics.Process.Start(f);
        }

        private string GetPhonetic(string word,bool isUSA)
        {
            using (WebClient wc = new WebClient())
            {

                var bs = wc.DownloadData(new Uri("http://dict.youdao.com/search?le=eng&q="+word+"&keyfrom=dict.top"));

                HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();

                var s = System.Text.Encoding.UTF8.GetString(bs);

                html.LoadHtml(s);
                
                var nodes =  html.DocumentNode.SelectNodes("//div/span['class=phonetic']/span");

                //lucida sans unicode",arial,sans-serif
                if (nodes.Count >= 2)
                {
                    if (isUSA)
                    {
                        return nodes[2].InnerText;
                    }
                    else
                    {
                        return nodes[1].InnerText;
                    } 
                }
                return "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBox2.Text = GetPhonetic(this.textBox1.Text, false);
            this.textBox3.Text = GetPhonetic(this.textBox1.Text, true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
