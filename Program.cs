using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMasService
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите лямбду:");
            double lamda = Convert.ToDouble(Console.ReadLine()) / 60;
            Console.WriteLine("Время обслуживания:");
            double timeService = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Количество каналов:");
            double chanel = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("----------------------------------------");

            double alpha = lamda / (1 / timeService);
            Console.WriteLine($"Интенсивность обслуживания - {alpha}");
            Console.WriteLine($"Интенсивность потока заявок каждого потенциального требования - {lamda}");

            double p0 = 0;
            double p = 0;
            for (int k = 0; k <= chanel; k++)
            {
                p +=  (Math.Pow(alpha, k) / Factorial(k));
            }
            p0 = 1 / p;
            Console.WriteLine($"Вероятность простоя каналов обслуживания -  {p0}"); //0,122

            double pK = 0;
            for (int k = 0; k <= chanel; k++)
            {
                pK = p0 * (Math.Pow(alpha, k) / Factorial(k));
                Console.WriteLine($"Вероятность занятости обслуживанием {k} канала -  {pK}");
            }
            

            Console.ReadKey();
        }

        static int Factorial(int x)
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
        }
    }
}
