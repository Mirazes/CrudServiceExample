using System;
using System.IO;

namespace ServiceExample.Web.Utils
{
    /// <summary>
    /// Contains utils for message logging.
    /// </summary>
    public class LogHandler
    {
        private static readonly string LogPath = $"{Directory.GetCurrentDirectory()}\\logs\\{DateTime.Now}.txt";

        /// <summary>
        /// Helper function for logging errors to text file.
        /// This can be refactored to support logging to database or something else.
        /// Ultimately 3rd party nuget would be used. 
        /// </summary>
        /// <param name="description"></param>
        public static void LogError(string description)
        {
            FileTools.AppendTextToFile(LogPath, $"[{DateTime.Now}][ERROR]: {description}");
        }
        public static void LogInfo(string description)
        {
            FileTools.AppendTextToFile(LogPath, $"[{DateTime.Now}][INFO]: {description}");
        }
        public static void LogWarning(string description)
        {
            FileTools.AppendTextToFile(LogPath, $"[{DateTime.Now}][WARNING]: {description}");
        }

    }
}