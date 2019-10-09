using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gw2ApiLibrary
{
    public class TextFileReader
    {
        public static Dictionary<int, string> ParseText(Stream file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                Dictionary<int, string> parsedFile = new Dictionary<int, string>();
                try
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parsed = Regex.Split(line, @":");
                        parsedFile.Add(Int32.Parse(parsed[0]), parsed[1]);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("The file could not be read:");
                    Console.WriteLine(e.Message);
                }

                return parsedFile;
            }
        }
    }
}
