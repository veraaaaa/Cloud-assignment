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
    class TaskAllocations 
    {
        private string FileName { get; set; }
        public string ConfigFilename { get; set; }
        ErrorList error = new ErrorList();
        //Valid documantation
        public Boolean Valid { get; set; } = false;
        //errorlist
        public string Error { get; set; }
        List<String> errorList = new List<string>();
        public TaskAllocations(string TanFileName)
        {
            FileName = TanFileName;
        }

        public void Parse()
        {
            int AllocationId = 0;
            int task = 0;
            int processor = 0;
            int total = 0;
            int Matrix = 0;
            int allocation = 0;
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
                        continue;
                    }
                    else
                    {
                        error.AppendError(line);
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
                        continue;
                    }
                    else
                    {
                        
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
                    }
                    else
                    {
                        
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
                            continue;
                        }
                        else
                        {
                           // Console.WriteLine("allocation not match ");
                        }
                    }
                    else
                    {

                    }
                }
                if (line.StartsWith("0") || line.StartsWith("1"))
                {
                    String[] item = line.Split(new char[] { ',' });
                    Matrix++;
                    if(Matrix == processor)
                    {
                        //continue;
                        for(int i = 0; i < item.Length; i++)
                        {
                            allocation++;
                            if (allocation == task)
                            {
                                continue;
                            }
                        }
                    }
                }
                Console.WriteLine(line);
            }
            tanfile.Close();
        }
        public void Errors(string errors)
        {
            StreamWriter errorfile = new StreamWriter(errors);
            errorfile.WriteLine(Error);
            errorfile.Close();
        }
    }
}
