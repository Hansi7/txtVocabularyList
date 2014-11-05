using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxtDictionary
{
    public class Word
    {

        public Word(string word, List<Meaning> meanings)
        {
            this.Text = word;
            this.Meanings = meanings;
        }

        public string Text { get; set; }
        private List<Meaning> Meanings;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Text);
            foreach (var m in Meanings)
            {

                    sb.Append("\t");
      

                sb.Append(m.PhoneticEN + "\t");

                for (int i = 0; i < m.CixingChinese.Count; i++)
                {
                    if ( i > 0)
                    {
                        sb.Append("\t\t");
                    }
                    sb.Append(m.CixingChinese[i].Cixing + "\t" + m.CixingChinese[i].Chinese);
                    sb.AppendLine();    
                }
            }
            return sb.ToString();
        }
    }

    public class Meaning
	{
        public Meaning(string phoneticEN, string phoneticUS, List<CixingChinese> cc)
        {
            PhoneticEN = phoneticEN;
            PhoneticUS = phoneticUS;
            CixingChinese = cc;
        }
        public List<CixingChinese> CixingChinese;
        public string PhoneticEN { get; set; }
        public string PhoneticUS { get; set; }
	}

    public class CixingChinese
    {
        public string Cixing { get; set; }
        public string Chinese { get; set; }
    }
}
