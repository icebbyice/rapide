using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace rapide
{
    class CleanText
    {
        public static string MatchAndReplace(string input)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9] ' $ { @ $ # < \" } ! * ? ! > . , %");
            //removes any weird characters
            rgx.Replace(input, "");

            MatchCollection matches = Regex.Matches(input, "' $ { @ $ # < \"");
            //check for each word if it's alone or if after the match there is a word
            foreach (Match match in matches)
            {
                if (!char.IsLetterOrDigit(input[match.Index - 1]))
                {
                    input.Remove(match.Index, 1);
                }
            }

            matches = Regex.Matches(input, "' \" } ! * ? ! > . , % ");
            foreach (Match match in matches)
            {
                if (!char.IsLetterOrDigit(input[match.Index + 1]))
                {
                    input.Remove(match.Index, 1);
                }
            }
            return input;
        }
    }
}
