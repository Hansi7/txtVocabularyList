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

                st.Select("A:D");
                st.SelectedRange.AutoFitColumns();
                st.Name = (list.Count / count) * count + 1 + "-" + ((list.Count / count) * count + (list.Count % count));

                ep.SaveAs(new System.IO.FileInfo(fileName));
            }
        }
    }
}
