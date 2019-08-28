using System;
using System.Collections.Generic;

namespace SIT323_Assignment_1
{
    public class Allocation
    {
        public string id = "";
		//store allocation matrix value
        public int[,] allocation;
        public int tasknumber;
        public int processor;
		//defalut set the final result is valid
        public bool valid;
        //store error list
        public List<string> errorlist = new List<string>();

        public Allocation(int i, int j)
        {
            allocation = new int[i,j];
            processor = i;
            tasknumber = j;
        }
        public void SetAllocation(int i, int j, string value)
        {
            int k = int.Parse(value);
            allocation[i,j] = k;
        }
        //check wether the data set is corrrect or not
        public bool Check()
        {
            valid = true;
            int x = 0;
            for (int j = 0; j < tasknumber; j++)
            {
                int k = 0;
                for (int i = 0; i < processor; i++)
                {
                    if (allocation[i, j] == 0 || allocation[i, j] == 1)
                    {
                        if (allocation[i, j] == 1)
                        {
                            x++;
                            k++;
                        }
                    }
                    else
                    {
                        errorlist.Add("Error: The number in allocation(ID = "+ id +") must be 1 or 0");
                        valid = false;
                    }
                }
                if (k > 1)
                {
                    errorlist.Add("Error: a task(TaskID = "+ (j + 1)+") in an allocation (ID = "
                        + id +") has been allocated to 2 processors instead of 1");
                    valid = false;
                }
            }
            if (x != tasknumber)
            {
                errorlist.Add("Error: Allocation(ID = "+ id + ") has " + x.ToString() + " tasks, but " 
                    + tasknumber.ToString() + " are expected");
                valid = false;
            }
            return valid;
        }
        //return the allocation
        public void OutputAllocation(Home home)
        {
            for (int i = 0; i < processor; i++)
            {
                for (int j = 0; j < tasknumber; j++)
                {
                    if (j == tasknumber - 1)
                        home.textBox_Valid.Text += allocation[i, j] + "\r\n\r\n";
                    else
                        home.textBox_Valid.Text += allocation[i, j] + ",";
                }
            }
            home.textBox_Valid.Text += "\r\n\r\n";
        }


    }
}
