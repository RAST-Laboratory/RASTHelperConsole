namespace Calculator
{
    class MixingHead
    {
        public static double Rk;

        public void mixingHead()
        {
            Program.print("--------------------СМЕСИТЕЛЬНАЯ ГОЛОВКА--------------------\n");

            Console.Write("Введите диаметр форсунок ядра = "); double dyaf = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите диаметр пристеночного слоя = "); double dprf = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите delta 1 (1..5) = "); double delta1 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите delta 2 (1..4) = "); double delta2 = Convert.ToDouble(Console.ReadLine());

            double H = dyaf + delta1;
            Program.print($"Шаг между форсунками = {H}");

            double lpr = 0.5 * dyaf + dprf + delta1 + delta2;
            Program.print($"Толщина пристеночного слоя головки = {lpr}");

            if (Rk == 0)
            {
                Console.Write("Введите радиус цилиндрической части канала: "); Rk = Convert.ToDouble(Console.ReadLine());
            }
            double Rya = Rk + lpr;
            Program.print($"Радиус ядра головки = {Rya}");

            double n = Rya / H;
            Program.print($"Число концентрических окружностей = {n}");

            double Zyaf = 1 + 6 * Factorial(n);
            Program.print($"Число форсунок ядра и пристеночного слоя = {Zyaf}");
        }

        public static double Factorial(double x)
        {
            double factorial = 1;
            for (int i = 1; i < x + 1; i++)
            {
                factorial *= i;
            }

            return factorial;
        }
    }
}