namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ввод данных
            Console.Write("Введите урожайность пшеницы (ц/га): ");
            double P = double.Parse(Console.ReadLine());

            Console.Write("Введите урожайность ржи (ц/га): ");
            double T = double.Parse(Console.ReadLine());

            Console.Write("Введите общую площадь угодий (га): ");
            double C = double.Parse(Console.ReadLine());

            Console.Write("Введите процент ежегодного увеличения площади под рожь (%): ");
            double r = double.Parse(Console.ReadLine());

            Console.Write("Введите количество лет: ");
            int N = int.Parse(Console.ReadLine());

            // Начальные площади
            double wheatArea = C / 2;
            double ryeArea = C / 2;

            Console.WriteLine("\nГод\tПшеница (ц)\tРожь (ц)\tПлощадь пшеницы\tПлощадь ржи");

            for (int year = 1; year <= N; year++)
            {
                double wheatYield = wheatArea * P;
                double ryeYield = ryeArea * T;

                Console.WriteLine($"{year}\t{wheatYield:F2}\t\t{ryeYield:F2}\t\t{wheatArea:F2} га\t\t{ryeArea:F2} га");

                // На следующий год площадь ржи увеличивается на r%
                double newRyeArea = ryeArea * (1 + r / 100);
                if (newRyeArea > C) newRyeArea = C;
                wheatArea = C - newRyeArea;
                ryeArea = newRyeArea;
            }

            Console.ReadKey();
        }
    }
}