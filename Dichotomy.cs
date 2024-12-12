using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optim_func_one_var
{
    public class Dichotomy
    {
        public static double[] Optimize(Func<double, double> func,int a,int b,double Epsx,double Epsy,double Delta)
        {
            bool check = true;
            double ak = a;
            double bk = b;
            double x_appr = (ak + bk) / 2;

            while (check)
            {
                double f_now = func(x_appr);

                double x_left = x_appr - Delta / 2; 
                double x_right = x_appr + Delta / 2;

                double f_left = func(x_left);
                double f_right = func(x_right);

                if (f_left < f_right)
                {
                    bk = x_right;
                }
                if (f_left >= f_right)
                {
                    ak = x_left;
                }
                
                x_appr = (ak + bk)/2;

                double f_next = func(x_appr);

                if (((bk-ak) <= Epsx) & (Math.Abs(f_next - f_now) <= Epsy))
                {
                    check = false;
                }

                
            }

            double[] result = new double[2];
            double resy = func(x_appr);
            result[0] = resy;
            result[1] = x_appr;
            return result;
        }
    }
}
