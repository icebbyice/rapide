using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rapide
{
    class Spreader
    {
        public static string[] spreadText;

        public static int GetLength()
        {
            return spreadText.Length;
        }

        public static void SetUpSpreadText(string inputText)
        {
            //may want to reconsider because of plans (user input check)
            CleanText.MatchAndReplace(inputText);
            spreadText = inputText.Split(new string[] { " " },
                StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
