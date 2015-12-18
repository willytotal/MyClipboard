using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNewClipboard
{
    internal class SaveItem
    {        
        public string Text { get; set; }

        public SaveItem(string str)
        {
            Text = str;
        }

        public override string ToString()
        {
            string strRet = Text.TrimStart(new char[] { ' ', '\r', '\n' });
            strRet = strRet.Replace("\r\n", " .. ");

            return strRet;
        }
    }
}
