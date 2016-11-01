using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LectionDictionary
{
    public partial class Form1 : Form
    {
       // Dictionary Dic = new Dictionary();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dictionary.Work();
            label1.Text = "Check bin/Debug/result.txt";
        }

    }
}
