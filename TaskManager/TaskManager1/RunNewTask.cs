using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace TaskManager1
{
    public partial class RunNewTask : Form
    {
        public RunNewTask()
        {
            InitializeComponent();
        }

        private void Run_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    Process proc = new Process();
                    proc.StartInfo.FileName = textBox1.Text;
                    proc.Start();
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
