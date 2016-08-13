using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreAppDemo.FromMiniUI
{
    public class File
    {
        public static string Read(string path)
        {
            string text;
            using (StreamReader sr = new StreamReader(System.IO.File.OpenRead(path)))
            {
                text = sr.ReadToEnd();

                return text;
            }
        }
    }
}
