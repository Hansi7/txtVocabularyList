using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TxtDictionary
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btn_Brower_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel 文件 (*.xlsx)|*.xlsx";
            ofd.Multiselect = false;
            if (ofd.ShowDialog()== System.Windows.Forms.DialogResult.OK)
            {
                this.lbl_filename.Text = ofd.FileName;
            }
            var ex = new ExcelTool();

            var dt = ex.Read(ofd.FileName, cb_IsHaveHeader.Checked, 1);
            var dic = ex.toWords(dt);
            CixingSelector cs = new CixingSelector();




            foreach (Word item in dic)
            {
                cs.KeepCixing(item, "n.");
            }
            ex.Save("aaa.xlsx", dic, 9999);
        }
    }
}
