using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rapide
{
    class PadText
    {
        public static string Left(string input, int width)
        {
            string finalString = "";
            for (int i = 0; i < width; i++)
            {
                finalString += " ";
            }
            finalString += input;
            return finalString;
        }

        public static string Right(string input, int width)
        {
            string finalString = input;
            for (int i = 0; i < width; i++)
            {
                finalString += " ";
            }
            return finalString;
        }
    }
}
