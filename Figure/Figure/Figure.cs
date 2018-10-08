using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    public class Figure : IDisposable
    {
        private int[] param;

        public Figure(int[] param)
        {
            this.param = param;
        }
        ~Figure()
        {

        }
        public double S()
        {
            double s = 0;
            switch (param.Length)
            {
                case 1:
                    s = 2 * Math.PI * param[0];
                    break;
                case 2:
                    s = param[0] * param[1];
                    break;
                case 3:
                    if ((Math.Pow(param[0], 2) + Math.Pow(param[1], 2) == Math.Pow(param[2], 2)) || (Math.Pow(param[0], 2) + Math.Pow(param[2], 2) == Math.Pow(param[1], 2)) || (Math.Pow(param[2], 2) + Math.Pow(param[1], 2) == Math.Pow(param[0], 2)))
                    {
                        int[] i = param.OrderBy(x => x).Take(2).ToArray();
                        s = i[0] * i[1] / 2;
                    }
                    else
                    {
                        double pt = (double)(param[0] + param[1] + param[2]) / 2;
                        s = Math.Sqrt(pt * (pt - param[0]) * (pt - param[1]) * (pt - param[2]));
                    }
                    break;
                case 4:
                    double p = (param[0] + param[1] + param[2] + param[3]) / 2;
                    s = Math.Sqrt((p - param[3]) * (p - param[0]) * (p - param[1]) * (p - param[2]));
                    break;                
                default:
                    s = 0;
                    break;
            }
            return s;
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
