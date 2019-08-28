using System;
using System.Windows.Forms;

namespace SIT323_Assignment_1
{
    public partial class ErrorList : Form
    {
        public ErrorList()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
