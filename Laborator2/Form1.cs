using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laborator2
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("5");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("6");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("4");

        }

        private void button0_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("0");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("1");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("7");

        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("9");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("8");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("2");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("3");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(textBox1.Text.StartsWith("0") && textBox1.Text.Length > 1)
            {
                textBox1.Text = textBox1.Text.Substring(1);
            }
            if(textBox1.TextLength > 2 && textBox1.Text.StartsWith("-") && 
                textBox1.Text.Substring(1, 1) == "0")
            {
                textBox1.Text = textBox1.Text.Substring(0, 1) + textBox1.Text.Substring(2);
            }
        }

        private void buttonplus_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength > 0)
            {
                if(Int32.Parse(textBox1.Text) < 0)
                {
                    textBox3.AppendText("(");
                    textBox2.AppendText(textBox1.Text);
                    textBox3.AppendText(textBox1.Text);
                    textBox3.AppendText(")");
                }
                else
                {
                    textBox2.AppendText(textBox1.Text);
                    textBox3.AppendText(textBox1.Text);
                }                  
                textBox2.AppendText("+");
                textBox3.AppendText("+");
                textBox1.Clear();
            }
            
        }

        private void buttonegal_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(textBox1.Text) < 0)
            {
                textBox3.AppendText("(");
                textBox2.AppendText(textBox1.Text);
                textBox3.AppendText(textBox1.Text);
                textBox3.AppendText(")");
            }
            else
            {
                textBox2.AppendText(textBox1.Text);
                textBox3.AppendText(textBox1.Text);
            }
            string expr = textBox2.Text;
            textBox2.AppendText("=");
            textBox3.AppendText("=");
            textBox1.Clear();
            if (expr.Contains("+"))
            {
                int a = Int32.Parse(expr.Substring(0, expr.IndexOf("+")));
                int b = Int32.Parse(expr.Substring(expr.IndexOf("+") + 1));
                int suma = a + b;
                textBox1.AppendText(suma.ToString());
            }
            if (expr.Contains("*"))
            {
                int a = Int32.Parse(expr.Substring(0, expr.IndexOf("*")));
                int b = Int32.Parse(expr.Substring(expr.IndexOf("*") + 1));
                int produs = a * b;
                textBox1.AppendText(produs.ToString());
            }
            if (expr.Contains("/"))
            {
                int a = Int32.Parse(expr.Substring(0, expr.IndexOf("/")));
                int b = Int32.Parse(expr.Substring(expr.IndexOf("/") + 1));
                int catul = a / b;
                textBox1.AppendText(catul.ToString());
            }
            if (expr.Contains("-") && !(expr.Contains("+-")
                || expr.Contains("*-") || expr.Contains("/-")))
            {
                if (!expr.Contains("--"))
                {
                    int a = Int32.Parse(expr.Substring(0, expr.LastIndexOf("-")));
                    int b = Int32.Parse(expr.Substring(expr.LastIndexOf("-") + 1));
                    int diferenta = a - b;
                    textBox1.AppendText(diferenta.ToString());

                }
                else
                {
                    int a = Int32.Parse(expr.Substring(0, expr.IndexOf("--")));
                    int b = Int32.Parse(expr.Substring(expr.IndexOf("--") + 1));
                    int diferenta = a - b;
                    textBox1.AppendText(diferenta.ToString());
                }
            }
        }

        private void buttonminus_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0 && !(textBox2.Text.EndsWith("+") || textBox2.Text.EndsWith("-")
                || textBox2.Text.EndsWith("*") || textBox2.Text.EndsWith("/")))
            {
                if (Int32.Parse(textBox1.Text) < 0)
                {
                    textBox3.AppendText("(");
                    textBox3.AppendText(textBox1.Text);
                    textBox2.AppendText(textBox1.Text);
                    textBox3.AppendText(")");
                }
                else
                {
                    textBox2.AppendText(textBox1.Text);
                    textBox3.AppendText(textBox1.Text);
                }
                    
                textBox2.AppendText("-");
                textBox3.AppendText("-");
                textBox1.Clear();
            }
            else
                textBox1.AppendText("-");
        }

        private void buttondiv_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength > 0)
            {
                if (Int32.Parse(textBox1.Text) < 0)
                {
                    textBox3.AppendText("(");
                    textBox3.AppendText(textBox1.Text);
                    textBox2.AppendText(textBox1.Text);
                    textBox3.AppendText(")");
                }
                else
                {
                    textBox2.AppendText(textBox1.Text);
                    textBox3.AppendText(textBox1.Text);
                }
                textBox2.AppendText("/");
                textBox3.AppendText("/");
                textBox1.Clear();
            }
        }

        private void buttonasterisc_Click(object sender, EventArgs e)
        {
            if(textBox1.TextLength > 0)
            {
                if (Int32.Parse(textBox1.Text) < 0)
                {
                    textBox3.AppendText("(");
                    textBox3.AppendText(textBox1.Text);
                    textBox2.AppendText(textBox1.Text);
                    textBox3.AppendText(")");
                }
                else
                {
                    textBox2.AppendText(textBox1.Text);
                    textBox3.AppendText(textBox1.Text);
                }
                textBox2.AppendText("*");
                textBox3.AppendText("*");
                textBox1.Clear();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
