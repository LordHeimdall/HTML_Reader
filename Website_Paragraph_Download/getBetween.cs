using System;
using System.Collections.Generic;
using System.Text;
//Pseudocode found somewhere in StackOverflow
//Edited by LordHeimdall
namespace HTML_Reader
{
    class getBetween
    {
        public string GetBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "Not Found";
            }
        }
    }
}
