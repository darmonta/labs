using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _10._1
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
                if (double.TryParse(a, out double c) && double.TryParse(b, out double d) && c>0 && d>0)
                {
                    double ab = (c / 1000) * d;
                    label5.Text = ab.ToString() + "кг";
                }
                else
                {
                    MessageBox.Show("Введите корректные данные", "ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
            }
            catch (Exception ex)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                label5.Text = "некорректные \n данные!!1!1!!";
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            string b = textBox2.Text;
            if (!(double.TryParse(b, out double b_1)))
            {
                label6.Text = "некорректные данные!";
            }
            else
            {
                label6.Text = "";
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            string a = textBox1.Text;
            if (!(double.TryParse(a, out double a_1)))
            {
                label7.Text = "некорректные данные!";
            }
            else
            {
                label7.Text = "";
            }
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            label5.Text = "";
            string b = textBox2.Text;
            if (!(double.TryParse(b, out double b_1)))
            {
                label6.Text = "некорректные данные!";
            }
            else
            {
                label6.Text = "";
            }
            string a = textBox1.Text;
            if (!(double.TryParse(a, out double a_1)))
            {
                label7.Text = "некорректные данные!";
            }
            else
            {
                label7.Text = "";
            }
        }
    }
}
