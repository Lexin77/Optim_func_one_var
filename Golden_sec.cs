using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optim_func_one_var
{
    public class Golden_sec
    {
        public static double[] Optimize(Func<double, double> func, int a, int b,double Epsx,double Epsy)
        {
            bool check = true;
            // Начальные границы интервала
            double ak = a;
            double bk = b;
            // Начальное приближение (середина интервала)
            double x_appr = (ak + bk) / 2;

            // Золотое сечение (приблизительно 1.618)
            const double gamma = 1.618;

            while (check)
            {
                // Вычисляем длину текущего интервала
                double delta = bk - ak;

                // Значение функции в текущем приближении
                double y_now = func(x_appr);

                // Вычисляем новые точки для сравнения
                double x_left = bk - delta / Math.Pow(gamma,2);
                double x_right = ak + delta / gamma;

                // Значения функции в новых точках
                double y_left = func(x_left);
                double y_right = func(x_right);

                // Сравниваем значения функции и обновляем границы интервала
                if (y_left < y_right)
                {
                    bk = x_right;
                }
                if (y_left >= y_right)
                {
                    ak = x_left;
                }

                // Обновляем текущее приближение
                x_appr = (ak + bk) / 2;
                double y_next = func(x_appr);
                // Проверяем условия остановки: длина интервала и изменение значения функции
                if (bk-ak <= Epsx & Math.Abs(y_next - y_now) <= Epsy)
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
