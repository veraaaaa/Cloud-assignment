using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace SIT323_Assignment_1
{
    public class TaskAllocation
    {
        public List<Allocation> allocationList = new List<Allocation>();
        public List<string> allocationID = new List<string>();
        public List<string> errorlist = new List<string>();
        
        private bool valid;
        public int processorNumber = 0;
        public int taskNumber = 0;
        public int allocationNumber = 0;
        private string csvPath = "";
        public bool lostCSVName = false;

        //get the csv document path
        public string GetcsvFilePath()
        {
            return csvPath;
        }
        public bool Parse(string filename)
        {
            StreamReader tanfile = new StreamReader(filename);
            valid = true;
            //read every line in the TAN file
            while (!tanfile.EndOfStream)
            {
                try
                {
                    String line = tanfile.ReadLine();
                    //skip comment line
                    if (Regex.IsMatch(line, "//"))
                    {
                        int index = line.IndexOf("//");
                        line = line.Remove(index);
                        line = line.Trim();
                        if (line != "")
                        {
                            errorlist.Add(line + " Error:comments cannot be in the same line with the data");
                            valid = false;
                        }
                    }
                    line = line.Trim();//remove leading and trailing white space
                    //skip blank line
                    if (line == "")
                        continue;
                    //Keyword - CONFIGURATION
                    if (line.Contains("CONFIGURATION") || line.Contains("\""))
                    {
                        if (line.Split(',')[1].Contains(":\\"))
                        {
                            csvPath = Path.GetDirectoryName(filename) + @"\Test3.csv";
                            lostCSVName = true;
                        }
                        else
                        {
                            csvPath = line.Split(new Char[] { ',', '"' }, StringSplitOptions.RemoveEmptyEntries)[1];
                            string directory = Path.GetDirectoryName(filename) + "\\";
                            csvPath = directory + csvPath;
                        }
                        if (!line.Contains("CONFIGURATION"))
                        {
                            errorlist.Add("Error: " + line.Split(',')[0] + " Should be CONFIGURATION");
                            valid = false;
                        }
                    }
                    //Keyword - TASKS
                    else if (line.Contains("TASKS"))
                    {
                        if (!Int32.TryParse(line.Split(',')[1], out taskNumber))
                        {
                            errorlist.Add("Error: Tasks number should be a positive number");
                            valid = false;
                        }
                    }
                    //Keyword - PROCESSORS
                    else if (line.Contains("PROCESSORS"))
                    {
                        if (!Int32.TryParse(line.Split(',')[1], out processorNumber))
                        {
                            valid = false;
                            errorlist.Add("Error:The PROCESSORS number should be a positive number");
                        }
                    }
                    //Keyword - ALLOCATIONS
                    else if (line.Contains("ALLOCATIONS"))
                    {
                        if (!Int32.TryParse(line.Split(',')[1], out allocationNumber))
                        {
                            errorlist.Add("Error:The ALLOCATIONS number should be a positive number");
                            valid = false;
                        }
                    }
                    //KeyWord - ALLOCATION-ID
                    else if (line.Contains("ALLOCATION-ID"))
                    {
                        if (allocationID.Contains(line.Split(',')[1]))
                        {
                            errorlist.Add("Error: The ALLOCATION-ID must be unique");
                            valid = false;
                        }
                        else
                        {
                            allocationID.Add(line.Split(',')[1]);//seperate the allocation id out
                        }
                        allocationNumber++;
                        Allocation allocation = new Allocation(processorNumber, taskNumber)//initilize the allocation position box
                        {
                            id = line.Split(',')[1]
                        };
                        for (int i = 0; i < processorNumber; i++)
                        {
                            line = tanfile.ReadLine();
                            for (int j = 0; j < taskNumber; j++)
                            {
                                string str = line.Split(',')[j];//each individual element with in the allocationID matrix;
                                allocation.SetAllocation(i, j, str);//store their position based on(row,coloum and actual content
                            }
                        }
                        if (!allocation.Check())//check all the errorlist within to determine the data within the allocationid is valid or not
                        {
                            foreach (string s in allocation.errorlist)
                            {
                                errorlist.Add(s);
                            }
                            valid = false;
                        }
                        allocationList.Add(allocation);
                    }
                    else
                    {
                        valid = false;
                        errorlist.Add("Error:" + line.Split(',')[0] + " is incorrect");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            tanfile.Close();
            return valid;
        }
    }
}
