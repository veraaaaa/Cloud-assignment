using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace _1
{
    class Configuration
    {
        private string FileName { get; set; }
        public Configuration(string configFileName)
        {
            FileName = configFileName;
        }
        public Boolean Valid { get; set; } = false;
        public string Error { get; set; }
       
        public void Parse()
        {
            List<String> ErrorList = new List<string>();
            try {
                //Display file
                StreamReader csvfile = new StreamReader(FileName);
                while (!csvfile.EndOfStream)
                {
                    String line = csvfile.ReadLine();
                    line = line.Trim();//remove leading and trailing white spaces
                    if (line.Length == 0)
                    {
                        // Console.WriteLine("Blank line found");
                        continue;
                    }
                    //skip comment line
                    else if (line.Contains("//"))
                    {
                        if (line.StartsWith("//"))
                        {
                            //Console.WriteLine("Comment line found");//check if the line start with"//"
                            continue;
                        }
                        else
                        {
                            ErrorList.Add(line);
                        }
                    }
                    //check DEFAULT-LOGFILE line pattern
                    if (line.Contains("DEFAULT-LOGFILE"))
                    {
                        string pattern = @"^DEFAULT-LOGFILE,";
                        if (Regex.IsMatch(line, pattern))
                        {

                        }
                        else
                        {
                            ErrorList.Add(line);
                            Error.ToString();
                        }
                    }
                    //When line contain "TASKS"
                    if (line.Contains("LIMITS-TASKS"))
                    {
                        string pattern = @"^LIMITS-TASKS,\d+,\d+$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            String[] item = line.Split(new char[] { ',' });
                        }
                        else
                        {
                            ErrorList.Add(line);
                            Error = line.ToString();
                        }
                        continue;
                    }
                    //When line contain "PROCESSORS"
                    if (line.StartsWith("LIMITS-PROCESSORS"))
                    {
                        string pattern = @"^LIMITS-PROCESSORS,\d+,\d+$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            Console.WriteLine("format is correct");
                        }
                        else
                        {
                            ErrorList.Add(line);
                            Console.WriteLine("format is INcorrect");
                        }
                        continue;
                    }
                    //When line contain "ALLOCATIONS"
                    if (line.StartsWith("LIMITS-PROCESSOR-FREQUENCIES"))
                    {
                        string pattern = @"^LIMITS-PROCESSOR-FREQUENCIES,\d+,\d+$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            Console.WriteLine("format is correct");
                        }
                        else
                        {
                            ErrorList.Add(line);
                        }
                        continue;
                    }
                    //when line contain "ALLOCATION-ID"
                    if (line.StartsWith("PROGRAM-MAXIMUM-DURATION"))
                    {
                        string pattern = @"^PROGRAM-MAXIMUM-DURATION,\d+$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            Console.WriteLine("format is correct");
                        }
                        else
                        {
                            ErrorList.Add(line);
                        }
                    }
                    if (line.StartsWith("PROGRAM-TASKS"))
                    {
                        string pattern = @"^PROGRAM-TASKS,\d+$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            Console.WriteLine("format is correct");
                        }
                        else
                        {
                            ErrorList.Add(line);
                        }
                    }
                    if (line.StartsWith("PROGRAM-PROCESSORS"))
                    {
                        string pattern = @"^PROGRAM-PROCESSORS,\d+$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            Console.WriteLine("format is correct");
                        }
                        else
                        {
                            ErrorList.Add(line);
                        }
                    }
                    if (line.StartsWith("RUNTIME-REFERENCE-FREQUENCY"))
                    {
                        string pattern = @"^RUNTIME-REFERENCE-FREQUENCY,\d+$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            Console.WriteLine("format is correct");
                        }
                        else
                        {
                            ErrorList.Add(line);
                        }
                    }
                    if (line.StartsWith("TASK-ID"))
                    {
                        string pattern = @"^TASK-ID,RUNTIME$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            String[] item = line.Split(new char[] { ',' });

                        }
                        else
                        {
                            ErrorList.Add(line);
                        }
                    }
                    //如何检查重复的task任务，或者如何可以将他们导出来比较
                    if (line.StartsWith("1")||line.StartsWith("2")|| line.StartsWith("3")|| line.StartsWith("4")|| line.StartsWith("5")|| line.StartsWith("6")|| line.StartsWith("7") || line.StartsWith("8") || line.StartsWith("9"))
                    {
                        String[] item = line.Split(new char[] { ',' });

                    }
                    {

                    }
                    if (line.StartsWith("PROCESSOR-ID"))
                    {
                        string pattern = @"^PROCESSOR-ID,FREQUENCY$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            Console.WriteLine("format is correct");
                        }
                        else
                        {
                            ErrorList.Add(line);
                        }
                    }
                    if (line.StartsWith("COEFFICIENT-ID"))
                    {
                        string pattern = @"^COEFFICIENT-ID,VALUE$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            Console.WriteLine("format is correct");
                        }
                        else
                        {
                            ErrorList.Add(line);
                        }
                    }
                    Console.WriteLine(line);
                }
                csvfile.Close();
            }
            catch
            {
                Console.WriteLine("Wrong file");
            }
            }
    }
}
