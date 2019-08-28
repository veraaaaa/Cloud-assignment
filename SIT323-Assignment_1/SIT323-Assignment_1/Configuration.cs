using System;
using System.Collections.Generic;
using System.IO;

namespace SIT323_Assignment_1
{
    public class Configuration
    {
        public List<string> errorList = new List<string>();

        private bool valid;
        public string default_logFile;
        public int LTmin;
        public int LTmax;
        public int LPmin;
        public int LPmax;
        public int LPFmin;
        public int LPFmax;
        private double duration;
        public int programtasks;
        public int programProcessors;
        private double frequency;
        private int[,] runTime;
        private string[,] processorID;
        public int[,] coefficientID;
        
        public bool Parse(string path)
        {
            StreamReader csvfile = new StreamReader(path);
            valid = true;
            // Search for file name.
            while (!csvfile.EndOfStream)
            {
                try
                {
                    String line = csvfile.ReadLine();
                    //skip  comment
                    if (line.Contains("//"))
                    {
                        int index = line.IndexOf("//");
                        line = line.Remove(index);
                        line = line.Trim();
                        if (line != "")
                        {
                            errorList.Add("Error:comments cannot be mixed with data(" + line + ").");
                            valid = false;
                        }
                    }
                    line = line.Trim();//remove leading and trailing white spaces
                    //skip blan line
                    if (line == "")
                        continue;
                    //KeyWord - DEFAULT-LOGFILE
                    if (line.StartsWith("DEFAULT-LOGFILE"))
                    {
                        if (!line.Contains(","))
                        {
                            errorList.Add("Error:comma is missing after keyword");
                            valid = false;
                        }
                        else
                        {
                            if (!line.Contains("DEFAULT-LOGFILE"))
                            {
                                errorList.Add("Error: DEFAULT-LOGFILE file is missing");
                                valid = false;
                            }
                            default_logFile = line.Split(',')[1];
                        }
                    }
                    //KeyWord - LIMITS-TASKS
                    else if (line.StartsWith("LIMITS-TASKS"))
                    {
                        if (!Int32.TryParse(line.Split(',')[1], out LTmin) || !Int32.TryParse(line.Split(',')[2], out LTmax))
                        {
                            errorList.Add("Error: LIMITS-TASKS number must be a positive intger");
                            valid = false;
                        }
                        else
                        {
                            if (LTmax < LTmin || LTmin < 1 || LTmax < 1)
                            {
                                errorList.Add("Error: LIMITS-TASKS number is out of range");
                                valid = false;
                            }
                        }
                    }
                    //KeyWord - LIMITS-PROCESSORS
                    else if (line.Contains("LIMITS-PROCESSORS"))
                    {
                        if (!Int32.TryParse(line.Split(',')[1], out LPmin) || !Int32.TryParse(line.Split(',')[2], out LPmax))
                        {
                            errorList.Add("Error:LIMITS-PROCESSORS number must be a positive intger");
                            valid = false;
                        }
                        else
                        {
                            if (LPmax < LPmin || LPmin < 1 || LPmax < 1)
                            {
                                errorList.Add("Error: LIMITS-PROCESSORS number is out of range");
                                valid = false;
                            }
                        }
                    }
                    //KeyWord - LIMITS-PROCESSOR-FREQUENCIES
                    else if (line.Contains("LIMITS-PROCESSOR-FREQUENCIES"))
                    {
                        if (!Int32.TryParse(line.Split(',')[1], out LPFmin) || !Int32.TryParse(line.Split(',')[2], out LPFmax))
                        {
                            errorList.Add("Error:LIMITS-PROCESSOR-FREQUENCIES number must be a positive intger");
                            valid = false;
                        }
                        else
                        {
                            if (LPFmax < LPFmin || LPFmax < 1)
                            {
                                errorList.Add("Error: The Max-processor frequency " + line.Split(',')[2]
                                    + " should be larger than the Min-processor frequency " + line.Split(',')[1]);
                                valid = false;
                            }
                            else if (LPFmin < 0)
                            {
                                errorList.Add("Error: Processor frequency of " + line.Split(',')[1] + " is out of range");
                                valid = false;
                            }
                        }
                    }
                    //KeyWord - PROGRAM-MAXIMUM-DURATION
                    else if (line.Contains("PROGRAM-MAXIMUM-DURATION"))
                    {
                        if (!Double.TryParse(line.Split(',')[1], out duration))
                        {
                            errorList.Add("Error:" + line.Split(',')[1] + " is a negative integer");
                            valid = false;
                        }
                    }
                    //KeyWord - PROGRAM-TASKS
                    else if (line.StartsWith("PROGRAM-TASKS"))
                    {
                        if (!Int32.TryParse(line.Split(',')[1], out programtasks))
                        {
                            errorList.Add("Error:" + line.Split(',')[1] + " is a negative integer");
                            valid = false;
                        }
                        if (!line.Contains("PROGRAM-TASKS"))
                            errorList.Add("Error:" + line.Split(',')[0] + " is not a keyword");
                    }
                    //KeyWord - PROGRAM-PROCESSORS
                    else if (line.StartsWith("PROGRAM-PROCESSORS"))
                    {
                        if (!line.Contains("PROGRAM-PROCESSORS"))
                        {
                            errorList.Add("Error:" + line.Split(',')[0] + " is not a keyword");
                            valid = false;
                        }
                        if (!Int32.TryParse(line.Split(',')[1], out programProcessors))
                        {
                            errorList.Add("Error:" + line.Split(',')[1] + " is a negative integer");
                            valid = false;
                        }
                    }
                    //KeyWord - RUNTIME-REFERENCE-FREQUENCY
                    else if (line.StartsWith("RUNTIME-REFERENCE-FREQUENCY"))
                    {
                        if (!line.Contains(","))
                        {
                            errorList.Add("Error:Comma is missing after keyword");
                            valid = false;
                        }
                        else
                        {
                            if (!Double.TryParse(line.Split(',')[1], out frequency))
                            {
                                errorList.Add("Error:" + line.Split(',')[1] + " is a negative number");
                                valid = false;
                            }
                        }
                    }
                    //KeyWord - TASK-ID,RUNTIME
                    else if (line.StartsWith("TASK-ID"))
                    {
                       if (!line.Contains("RUNTIME"))
                          {
                             errorList.Add("Error:" + line.Split(',')[1] + " is not a keyword");
                             valid = false;
                        }
                        List<string> temp = new List<string>();
                        runTime = new int[programtasks, 2];
                        for (int i = 0; i < programtasks; i++)
                        {
                            line = csvfile.ReadLine();
                            if (temp.Contains(line.Split(',')[0]))
                            {
                                errorList.Add("Error:TASK-ID=" + line.Split(',')[0] + " exits");//check duplicate taskid
                                valid = false;
                            }
                            else
                            {
                                temp.Add(line.Split(',')[0]);
                            }
                            for (int j = 0; j < 2; j++)
                            {
                                string strTemp = line.Split(',')[j];
                                runTime[i, j] = int.Parse(strTemp);
                            }
                        }
                    }
                    //KeyWord - PROCESSOR-ID,FREQUENCY
                    else if (line.Contains("PROCESSOR-ID"))
                    {
                        if (!line.Contains("FREQUENCY"))
                        {
                            errorList.Add("Error:" + line.Split(',')[1] + " is not a keyword");
                            valid = false;
                        }
                        List<string> temp = new List<string>();
                        processorID = new string[programProcessors, 2];
                        for (int i = 0; i < programProcessors; i++)
                        {
                            line = csvfile.ReadLine();
                            if (temp.Contains(line.Split(',')[0]))
                            {
                                errorList.Add("Error:PROCESSOR-ID=" + line.Split(',')[0] + "exits");
                                valid = false;
                            }
                            else
                            {
                                temp.Add(line.Split(',')[0]);
                            }
                            processorID[i, 0] = line.Split(',')[0];
                            processorID[i, 1] = line.Split(',')[1];
                        }
                    }
                    //KeyWord - COEFFICIENT-ID,VALUE
                    else if (line.Contains("COEFFICIENT-ID"))
                    {
                        if (!line.Contains("VALUE"))
                        {
                            errorList.Add("Error:" + line.Split(',')[1] + " is not a keyword");
                            valid = false;
                        }
                        List<string> temp = new List<string>();
                        coefficientID = new int[3, 2];
                        for (int i = 0; i < 4; i++)
                        {
                            line = csvfile.ReadLine();
                            string use = line.Split(',')[1];
                            if (i == 3)
                            {
                                errorList.Add("Error: only 3 coefficients are expected");
                                valid = false;
                                break;
                            }
                            else if (temp.Contains(line.Split(',')[0]))
                            {
                                errorList.Add("Error:COEFFICIENT-ID=" + line.Split(',')[0] + " already exits");
                                valid = false;
                                break;
                            }
                            else if (use != "25" && use != "-25" && use != "10")
                            {
                                errorList.Add("Error:COEFFICIENT-ID value should be 25, -25 or 10.");
                                valid = false;
                                break;
                            }
                            else
                            {
                                temp.Add(line.Split(',')[0]);
                                for (int j = 0; j < 2; j++)
                                {
                                    int l = Int32.Parse(line.Split(',')[j]);
                                    coefficientID[i, j] = l;
                                }
                            }
                        }
                    }
                    else
                    {
                        errorList.Add("Error:" + line.Split(',')[0] + " is not a keyword");
                        valid = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            csvfile.Close();
            return valid;
        }
        //check the runtime 
        public bool CheckRunTime()
        {
            bool checkAns = true;
            foreach (Allocation temp in Home.taskallocation.allocationList)
            {
                double runTime = Home.configuration.CaluationRunTime(temp);
                if (runTime > Home.configuration.ReturnDuration())
                {
                    runTime = Math.Round(runTime, 2);
                    Home.error.textBoxForm2.Text += "\tError:the runtime(" + runTime.ToString() + "s) of allocation "
                        + temp.id + " is greater than the expected maximum(8s).\r\n\r\n";
                    checkAns = false;
                }
            }
            return checkAns;
        }

        public double ReturnDuration()
        {
            return duration;
        }
        //calculate the energy per second formula
        public double CaluationEnergyPerSecond(double temp)
        {
            return (coefficientID[2, 1] * temp * temp + coefficientID[1, 1] * temp + coefficientID[0, 1]);
        }
        //calculate the task energy formula
        public double CaluationTaskEnergy(int taskID, string processID)
        {
            double energy;
            for (int i = 0; i < programtasks; i++)
            {
                for (int j = 0; j < programProcessors; j++)
                {
                    if (taskID == runTime[i, 0] && processorID[j, 0] == processID)
                    {
                        energy = CaluationEnergyPerSecond(Double.Parse(processorID[j, 1])) * CaluationTaskRunTime(j, i);// / duration;
                        return energy;
                    }
                    else
                        continue;
                }
            }
            return 0;
        }
        //calculate the allocation energy formula
        public double CaluationAllocationEnergy(Allocation temp)
        {
            double ans = 0;
            for (int i = 0; i < temp.processor; i++)
            {
                for (int j = 0; j < temp.tasknumber; j++)
                {
                    if (temp.allocation[i, j] == 1)
                    {
                        ans += CaluationTaskEnergy(runTime[j, 0], processorID[i, 0]);
                    }
                }
            }
            return ans;
        }
        //calculate the task runtime
        public double CaluationTaskRunTime(int i, int j)
        {
            double processFrequency = Double.Parse(processorID[i, 1]);
            return 2 * runTime[j, 1] / processFrequency;
        }
        //caluation the overall runtime
        public double CaluationRunTime(Allocation temp)
        {
            double max = 0;
            for (int i = 0; i < temp.processor; i++)
            {
                double time = 0;
                for (int j = 0; j < temp.tasknumber; j++)
                {
                    if (temp.allocation[i, j] == 0)
                        continue;
                    else
                    {
                        time += CaluationTaskRunTime(i, j);
                    }
                }
                if (max < time)
                {
                    max = time;
                }
            }
            return max;
        }
    }
}
