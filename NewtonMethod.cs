﻿using System;
using System.Windows.Forms;

namespace NumberMethods
{
    public partial class NewtonMethod : Form
    {
        public NewtonMethod()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string f1 = "sin(x)-y^2";
            string f2 = "tan(x)^2-y";
            //string f1 = "x^2-2*x-y+0.5";
            //string f2 = "x^2+4*y^2-4";
            NewtonEquation nq = new NewtonEquation(f1, f2);
            double x1 = Convert.ToDouble(textBox3.Text);
            double x2 = Convert.ToDouble(textBox4.Text);
            //double x1 = 0.5f;
            //double x2 = 0.022f;

            //double x1 = 2f;
            //double x2 = 0.25f;
            //float E = 0.0001f;
            float E = (float)Convert.ToDouble(textBox5.Text);
            NewtonEquation.ShowResult(x1, x2, E);
            foreach (var Text in NewtonEquation.stepText)
            {
                listBox1.Items.Add(Text);
            }

        }
    }
}
