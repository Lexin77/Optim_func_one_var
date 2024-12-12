using System;
using Optim_func_one_var;
namespace Optim_func_one_var
{
    class Program
    {
        static void Main(string[] args)
        {
            // Определяем функцию, которую хотим оптимизировать
            Func<double, double> myFunction = x => Math.Sqrt(Math.Pow(x, 2) + 9) / 4 + ((5 - x) / 5);

            int a = -3; // Начальная граница
            int b = 8; // Конечная граница
            int N = 10; // Количество узлов для равномерного метода
            double Epsx = 0.05; // Допустимая ошибка по x
            double Epsy = 0.001; // Допустимая ошибка по значению функции
            double Delta = 0.02; // минимальный интервал поиска для метода дихотомии
            
            // Вызов функции Optimize
            double[] result_uniform = Uniform.Optimize(myFunction, a, b, N, Epsx, Epsy);
            double[] result_dichotomy = Dichotomy.Optimize(myFunction,a,b,Epsx, Epsy,Delta);
            double[] result_fibonacci = Fibonacci.Optimize(myFunction, a, b, Epsx);
            double[] result_Golden_sec = Golden_sec.Optimize(myFunction,a,b,Epsx,Epsy);
            // Вывод результатов
            Console.WriteLine($"Минимальное значение функции по равномерному делению: {result_uniform[0]}");
            Console.WriteLine($"Приближенное значение x равномерному делению: {result_uniform[1]}");
            Console.WriteLine();
            Console.WriteLine($"Минимальное значение функции по делению отрезков пополам: {result_dichotomy[0]}");
            Console.WriteLine($"Приближенное значение x по делению отрезков пополам: {result_dichotomy[1]}");
            Console.WriteLine();
            Console.WriteLine($"Минимальное значение функции по методу фибоначчи: {result_fibonacci[0]}");
            Console.WriteLine($"Приближенное значение x по методу фибоначчи: {result_fibonacci[1]}");
            Console.WriteLine();
            Console.WriteLine($"Минимальное значение функции по методу фибоначчи: {result_Golden_sec[0]}");
            Console.WriteLine($"Приближенное значение x по методу фибоначчи: {result_Golden_sec[1]}");

        }
    }
}
