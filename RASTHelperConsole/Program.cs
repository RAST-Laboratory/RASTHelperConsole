namespace Calculator
{
    class Program
    {
        protected static string date = DateTime.UtcNow.ToString("HH-mm-ss_ddMMyyyy");
        public static StreamWriter sw = new StreamWriter($"answer_{date}.txt");

        public static void Main(string[] args)
        {
            Console.WriteLine("Приветствую!\nПрограмму разработал: Ckompadre & Vlad\n");
            while (true)
            {
                Console.Write("Выберете действие:\n0. Выход\n1. Расчёт камеры сгорания\n2. Расчёт смесительной головки\nОтвет: ");
                byte mainInput = Convert.ToByte(Console.ReadLine());

                if (mainInput == 0)
                {
                    sw.Close();
                    break;
                }
                else if (mainInput == 1)
                {
                    CombustionChamber.combustionChamber();
                }
            }
        }

        public static void print(string x)
        {
            sw.Write(x);
            sw.Flush();
            Console.WriteLine(x);
        }
    }
}