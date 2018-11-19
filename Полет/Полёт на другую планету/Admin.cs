using System;
using System.Collections.Generic;

namespace Полёт_на_другую_планету
{
    class Admin
    {
        public string GetInfo(int number, char[] charr, List<char> charr2, string wrap) 
        {
            int k,j = 0,s=1,i=0;
            string result4 = "";
            string splitter2 = "|";
            while (j < charr.Length)
            {
                if (charr[j] == Convert.ToChar("/"))
                {
                    if (s == number)
                    {
                        k = j;
                        while (charr[k] != Convert.ToChar(splitter2))
                        {
                            charr2.Add(charr[k]);
                            k++;
                            i++;
                            wrap = string.Join("", charr2.ToArray());
                            result4 += (Convert.ToString(charr[k]));
                            s = 1000;
                        }
                    }
                    else s++;
                }
                if (s == 1000)
                {
                    break;
                }
                j++;
            }
            return result4;
        }
    }
}
