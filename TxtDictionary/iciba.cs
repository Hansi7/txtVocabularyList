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

        string urlBase = "http://wap.iciba.com/cword/";
        public Word QueryWord(string wordText)
        {
            var data = wc.DownloadData(urlBase + wordText);

            var htmlStr = Encoding.UTF8.GetString(data);

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();

            doc.LoadHtml(htmlStr);

            var nodes = doc.DocumentNode.SelectNodes("//div[@class='h2']");
            Word wordToReturn = null;
            if (nodes!=null && nodes.Count >= 2)
            {
                List<Meaning> lm = new List<Meaning>();
                for (int i = 2; i <= nodes.Count; i++)
                {

                    //只有一个意思的时候 i =2;
                    Console.WriteLine(i.ToString());
                    string phoneticEN,phoneticUS;
                    if (i == 2)
                    {
                        try
                        {
                            phoneticEN = nodes[i - 1].ChildNodes[3].ChildNodes["span"].InnerText;
                        }
                        catch 
                        {
                            phoneticEN = "";
                            
                        }

                        try
                        {
                            phoneticUS = nodes[i - 1].ChildNodes[4].ChildNodes["span"].InnerText;
                        }
                        catch
                        {
                            phoneticUS = "";
                        }
                        
                    }
                    else
                    {
                        try
                        {
                            phoneticEN = nodes[i - 1].ChildNodes[1].ChildNodes["span"].InnerText;
                        }
                        catch
                        {
                            phoneticEN = "";
                        }
                        try
                        {
                            phoneticUS = nodes[i - 1].ChildNodes[2].ChildNodes["span"].InnerText;
                        }
                        catch
                        {
                            phoneticUS = "";
                        }
                        
                    }

                    var ns = doc.DocumentNode.SelectNodes("//div[@class='y']");

                    string sub1 = ns[i - 2].InnerHtml;
                    HtmlAgilityPack.HtmlDocument docSub = new HtmlAgilityPack.HtmlDocument();
                    docSub.LoadHtml(sub1);
                    var nodesSub = docSub.DocumentNode.SelectNodes("dl");

                    List<CixingChinese> lcc = new List<CixingChinese>();
                    foreach (HtmlAgilityPack.HtmlNode item in nodesSub)
                    {
                        string cixing = item.ChildNodes["dt"].InnerText;
                        string yisi = item.ChildNodes["dd"].InnerText;

                        CixingChinese cc = new CixingChinese()
                        {
                            Chinese = yisi,
                            Cixing = cixing
                        };
                        lcc.Add(cc);
                    }
                    Meaning m = new Meaning(phoneticEN, phoneticUS, lcc);
                    lm.Add(m);
                }

                wordToReturn = new Word(wordText, lm);
            }
            return wordToReturn;
        }


    }
}
