using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eBdb.EpubReader;

namespace rapide
{
    class EpubOps
    {
        public static string ExtractTextFromEpub(string path)
        {
            Epub ePub = new Epub(path);
            return ePub.GetContentAsPlainText();
        }
    }
}
