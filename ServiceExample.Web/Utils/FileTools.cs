using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceExample.Web.Utils
{
    public class FileTools
    {
        public static void AppendTextToFile(string path, string text)
        {
            using (var sw = File.AppendText(path))
            {
                sw.WriteLine(text);
            }
        }

    }
}
