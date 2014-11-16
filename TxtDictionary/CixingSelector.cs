using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TxtDictionary
{
    class CixingSelector
    {
        public void KeepCixing(Word w, string cixingString)
        {
            List<CixingChinesePair> toRemoveCixingPair = new List<CixingChinesePair>();
            List<Meaning> toRemoveMeaning = new List<Meaning>();
            if (w.Text=="level")
            {
                Console.WriteLine(w);
            }
            Word wClone = w.Clone() as Word;

            foreach (Meaning m in w.Meanings)
            {
                foreach (CixingChinesePair item in m.CixingChinese)
                {
                    if (item.Cixing.ToString().Trim() != cixingString.Trim())
                    {
                        m.CixingChinese.Remove(item);
                        if (m.CixingChinese.Count==0)
                        {
                            toRemoveMeaning.Add(m);
                            break;
                        }
                    }
                }
            }
            foreach (Meaning ming in toRemoveMeaning)
            {
                w.Meanings.Remove(ming);
            }

        }
    }
}
