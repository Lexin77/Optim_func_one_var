namespace Optim_func_one_var
{
    public class Uniform
    {
        public static double[] Optimize(Func<double,double> func, int a, int b, int N,double Epsx, double Epsy)
        {
            //Условие остановки
            bool check = true;
            //Присваиваивние
            double ak = a;
            double bk = b;
            double delta = (bk - ak);
            double x_appr = (ak + bk) / 2;
        
            while (check == true)
            {
                // значение функции в точке приближения на этом шаге
                double fk_now = func(x_appr);

                // Построение равномерной сетки
                double[] x = new double[N+1];
                x[0] = ak;
                for (int i = 1; i <= N - 1; i++)
                {
                    x[i] = ak + (i * delta / N);
                }
                x[N] = bk;

                // Вычисление значение функции в узлах
                double[] f = new double[N+1];
                
                f[0] = func(x[0]);
                for(int i = 1;i <= N-1; i++)
                {
                    f[i] = func(x[i]);
                }
                f[N] = func(x[N]);

                // находим минимум
                double min = f.Min();
                int minIndex = Array.IndexOf(f, min); // находит индекс значенияя min
                
                // Переприсваивание
                ak = x[minIndex - 1];
                bk = x[minIndex + 1];
                delta = (bk - ak);
                x_appr = (ak + bk) / 2;

                // Вычисляем значение функции в приближеном иксе на следующем шаге
                double fk_next = func(x_appr);

                if (((delta / 2) <= Epsx) & (fk_next - fk_now <= Epsy))
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
