using System;
using System.Windows.Forms;

namespace SIT323_Assignment_1
{
    public static class Program
    {
        public static Home form1;
        
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Home();
            Application.Run(form1);
        }
    }
}
