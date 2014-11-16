using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;
using System.Data;

namespace TxtDictionary
{
    class ExcelTool
    {
        /// <summary>
        /// 保存为Excel文件
        /// </summary>
        /// <param name="fileName">文件名，参数需要写扩展名xlsx</param>
        /// <param name="list">单词表的</param>
        /// <param name="count"></param>
        public void Save(string fileName, List<Word> list, int count)
        {
            using (ExcelPackage ep = new ExcelPackage())
            {
                var st = ep.Workbook.Worksheets.Add("TTT");

                int x = 1;
                int y = 1;

                for (int i = 0; i < list.Count; i++)
                {
                    st.Cells[x, y].Value = list[i].Text;
                    foreach (var ms in list[i].Meanings)
                    {
                        st.Cells[x, ++y].Value = ms.PhoneticEN;

                        if (x!=1)
                        {
                            int k = 1;
                            while (st.Cells[x - k, y].Value.ToString() == "")
                            {
                                k++;
                            }
                            if (st.Cells[x, y].Value == st.Cells[x - k, y].Value)
                            {
                                st.Cells[x, y].Value = "";
                            } 
                        }
                        
                        foreach (var cc in ms.CixingChinese)
                        {
                            st.Cells[x, ++y].Value = cc.Cixing;
                            st.Cells[x++, ++y].Value = cc.Chinese;
                            y = 2;
                        }
                        y = 1;
                    }

                    if ((i + 1) % count == 0)
                    {
                        st.Select("A:D");
                        st.SelectedRange.AutoFitColumns();
                        st.Name = (i - count + 2) + "-" + (i + 1);
                        st = ep.Workbook.Worksheets.Add("TTT");
                        x = 1;
                        y = 1;
                    }
                }

                st.Select("A:D");
                st.SelectedRange.AutoFitColumns();
                st.Name = (list.Count / count) * count + 1 + "-" + ((list.Count / count) * count + (list.Count % count));

                ep.SaveAs(new System.IO.FileInfo(fileName));
            }
        }
        /// <summary>
        /// 读取ExcelSheet为dataTable
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="isHaveHeader">是否有标题行</param>
        /// <param name="sheetNoBase1">第几个Sheet，从1开始</param>
        /// <returns>datatable</returns>
        public DataTable Read(string path, bool isHaveHeader, int sheetNoBase1)
        {
            var dtb = new DataTable();
            using (ExcelPackage ep = new ExcelPackage(new System.IO.FileInfo(path)))
            {
                var s1 = ep.Workbook.Worksheets[sheetNoBase1];

                for (int i = 1; i <= s1.Dimension.End.Column; i++)
                {
                    //添加表头
                    if (isHaveHeader && s1.Cells[1, i].Value != null)
                    {
                        dtb.Columns.Add(s1.Cells[1, i].Value.ToString());
                    }
                    else
                    {
                        dtb.Columns.Add("");
                    }
                }
                var M = new object();
                if (isHaveHeader)
                {
                    M = s1.Cells[2, 1, s1.Dimension.End.Row, s1.Dimension.End.Column].Value;
                }
                else
                {
                    M = s1.Cells[1, 1, s1.Dimension.End.Row, s1.Dimension.End.Column].Value;
                }
                object[,] MO = (M as object[,]);


                for (int ro = 0; ro < MO.GetLength(0); ro++)
                {
                    List<object> l = new List<object>();
                    for (int co = 0; co < MO.GetLength(1); co++)
                    {
                        if (MO[ro, co] != null)
                        {
                            l.Add(MO[ro, co]);
                        }
                        else
                        {
                            l.Add("");
                        }
                    }
                    dtb.Rows.Add(l.ToArray());
                }
            }
            return dtb;
        }
        /// <summary>
        /// 读取ExcelSheet为dataTable
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="isHaveHeader">是否有标题行</param>
        /// <param name="sheetName">Sheet名称</param>
        /// <returns></returns>
        public DataTable Read(string path, bool isHaveHeader, string sheetName)
        {
            int i = 0;
            using (ExcelPackage ep = new ExcelPackage(new System.IO.FileInfo(path)))
            {
                foreach (ExcelWorksheet item in ep.Workbook.Worksheets)
                {
                    i++;
                    if (item.Name == sheetName)
                    {
                        break;
                    }
                }
            }
            return Read(path, isHaveHeader, i);
        }

        public List<Word> toWords(DataTable dt)
        {
            int c = dt.Columns.Count;
            List<Word> list = new List<Word>();
            Word currentWord = null;
            foreach (DataRow item in dt.Rows)
            {
                if (item[0].ToString() == "")
                {
                    string phontic = item[1].ToString();
                    CixingChinesePair cc = new CixingChinesePair();
                    cc.Cixing = item[2].ToString();
                    cc.Chinese = item[3].ToString();
                    List<CixingChinesePair> ccList = new List<CixingChinesePair>();
                    ccList.Add(cc);
                    Meaning mn = new Meaning(phontic, "", ccList);
                    currentWord.Meanings.Add(mn);
                }
                else
                {
                    //new word
                    string wd = item[0].ToString();
                    string phontic = item[1].ToString();
                    CixingChinesePair cc = new CixingChinesePair();
                    cc.Cixing = item[2].ToString();
                    cc.Chinese = item[3].ToString();
                    List<CixingChinesePair> ccList = new List<CixingChinesePair>();
                    ccList.Add(cc);
                    Meaning mn = new Meaning(phontic, "", ccList);
                    List<Meaning> mnList = new List<Meaning>();
                    mnList.Add(mn);
                    currentWord = new Word(wd, mnList);

                    for (int i = 1; i < currentWord.Meanings.Count; i++)
                    {
                        if (currentWord.Meanings[i].PhoneticEN == "" && currentWord.Meanings[i - 1].PhoneticEN != "")
                        {
                            currentWord.Meanings[i].PhoneticEN = currentWord.Meanings[i - 1].PhoneticEN;
                        }
                        if (currentWord.Meanings[i].PhoneticUS == "" && currentWord.Meanings[i - 1].PhoneticUS != "")
                        {
                            currentWord.Meanings[i].PhoneticUS = currentWord.Meanings[i - 1].PhoneticUS;
                        }
                    }

                    list.Add(currentWord);
                }

            }

            
            foreach (Word item in list)
            {
                if (item.Text=="level")
                {
                    Console.WriteLine();
                }
                for (int i = 1; i < item.Meanings.Count; i++)
                {
                    if (item.Meanings[i].PhoneticEN == "" && item.Meanings[i - 1].PhoneticEN != "")
                    {
                        item.Meanings[i].PhoneticEN = item.Meanings[i - 1].PhoneticEN;
                    }
                    if (item.Meanings[i].PhoneticUS == "" && item.Meanings[i - 1].PhoneticUS != "")
                    {
                        item.Meanings[i].PhoneticUS = item.Meanings[i - 1].PhoneticUS;
                    }
                }
            }

            return list;
        }

    }
}
