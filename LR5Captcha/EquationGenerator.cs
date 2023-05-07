using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR5Captcha
{
    internal static class EquationGenerator
    {
        private enum Operation
        {
            Multiplication,
            Addition,
            Subtraction,
            Division
        }


        private static Random random = new Random();
        private static List<double> GenerateNumSet(int K)
        {
            List<double> nums = new List<double>();
            int randint;
            double randouble;

            for (int i = 0; i < K; i++)
            {
                randint = random.Next(0, 100);
                randouble = 0;

                if (random.Next(0, 2) == 0)
                {
                    randouble = Math.Round(random.NextDouble(), 2);
                }

                nums.Add(randint + randouble);
            }
            return nums;
        }


        public static string Generate(int K)
        {
            StringBuilder sb = new StringBuilder();
            Operation randoper;
            foreach (double d in GenerateNumSet(K))
            {
                sb.Append(d);
                randoper = (Operation)random.Next(Operation.GetValues(typeof(Operation)).Length);
                switch (randoper)
                {
                    case Operation.Multiplication:
                        sb.Append(" * ");
                        break;
                    case Operation.Addition:
                        sb.Append(" + ");
                        break;
                    case Operation.Subtraction:
                        sb.Append(" - ");
                        break;
                    case Operation.Division:
                        sb.Append(" / ");
                        break;
                }
            }
            return sb.ToString().Trim().Remove(sb.Length - 2);
        }

        public static string Evaluate(string equation)
        {
            DataTable dt = new DataTable();

            equation = equation.Replace(",", ".");

            double res = Convert.ToDouble(dt.Compute(equation, ""));
            return res.ToString("0.00");
        }
    }
}
