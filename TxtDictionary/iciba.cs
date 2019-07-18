using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace TxtDictionary
{
    public class iciba
    {
        WebClient wc = new WebClient();

        string urlBase = "http://dict-co.iciba.com/api/dictionary.php?key=EBCFD059A10094F790FD6A3F56E3CA6A&w=";
        public Word QueryWord(string wordText)
        {
            var data = wc.DownloadData(urlBase + wordText);

            var htmlStr = Encoding.UTF8.GetString(data);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            doc.LoadHtml(htmlStr);

            //var word = doc.DocumentNode.SelectNodes("dict/key")[0].InnerText;
            List<Meaning> lm = new List<Meaning>();
            string en, us;
            try
            {
                en = "["+doc.DocumentNode.SelectNodes("dict/ps")[0].InnerText + "]";

            }

            catch 
            {
                en = "";
            }
            try
            {
                us = "[" + doc.DocumentNode.SelectNodes("dict/ps")[1].InnerText + "]";

            }
            catch 
            {
                us = "";
            }

            List<CixingChinese> cixings = new List<CixingChinese>();
            CixingChinese cixing = new CixingChinese();
            int counts = 0;
            try
            {
                counts = doc.DocumentNode.SelectNodes("dict/pos").Count;
                for (int i = 0; i < counts; i++)
                {
                    cixing = new CixingChinese();
                    cixing.Cixing = doc.DocumentNode.SelectNodes("dict/pos")[i].InnerText;
                    cixing.Cixing = cixing.Cixing.Replace("&amp;", "&");
                    cixing.Chinese = doc.DocumentNode.SelectNodes("dict/acceptation")[i].InnerText;
                    cixing.Chinese = cixing.Chinese.Replace("&lt;", "<").Replace("&gt;", ">");
                    cixings.Add(cixing);
                }
            }
            catch 
            {
                return null;
                cixing.Chinese = "";
                cixing.Cixing = "";
            }
            Meaning meaning = new Meaning(en, us, cixings);
            lm.Add(meaning);
            Word wordToReturn = new Word(wordText, lm);

            return wordToReturn;
        }


    }
}
