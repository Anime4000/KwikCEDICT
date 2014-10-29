using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace KwikCEDICT.Framework
{
    public class Cedict
    {
        private static string Dict = Path.Combine(".", "cedict_ts.u8");

        public static string GetDict(string input)
        {
            string ReturnThis = "Not Found :(";
            foreach (var item in File.ReadAllLines(Dict))
            {
                string OldChinese = "";
                string NewChinese = "";
                string Pinyin = "";
                string English = "";

                bool IsPinyin = false;
                bool IsEnglish = false;
                bool IsOld = false;
                bool IsFound = false;
                int SpaceCNT = 0;

                char[] line = item.ToCharArray();

                if (line[0] == '#')
                    continue;

                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] == ' ' && SpaceCNT < 2)
                            SpaceCNT++;

                    if (SpaceCNT == 0)
                        OldChinese += String.Format("{0}", line[i]);

                    if (SpaceCNT == 1)
                        if (line[i] == ' ')
                            continue;
                        else
                            NewChinese += String.Format("{0}", line[i]);

                    if (line[i] == '[' && String.IsNullOrEmpty(Pinyin))
                    {
                        IsPinyin = true;
                        continue;
                    }
                    else if (line[i] == ']' && IsPinyin)
                    {
                        IsPinyin = false;
                        IsEnglish = true;
                        i++;
                        continue;
                    }

                    if (IsPinyin)
                        Pinyin += String.Format("{0}", line[i]);
                    
                    if (IsEnglish)
                        English += String.Format("{0}", line[i]);
                }

                if (String.Equals(input, OldChinese, StringComparison.CurrentCultureIgnoreCase))
                {
                    IsOld = true;
                    IsFound = true;
                }

                if (String.Equals(input, NewChinese, StringComparison.CurrentCultureIgnoreCase))
                {
                    IsOld = false;
                    IsFound = true;
                }

                if (IsFound)
                {
                    English = English.Substring(1, English.Length - 1); // Remove first char '/'
                    English = English.Remove(English.Length - 1); // Remove last char '/'
                    ReturnThis = String.Format("Simplified: {0}\nTraditional: {1}\nPinyin: {2}\nEnglish: {3}", NewChinese, OldChinese, Pinyin, English);
                    break;
                }
            }
            return ReturnThis;
        }
    }
}

