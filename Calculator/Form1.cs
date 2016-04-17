using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Calculator : Form
    {
        Int16 decim;
        Double num = 0;
        Double ans = 0;
        String opr = "";
        String state = "initial";
        String mode = "INFIX";
        Boolean decimalFlag = false;
        Boolean resultFlag = false;

        public Calculator()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            calcResult.Text = ans.ToString();
        }

        private void number_Click(object sender, EventArgs e)
        {
            Button key = (Button)sender;
            resultFlag = false;
            if (calcResult.Text == "0")
                calcResult.Clear();
            if (state == "initial")
            {
                num = Double.Parse(key.Text);
                calcResult.Text = num.ToString();
                state = "number";
            }
            else if (state == "number")
            {
                num = num * 10 + Double.Parse(key.Text);
                calcResult.Text = num.ToString();
            }
            else if (state == "decimal")
            {
                if (key.Text == "0")
                {
                    calcResult.Text = calcResult.Text + "0";
                }
                else
                {
                    num = num + Double.Parse(key.Text) * Math.Pow(10, -decim);
                    calcResult.Text = num.ToString();
                }
                decim++;
            }
        }

        private void decimal_Click(object sender, EventArgs e)
        {
            if (decimalFlag == false)
            {
                state = "decimal";
                decim = 1;
                if (num == 0)
                    calcResult.Text = "0.";
                else
                    calcResult.Text = calcResult.Text + ".";
                decimalFlag = true;
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            ans = 0;
            num = 0;
            state = "initial";
            decimalFlag = false;
            opr = "";
            calcResult.Text = num.ToString();
        }

        private void operator_Click(object sender, EventArgs e)
        {
            Button key = (Button)sender;
            if (mode == "INFIX")
            {
                if (opr == "")
                {
                    ans = num;
                    if (key.Text != "=")
                    {
                        opr = key.Text;
                        num = 0;
                        decimalFlag = false;
                        calcResult.Text = num.ToString();
                        state = "initial";
                    }
                    else if (key.Text == "=")
                    {
                        opr = "";
                    }
                }
                else if (opr != "")
                {
                    if (opr == "+")
                    {
                        ans = ans + num;
                    }
                    else if (opr == "-")
                    {
                        ans = ans - num;
                    }
                    else if (opr == "*")
                    {
                        ans = ans * num;
                    }
                    else if (opr == "/")
                    {
                        ans = ans / num;
                    }

                    calcResult.Text = ans.ToString();
                    decimalFlag = false;
                    num = 0;
                    state = "initial";

                    if (key.Text != "=")
                    {
                        opr = key.Text;
                    }
                    else if (key.Text == "=")
                    {
                        //opr = "";
                        opr = key.Text;
                    }
                }
            }
            else if (mode == "RPN")
            {
                if (key.Text != "Enter")
                {
                    if (resultFlag == false)
                    {
                        if (key.Text == "+")
                        {
                            ans = ans + num;
                        }
                        else if (key.Text == "-")
                        {
                            ans = ans - num;
                        }
                        else if (key.Text == "*")
                        {
                            ans = ans * num;
                        }
                        else if (key.Text == "/")
                        {
                            ans = ans / num;
                        }
                        num = 0;
                        decimalFlag = false;
                        resultFlag = true;
                        calcResult.Text = ans.ToString();
                        state = "initial";
                    }
                }
                else if (key.Text == "Enter")
                {
                    ans = num;
                    num = 0;
                    decimalFlag = false;
                    state = "initial";
                }
            }
        }

        private void mode_Click(object sender, EventArgs e)
        {
            Button key = (Button)sender;
            mode = key.Text;

            if (mode == "INFIX")
            {
                equalsButton.Text = "=";
            }
            else if (mode == "RPN")
            {
                equalsButton.Text = "Enter";
            }

            ans = 0;
            num = 0;
            state = "initial";
            decimalFlag = false;
            resultFlag = false;
            opr = "";
            calcResult.Text = num.ToString();
        }
    }
}
