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
        ErrorList error = new ErrorList();
        public Configuration(string configFileName)
        {
            FileName = configFileName;
        }
        public string Error { get; set; }
        public static bool conValid { get; private set; }
        public static bool ltValid { get; private set; }
        public static bool lpValid { get; private set; }
        public static bool lpfValid { get; private set; }
        public static bool pmdValid { get; private set; }
        public static bool ptValid { get; private set; }
        public static bool prValid { get; private set; }
        public static bool rrfValid { get; private set; }
        public static bool tiValid { get; private set; }
        public static bool piValid { get; private set; }
        public static bool ciValid { get; private set; }

        int programTask = 0;
        int TaskId = 0;
        int total = 0;
        int processorId = 0;
        int CId = 0;
        public void Parse()
        {
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
                            error.AppendError(line);
                        }
                    }
                    //check DEFAULT-LOGFILE line pattern
                    if (line.Contains("DEFAULT-LOGFILE"))
                    {
                        string pattern = @"^DEFAULT-LOGFILE,";
                        if (Regex.IsMatch(line, pattern))
                        {
                            conValid = true;
                        }
                        else
                        {
                            conValid = false;
                            error.AppendError(line);
                        }
                    }
                    //When line contain "TASKS"
                    if (line.Contains("LIMITS-TASKS"))
                    {
                        string pattern = @"^LIMITS-TASKS,\d,\d+$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            ltValid = true;
                        }
                        else
                        {
                            ltValid = false;
                            error.AppendError(line);
                        }
                        continue;
                    }
                    //When line contain "PROCESSORS"
                    if (line.StartsWith("LIMITS-PROCESSORS"))
                    {
                        string pattern = @"^LIMITS-PROCESSORS,\d,\d+$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            lpValid = true;
                        }
                        else
                        {
                            lpValid = false;
                            error.AppendError(line);
                        }
                        continue;
                    }
                    //When line contain "ALLOCATIONS"
                    if (line.StartsWith("LIMITS-PROCESSOR-FREQUENCIES"))
                    {
                        string pattern = @"^LIMITS-PROCESSOR-FREQUENCIES,\d,\d+$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            lpfValid = true;
                        }
                        else
                        {
                            lpfValid = false;
                            error.AppendError(line);
                        }
                        continue;
                    }
                    //when line contain "ALLOCATION-ID"
                    if (line.StartsWith("PROGRAM-MAXIMUM-DURATION"))
                    {
                        string pattern = @"^PROGRAM-MAXIMUM-DURATION,\d$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            pmdValid = true;
                        }
                        else
                        {
                            pmdValid = false;
                            error.AppendError(line);
                        }
                    }
                    if (line.StartsWith("PROGRAM-TASKS"))
                    {
                        string pattern = @"^PROGRAM-TASKS,\d$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            String[] item = line.Split(new char[] { ',' });
                            total = Convert.ToInt32(item[1]);
                            if (programTask == total)
                            {
                                continue;
                            }
                            ptValid = true;
                        }
                        else
                        {
                            ptValid = false;
                            error.AppendError(line);
                        }
                        continue;
                    }
                    if (line.StartsWith("PROGRAM-PROCESSORS"))
                    {
                        string pattern = @"^PROGRAM-PROCESSORS,\d$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            String[] item = line.Split(new char[] { ',' });
                            total = Convert.ToInt32(item[1]);
                           if(processorId == total)
                            {
                                continue;
                            }
                            prValid = true;
                        }
                        else
                        {
                            prValid = false;
                            error.AppendError(line);
                        }
                    }
                    if (line.StartsWith("RUNTIME-REFERENCE-FREQUENCY"))
                    {
                        string pattern = @"^RUNTIME-REFERENCE-FREQUENCY,\d$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            rrfValid = true;
                        }
                        else
                        {
                            rrfValid = false;
                            error.AppendError(line);
                        }
                    }
                    if (line.StartsWith("TASK-ID"))
                    {
                        string pattern = @"^TASK-ID,RUNTIME$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            IsDatValid(line);
                            //determine taskid matches limits-tasks
                            //String[] item = line.Split(new char[] { ',' });
                            //String taskId = item[1];
                            //TaskId++;
                            //if (TaskId == programTask)
                            //{
                            //    tiValid = true;
                            //}
                            //else
                            //{
                            //    error.AppendError(line);
                            //    tiValid = false;
                            //}
                        }
                        else
                        {
                            tiValid = false;
                            error.AppendError(line);
                        }
                    }

                    //piValid
                    if (line.StartsWith("PROCESSOR-ID"))
                    {
                        string pattern = @"^PROCESSOR-ID,FREQUENCY$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            //String[] item = line.Split(new char[] { ',' });
                            //String IdAmount = item[1];
                            //processorId++;
                            //if(processorId == total)
                            //{
                            //    piValid = true;
                            //}
                            //else
                            //{
                            //    piValid = false;
                            //    error.AppendError(line);
                            //}                       
                        }
                        else
                        {
                            piValid = false;
                            error.AppendError(line);
                        }
                    }
                    //ciValid
                    if (line.StartsWith("COEFFICIENT-ID"))
                    {
                        string pattern = @"^COEFFICIENT-ID,VALUE$";
                        if (Regex.IsMatch(line, pattern))
                        {
                            String[] item = line.Split(new char[] { ',' });
                            String Cid = item[0];
                            CId++;
                            if (CId == 3)
                            {
                                ciValid = true;
                            }
                            else
                            {
                                ciValid = false;
                                error.AppendError(line);
                            }

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

        private void IsDatValid(string line)
        {
            if(line.StartsWith("0")|| line.StartsWith("1") || line.StartsWith("2") || line.StartsWith("3") || line.StartsWith("4") || line.StartsWith("5") || line.StartsWith("6") || line.StartsWith("7") || line.StartsWith("8") || line.StartsWith("9"))
            {
                string[] item = line.Split(new char[] { ',' });

            }
        }

        //determine wether this CSVfile is valid or invalid
        internal static bool IsValid()
        {
            if (conValid == true && ltValid == true && lpValid == true && lpfValid == true && pmdValid == true && ptValid == true && prValid == true && rrfValid == true && tiValid == true && piValid == true && ciValid == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
