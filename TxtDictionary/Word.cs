using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace TxtDictionary
{
    [Serializable]
    public class Word:ICloneable
    {
        
        public Word(string word, List<Meaning> meanings)
        {
            this.Text = word;
            this.Meanings = meanings;
        }

        public string Text { get; set; }
        public List<Meaning> Meanings;
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

        public object Clone()
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms,this);

            ms.Position = 0;
            return bf.Deserialize(ms);

            //var mnList = new List<Meaning>();

            //for (int i = 0; i < Meanings.Count; i++)
            //{
            //    var ccList = new List<CixingChinesePair>();

            //    for (int j = 0; j < Meanings[i].CixingChinese.Count; j++)
            //    {

            //    }

            //    Meaning m = new Meaning(Meanings[i].PhoneticEN,Meanings[i].PhoneticUS, new List<CixingChinesePair>());
            //}



            //Meaning mn = new Meaning()


            
           

            //Word w = new Word(this.Text, mnList);



        }
    }
    [Serializable]
    public class Meaning
	{
        public Meaning(string phoneticEN, string phoneticUS, List<CixingChinesePair> cc)
        {
            PhoneticEN = phoneticEN;
            PhoneticUS = phoneticUS;
            CixingChinese = cc;
        }
        public List<CixingChinesePair> CixingChinese;
        public string PhoneticEN { get; set; }
        public string PhoneticUS { get; set; }
	}
    [Serializable]
    public class CixingChinesePair
    {
        public string Cixing { get; set; }
        public string Chinese { get; set; }
    }
}
