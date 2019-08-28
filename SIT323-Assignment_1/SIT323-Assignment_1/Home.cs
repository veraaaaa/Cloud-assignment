using System;
using System.IO;
using System.Windows.Forms;

namespace SIT323_Assignment_1
{
    public partial class Home : Form
    {

        public static TaskAllocation taskallocation;
        public static Configuration configuration;
        public static ErrorList error;
        bool checkCSV;
        public Home()
        {
            error = new ErrorList();
            InitializeComponent();
        }
        //open TAN fil and corressponding CSV file and valid at the same time
        private void MenuItem_File_Open_Click(object sender, EventArgs e)
        {
            //open and select file
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "TAN File(*.TAN) | *.TAN";

            try
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    taskallocation = new TaskAllocation();
                    configuration = new Configuration();

                    string path = ofd.FileName;
                    error.textBoxForm2.Text = "";
                    this.textBox_Valid.Text = "";

                    error.textBoxForm2.Text += "START PROCESSING TAN FILE: "
                        + path.Replace(Path.GetDirectoryName(path) + "\\", String.Empty) + "\r\n\r\n";
                    //Check the TAN file: valid or invalid
                    if (taskallocation.Parse(path))
                    {
                        textBox_Valid.Text += "Current TAN file is valid \r\n\r\n";
                    }
                    else
                    {
                        textBox_Valid.Text += "Current TAN file is invalid \r\n\r\n";
                        foreach (string s in taskallocation.errorlist)
                        {
                            error.textBoxForm2.Text += "\t" + s + "\r\n\r\n";
                        }
                    }
                    error.textBoxForm2.Text += "END PROCESSING TAN FILE: "
                        + path.Replace(Path.GetDirectoryName(path) + "\\", String.Empty) + "\r\n\r\n";

                    //To check whether the CSV file is missing
                    if (taskallocation.lostCSVName)
                        error.textBoxForm2.Text += "START PROCESSING CONFIGURATION FILE: file name missing\r\n\r\n";
                    else
                        error.textBoxForm2.Text += "START PROCESSING CONFIGURATION FILE: "
                            + taskallocation.GetcsvFilePath().Replace(Path.GetDirectoryName(path) + "\\", String.Empty) + "\r\n\r\n";

                    checkCSV = configuration.Parse(taskallocation.GetcsvFilePath());
                    //Check the CSV file: valid or invalid
                    if (checkCSV)
                    {
                        textBox_Valid.Text += "Current Configuration file is valid \r\n\r\n";
                    }
                    else
                    {
                        textBox_Valid.Text += "Current Configuration file is invalid \r\n\r\n";
                        foreach (string s in configuration.errorList)
                        {
                            error.textBoxForm2.Text += "\t" + s + "\r\n\r\n";
                        }
                    }
                    if (taskallocation.lostCSVName)
                        error.textBoxForm2.Text += "END PROCESSING CONFIGURATION FILE: file name missing\r\n\r\n";
                    else
                        error.textBoxForm2.Text += "END PROCESSING CONFIGURATION FILE: "
                            + taskallocation.GetcsvFilePath().Replace(Path.GetDirectoryName(path) + "\\", String.Empty) + "\r\n\r\n";

                    MenuItem_Validate_Allocations.Enabled = true;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        //check errorlist
        private void MenuItem_View_Error_Click(object sender, EventArgs e)
        {
            error.Show();
        }
        //check the allocation
        private void MenuItem_Validate_Allocations_Click(object sender, EventArgs e)
        {
                if(checkCSV)
                    configuration.CheckRunTime();
                textBox_Valid.Text += "Allocation:\r\n\r\n";
                //Output the runtime and the energy of each allocation.
                int taskID = 0;
                foreach (Allocation temp in taskallocation.allocationList)
                {
                    if (!temp.valid)//allocation wrong
                    {
                        textBox_Valid.Text += "Allocation ID = " + taskallocation.allocationID[taskID] + " is invalid " + "\r\n\r\n";
                    }
                    else if (!checkCSV)//CSV file invalid, answer invalid
                    {
                        textBox_Valid.Text += "Allocation ID = " + taskallocation.allocationID[taskID] 
                            + ", Time = Invalid Time, Energy = Invalid Energy\r\n\r\n";
                    }
                    else//output is valid even though the runtime is more than max-duration
                    {
                        textBox_Valid.Text += "Allocation ID = " + taskallocation.allocationID[taskID] + " ,Time = "
                            + Math.Round(configuration.CaluationRunTime(temp), 2) + " ,Energy = " 
                            + Math.Round(configuration.CaluationAllocationEnergy(temp), 2) + "\r\n\r\n";
                    }
                    temp.OutputAllocation(this);
                    taskID++;
                }
        }
        //exit control
        private void MenuItem_File_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
