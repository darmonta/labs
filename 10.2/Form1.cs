using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _10._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBox1.Text;
                string b = textBox2.Text;
                string c = textBox3.Text;
                double a1 = Convert.ToDouble(a);
                double b1 = Convert.ToDouble(b);
                double c1 = Convert.ToDouble(c);
                double max = Math.Max(a1, Math.Max(b1, c1));
                label4.Text = max.ToString();
            }
            catch (Exception ex)
            {
                label4.Text = "некорректные \n данные!!1!1!!";
                
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            string a = textBox1.Text;
            string b = textBox2.Text;
            string c = textBox3.Text;
            if (!double.TryParse(a, out double a1) || (!double.TryParse(b, out double b1)) || (!double.TryParse(c, out double c1)))
            {
                label6.Text = "некорректные данные!";
            }
            else
            {
                label6.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string a = textBox1.Text;
                string b = textBox2.Text;
                string c = textBox3.Text;
                double a1 = Convert.ToDouble(a);
                double b1 = Convert.ToDouble(b);
                double c1 = Convert.ToDouble(c);
                double min = Math.Min(a1, Math.Min(b1, c1));
                label5.Text = min.ToString();
            }
            catch (Exception ex)
            {
               
                label5.Text = "некорректные \n данные!!1!1!!";
            }
        }

    }
}
