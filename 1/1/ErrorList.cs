﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1
{
    public partial class ErrorList : Form
    {
        public string Error { get; set; }
        public ErrorList(string error)
        {
            Error = error;
        }
        public ErrorList()
        {
            InitializeComponent();
        }

        private void TextDisplay_TextChanged(object sender, EventArgs e)
        {

        }
        public void AppendError(String error)
        {
            TextDisplay.Text += error + "\r\n";
        }
    }
}
