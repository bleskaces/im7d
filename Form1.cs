using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IM8_3
{
    public partial class Form1 : Form
    {
        public EventCalcukator calculator;
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonGetAnswerOrb_Click(object sender, EventArgs e)
        {
            labelError.Text = "";
            labelProb5.Text = "(auto)";

            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            ReadAndCheckAndCalculateData();
            PlotResults();
        }

        private void ReadAndCheckAndCalculateData()
        {
            var N = (int)numericUpDownNumExp.Value;
            double p_sum = 0.0;

            var prob_1 = (double)numericUpDown1.Value;
            var prob_2 = (double)numericUpDown2.Value;
            var prob_3 = (double)numericUpDown3.Value;
            var prob_4 = (double)numericUpDown4.Value;

            p_sum = prob_1 + prob_2 + prob_3 + prob_4;

            if (p_sum > 1)
            {
                labelError.Text = "Sum of 1-4 probabilitis > 1";              
            }
            else
            {
                /*if (p_sum > 0)
                {
                    prob_1 /= p_sum;
                    prob_2 /= p_sum;
                    prob_3 /= p_sum;
                    prob_4 /= p_sum;
                }*/

                var prob_5 = 1 - p_sum;
                calculator = new EventCalcukator(prob_1, prob_2, prob_3, prob_4, prob_5, N);

                labelProb5.Text = prob_5.ToString();
                calculator.ModellingStatisticsCount();
            }
        }

        void PlotResults()
        {
            for (int j = 0; j < calculator.Statistics.Count(); j++)
            {
                chart1.Series[0].Points.AddXY(j + 1, calculator.Statistics[j]);
            }

        }
    }
}
