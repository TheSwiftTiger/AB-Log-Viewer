using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace LiveLog
{
    class Program
    {
        static void Main(string[] args)
        {
            string log = "";
            while (true)
            {
                if (!File.Exists("log.txt"))
                {
                    Console.WriteLine("Log file not found!");
                    break;
                }

                using (FileStream fileStream = File.Open("log.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        var fileContents = reader.ReadToEnd();
                        if (fileContents.Length < log.Length)
                        {
                            Console.Clear();
                            Console.Write(fileContents);
                        }
                        else if (string.IsNullOrEmpty(log))
                        {
                            Console.Write(fileContents);
                        }
                        else if (fileContents.Length > log.Length)
                        {
                            Console.Write(fileContents.Replace(log, ""));
                        }

                        log = fileContents;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
