using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OfficeOpenXml;

namespace TxtDictionary
{
    class ExcelTool
    {
        public void Save(string fileName, List<Word> list, int count)
        {
            using (ExcelPackage ep = new ExcelPackage())
            {
                var st = ep.Workbook.Worksheets.Add("TTT");
                
                int x = 1;
                int y = 1;
                
                for (int i = 0; i < list.Count; i++)
                {
                    st.Cells[x, y, x, 4].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Dotted;
                    st.Cells[x, y].Value = list[i].Text;
                    foreach (var ms in list[i].Meanings)
                    {
                        st.Cells[x, ++y].Value = ms.PhoneticEN;

                        foreach (var cc in ms.CixingChinese)
                        {
                            st.Cells[x, ++y].Value = cc.Cixing;
                            st.Cells[x++, ++y].Value = cc.Chinese;
                            y = 2;
                        }
                        y = 1;
                    }

                    if ((i + 1) % count ==0)
                    {
                        st.Select("A:D");
                        st.SelectedRange.AutoFitColumns();
                        st.Name =  (i - count + 2)+ "-" + (i + 1);
                        st = ep.Workbook.Worksheets.Add("TTT");
                        x = 1;
                        y = 1;
                    }
                }

                st.Cells.AutoFitColumns();

                st.Cells.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                st.Cells.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                st.Column(4).Style.WrapText = true;

               
                st.Column(4).Width = 55;
                
                st.Name = (list.Count / count) * count + 1 + "-" + ((list.Count / count) * count + (list.Count % count));


                st.InsertRow(1, 1);
                st.Cells[1, 1, 1, 4].Merge = true;
                st.Cells[1, 1].Value = "单词表";
                st.Cells[1, 1].Style.Font.Bold = true;
                st.Cells[1, 1].Style.Font.Size = 24;


                st.Column(1).Style.Font.Name = "Arial";
                st.Column(2).Style.Font.Name = "Arial";
                st.Column(3).Style.Font.Name = "Arial";
                st.Column(4).Style.Font.Name = "微软雅黑";
                st.Cells[1, 1].Style.Font.Name = "微软雅黑";

                ep.SaveAs(new System.IO.FileInfo(fileName));
            }
        }
    }
}
