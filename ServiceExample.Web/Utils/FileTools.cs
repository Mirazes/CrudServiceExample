using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceExample.Web.Utils
{
    /// <summary>
    /// Contains utilities for file handling.
    /// </summary>
    public class FileTools
    {
        /// <summary>
        /// Helps appending new lines to text file, creates new file if path does not exists.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        public static void AppendTextToFile(string path, string text)
        {
            using (var sw = File.AppendText(path))
            {
                sw.WriteLine(text);
            }
        }
    }
}
