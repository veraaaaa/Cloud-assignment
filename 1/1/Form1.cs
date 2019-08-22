using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class Form1 : Form
    {
        private TaskAllocations testTanFile { get; set; }

        TaskAllocations taskAllocations = null;
        Configuration configuration = null;
        ErrorList errorList = null;

        public Form1()
        {
            InitializeComponent();

            //ApplicationAboutBox = new AboutBox();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void openTANFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenTanFile();
        }

        private void OpenTanFile()
        {
            //open and select file
            OpenFileDialog ofd = new OpenFileDialog();
            //only allow user to open the tan file
            ofd.Filter = "txt Files(*.tan)|*.tan";
            ofd.ShowDialog();
            //TAN FILE
            taskAllocations = new TaskAllocations(ofd.FileName);
            taskAllocations.Parse(); //Display tanfile calling Parse class
            //CSV FILE
            configuration = new Configuration(taskAllocations.ConfigFilename);
            configuration.Parse();//Display assicoate csvfile calling Parse class
            TaskAllocations allocations = new TaskAllocations(ofd.FileName);
            if(TaskAllocations.IsValid() == true)
            {
                textBox1.AppendText("Current opining  TAN file is valid" +"\r\n");
            }
            else
            {
                textBox1.AppendText("Current opining TAN file is invalid" + "\r\n");
            }
            Configuration configurations = new Configuration(taskAllocations.ConfigFilename);
            if(Configuration.IsValid() == true)
            {
                textBox1.AppendText("Current opining CSV file is valid" + "\r\n");
            }
            else
            {
                textBox1.AppendText("Current opining CSV file is invalid" + "\r\n");
            }
        }
        //allocation
        private void allocationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            allocationsToolStripMenuItem.Enabled = false;
        }
        //errorList
        private void errorListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            errorList = new ErrorList();
            errorList.ShowDialog();
            errorList.AppendError("error..");
        }
        //exit the program
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
