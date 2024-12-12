using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Optim_func_one_var
{
    public class Fibonacci
    {
        private static int F_func(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return F_func(n - 1) + F_func(n - 2);
            }
        }
        public static double[] Optimize(Func<double,double> func,int a, int b, double Epsx)
        {

            // Определим порядок числа Фибоначчи N
            int n = 0; 
            while (F_func(n+2) < (b-a)/(2*Epsx)) {
                n++;
            }
            // Присваивание
            int k;
            double ak = a;
            double bk = b;
            double delta = bk - ak;

            double x_left = 0;
            double x_right = 0;
            double y_left = 0;
            double y_right = 0;

            // Основной цикл для нахождения минимума функции
            for (k = 0; k <= n-2; k++)
            {
                // Вычисляем новые точки для сравнения
                x_left = bk - delta * F_func(n - 1 - k) / F_func(n - k);
                x_right = ak + delta * F_func(n - 1 - k)/ F_func(n - k);

                // Вычисляем значения функции в новых точках
                y_left = func(x_left);
                y_right = func(x_right);

                // Сравниваем значения функции и обновляем границы интервала
                if (y_left < y_right)
                {
                    bk = x_right;
                }
                if (y_left >= y_right)
                {
                    ak = x_left;
                }
                // обновляем delta
                delta = bk - ak;
            }
            // Второй этап
            x_right += Epsx;
            y_right = func(x_right);
            if (y_left < y_right) {
                bk = x_left;
            }
            if (y_left > y_right)
            {
                ak = x_left;
            }
            double[] result = new double[2];
            //Ответ  Находим среднее значение между границами как приближенную точку минимума
            double x_appr = (ak + bk) / 2;
            double resy = func(x_appr);
            result[0] = resy;
            result[1] = x_appr;
            return result;
            
        }
    }
}
