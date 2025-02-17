﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NumberMethods
{
    public partial class NumericalIntegration : Form
    {
        public NumericalIntegration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string expression = textBox1.Text;
            int a = Convert.ToInt32(textBox2.Text.Split(',')[0]);
            int b = Convert.ToInt32(textBox2.Text.Split(',')[1]);
            Equation equation = new Equation(expression);
            double S = 0;
            int n = 20;
            int s = 4;

            double m = (b / (s - 1));
            double k = (s - 1) * m + 1;
            double h = Math.Abs(b - a) / (k - 1);
            listBox1.Items.Clear();
            Dictionary<int, (int, double, double)> values = new Dictionary<int, (int, double, double)>();

            //7+2*x^(-2/3)
            int counter = 0;
            for (int i = a; i < b; i += (int)h)
            {

                double fx = Equation.CalculateF(i);
                double f = ((3 * h) / 8) * (
                    fx
                    + 3 * Equation.CalculateF(i + 1)
                    + 3 * Equation.CalculateF(i + 2)
                    + Equation.CalculateF(i + 3));
                S += f;
                values.Add(counter, (i, fx, f));
                listBox1.Items.Add($"X: {i}, Y: {fx}, Integral: {f}");
                counter++;
            }
            listBox1.Items.Add($"S: {S}");
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            using (Graphics g = Graphics.FromImage(pictureBox1.Image))
            {
                Pen pen = new Pen(Color.Orange, 3);
                Pen pen2 = new Pen(Color.Black, 1);
                Pen pen3 = new Pen(Color.Red, 2);
                Pen pen4 = new Pen(Color.Blue, 1);
                List<PointF> pointslist = new List<PointF>();

                for (int i = a; i < b; i++)
                {
                    double y = Equation.CalculateF(i);
                    if (i != 0) { pointslist.Add(new PointF(i * 9, -(float)y * 26 + (pictureBox1.Height / 2))); }
                }
                pointslist.Reverse();
                g.DrawLines(pen, pointslist.ToArray());
                pictureBox1.Refresh();

            }
        }

    }
}
