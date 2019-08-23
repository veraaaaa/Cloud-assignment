using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;

namespace _1
{
    public class TaskAllocations 
    {
        private string FileName { get; set; }
        public string ConfigFilename { get; set; }
        ErrorList error = new ErrorList();
        
        
        //errorlist
        public string Error { get; set; }
        public static bool AidValid { get; private set; }
        public static bool allocationValid { get; private set; }
        public static bool processorValid { get; private set; }
        public static bool TasksValid { get; private set; }
        public static bool CommentValid { get; private set; }
        public static bool processorDataValid { get; private set; }

        int AllocationId = 0;
        int task = 0;
        int processor = 0;
        int total = 0;
        int Matrix = 0;

        public TaskAllocations(string TanFileName)
        {
            FileName = TanFileName;
        }
        public void Parse()
        {
           
            //List<String> errorList = new List<string>();
            //Display file
            StreamReader tanfile = new StreamReader(FileName);
            while (!tanfile.EndOfStream)
            {
                String line = tanfile.ReadLine();
                line = line.Trim();//remove leading and trailing white spaces
                //skip blank line
                if (line.Length == 0)
                {
                    continue;
                }
                //skip comment line
                else if (line.Contains("//"))
                {
                    if (line.StartsWith("//"))
                    {
                        //Console.WriteLine("Comment line found");//check if the line start with"//"
                        CommentValid = true;
                    }
                    else
                    {
                        error.AppendError(line);
                        CommentValid = false;
                    }
                    continue;
                }
                //find corressponding csv file
                else if (line.StartsWith("CONFIGURATION"))
                {
                    String[] items = line.Split(new char[] { ',' });
                    String filename = items[1];
                    filename = filename.Trim();
                    filename = filename.Trim(new char[] { '"' });
                    if (!Path.IsPathRooted(filename))
                    {
                        ConfigFilename = Path.GetDirectoryName(FileName) + @"\" + filename;
                    }
                }
                //When line contain "TASKS"
                if (line.Contains("TASKS"))
                {
                    string pattern = @"^TASKS,\d+$";
                    if (Regex.IsMatch(line, pattern))
                    {
                        String[] item = line.Split(new char[] { ',' });
                        task = Convert.ToInt32(item[1]);
                        TasksValid = true;
                    }
                    else
                    {
                        error.AppendError(line);
                        TasksValid = false;
                    }
                    continue;
                }
                //When line contain "PROCESSORS"
                if (line.StartsWith("PROCESSORS"))
                {
                    string pattern = @"^PROCESSORS,\d$";
                    if (Regex.IsMatch(line, pattern))
                    {
                        String[] item = line.Split(new char[] { ',' });
                        processor = Convert.ToInt32(item[1]);
                        processorValid = true;
                    }
                    else
                    {
                        error.AppendError(line);
                        processorValid = false;
                    }
                    continue;
                }
                //When line contain "ALLOCATIONS"
                if (line.StartsWith("ALLOCATIONS"))
                {
                    string pattern = @"^ALLOCATIONS,\d$";
                    if (Regex.IsMatch(line, pattern))
                    {
                        String[] item = line.Split(new char[] { ',' });
                        total = Convert.ToInt32(item[1]);
                        if (AllocationId == total)
                        {
                            continue;
                        }
                        allocationValid = true;
                    }
                    else
                    {
                        error.AppendError(line);
                        allocationValid = false;
                    }
                    continue;
                }
                //when line contain "ALLOCATION-ID"
                if (line.StartsWith("ALLOCATION-ID"))
                {
                    string pattern = @"^ALLOCATION-ID,\d$";
                    if (Regex.IsMatch(line, pattern))
                    {
                        String[] item = line.Split(new char[] { ',' });
                        String IdAmount = item[1];
                        AllocationId++;
                        if (AllocationId == total)
                        {
                            AidValid = true;
                        }
                        else
                        {
                            error.AppendError(line);
                            AidValid = false;
                        }
                    }
                    else
                    {
                        error.AppendError(line);
                    }
                }
                ////check 0 and 1
                if (line.StartsWith("0") || line.StartsWith("1"))
                {
                    //valid processors and allocation-id data - matching
                    DataValid(line,Matrix);
                }
                Console.WriteLine(line);
            }
            tanfile.Close();
        }

        private void DataValid(string line,int Matrix)
        {
            int prs = processor;//set the default processer is equal to the given number
            for(int i = 0; i < prs; i++)
            {
                String[] item = line.Split(new char[] { ',' });
                Matrix++;
                if (Matrix == prs)
                    {
                        processorDataValid = true;
                    }
                    else
                    {
                        processorDataValid = false;
                    }
            }

        }

        //determine wether this TAN file is valid or invalid
        internal static bool IsValid()
        {
            if(CommentValid == true &&  processorValid == true && TasksValid == true && AidValid == true && allocationValid == true && processorDataValid == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //display errorList
        public void Errors(string errors)
        {
            StreamWriter errorfile = new StreamWriter(errors);
            errorfile.WriteLine(Error);
            errorfile.Close();
        }
    }
}
