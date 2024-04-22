using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _11._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label2.Text = Convert.ToString(trackBar1.Value);
            trackBar1.Maximum = 999;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = trackBar1.Value;
            label6.Text = Convert.ToString(n*(n+1));
            int a = 0;
            for (int i = 1; i <= n; i++)
            {
                a += 2*i;
                
            }
            label5.Text = Convert.ToString(a);
        }
    }
}
