using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IM8_3
{
    public class EventCalcukator
    {
        public List<double> Statistics = new List<double>();
        private List<double> ProbList = new List<double>();

        private int N = 1;
        private Random R = new Random();
        //private Random random = new Random();

        public EventCalcukator(double p1, double p2, double p3, double p4, double p5, int N)
        {
            Statistics.AddRange(Enumerable.Repeat(0d, 5));
            ProbList.Add(p1);
            ProbList.Add(p2);
            ProbList.Add(p3);
            ProbList.Add(p4);
            ProbList.Add(p5);
            this.N = N;
        }

        public void ModellingStatisticsCount()
        {
            for (int i = 0; i < N; i++)
            {
                int k = GetEventHappenedK();
                Statistics[k - 1] += 1;
            }

            for (int j = 0; j < Statistics.Count(); j++)
            {
                Statistics[j] /= N;
            }
        }

        private int GetEventHappenedK()
        {
            double A = R.NextDouble();
            int k = 0;

            while (A > 0)
            {
                A -= ProbList[k];
                k++;
            }

            return k;
        }
    }
}
