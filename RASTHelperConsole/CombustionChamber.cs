namespace Calculator
{
    class CombustionChamber
    {
        public static void combustionChamber()
        {
            Program.print("-------------------РАСЧЁТ КАМЕРЫ СГОРАНИЯ-------------------\n");

            Console.Write("Тяга Р0 = "); double P0 = Convert.ToDouble(Console.ReadLine());
            Console.Write("Давление в камере сгорания Pк = "); double Pk = Convert.ToDouble(Console.ReadLine());
            Console.Write("Давление на срезе сопла Pс = "); double Pc = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите молярную массу горючего = "); double mk = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите молярную массу окислителя = "); double mc = Convert.ToDouble(Console.ReadLine());
            Console.Write("Температура в камере сгорания = "); double Tk = Convert.ToDouble(Console.ReadLine());
            Console.Write("Температура на срезе сопла = "); double Tc = Convert.ToDouble(Console.ReadLine());


            Program.print("\nРЯД ПРИБЛИЖЕННЫХ РАСЧЁТОВ:\n");

            double Rk = 8314 / mk;
            Program.print($"Газовая постоянная горючего = {Math.Round(Rk, 4)}\n");

            double Rc = 8314 / mc;
            Program.print($"Газовая постоянная окислителя = {Math.Round(Rc, 4)}\n");

            double uk = (Rk * Tk) / Pk * Math.Pow(10, -6);
            Program.print($"Удельный объём горючего = {Math.Round(uk, 4)}\n");

            double uc = (Rc * Tc) / Pc * Math.Pow(10, -6);
            Program.print($"Удельный объём окислителя = {Math.Round(uc, 4)}\n");

            double n = Math.Log(Pk / Pc) / Math.Log(uc / uk);
            Program.print($"Показатель процесса = {Math.Round(n, 4)}\n");

            double PIkp = Math.Pow((2 / (n + 1)), (n / (n - 1)));
            double Pkp = PIkp * Pk;
            Program.print($"Степень расширения в критическом сечении = {Math.Round(PIkp, 4)} и {Math.Round(Pkp, 4)}\n");

            double wkp = Math.Sqrt(2 * (n / (n + 1)) * Rk * Tk);
            Program.print($"Cкорость потока в критическом сечении  = {Math.Round(wkp, 4)}\n");

            double ukp = uk * Math.Pow(((n + 1) / 2), (1 / (n - 1)));
            Program.print($"Удельный объём продуктов сгорания = {Math.Round(ukp, 4)}\n");

            double fkp = ukp / wkp;
            Program.print($"Удельная площадь критического сечения = {Math.Round(fkp, 4)}\n");

            double PIc = Pc / Pk;
            Program.print($"Степень расширения на срезе канала = {Math.Round(PIc, 4)}\n");

            double wc = Math.Sqrt(2 * (n / (n - 1)) * Rk * Tk * (1 - Math.Pow((Pc / Pk), ((n - 1) / n))));
            Program.print($"Скорость потока на срезе сопла = {Math.Round(wc, 4)}\n");

            double fc = uc / wc;
            Program.print($"Удельная площадь сопла = {Math.Round(fc, 4)}\n");

            double F_c = fc / fkp;
            Program.print($"Геометрическая степень расширения сопла = {Math.Round(F_c, 4)}\n");


            Program.print("\nРАСЧЁТ ПАРАМЕТРОВ ДВИГАТЕЛЯ:\n");

            double J0yd = wc + fc * Math.Pow(10, 6) * (Pc - 0.1013);
            Program.print($"Удельный импульс на земле = {Math.Round(J0yd, 4)}\n");

            double m = (P0 * 1000) / J0yd;
            Program.print($"Расход топлива = {Math.Round(m, 4)}\n");

            double J00yd = wc + fc * Math.Pow(10, 6) * Pc;
            Program.print($"Удельный импульс в пустоте = {Math.Round(J00yd, 4)}\n");

            double P00 = (J00yd * m) / 1000;
            Program.print($"Тяга в пустоте = {Math.Round(P00, 2)}\n");

            double Fkp = fkp * m * 1000;
            Program.print($"Площадь критического сечения Fkp = {Math.Round(Fkp, 2)}\n");

            double Fc = fc * m;
            Program.print($"Площадь среза сопла = {Math.Round(Fc, 4)}\n");

            double B = (Pk * Fkp) / m * 1000;
            Program.print($"Расходный комплекс = {Math.Round(B, 4)}\n");

            double k00T = P00 / (Pk * Fkp);
            Program.print($"Коэффициент тяги = {Math.Round(k00T, 4)}\n");


            Program.print("\nРАСЧЁТ КОЭФФИЦИЕНТОВ ПОТЕРЬ:\n");

            double qk = 0.97;
            double qa = 0.992;
            double q00w = 0.98;
            double q0c = 0.997;
            double q00c = qa * q00w;


            Program.print("\nРАСЧЕТ РЕАЛЬНЫХ ПАРАМЕТРОВ ДВИГАТЕЛЯ:\n");

            double r_J00yd = qk * q00c * J00yd;
            Program.print($"Удельный импульс в пустоте = {Math.Round(r_J00yd, 4)}\n");

            double r_J0yd = qk * q0c * J0yd;
            Program.print($"Удельный импульс на земле = {Math.Round(r_J0yd, 4)}\n");

            double r_m = P0 / r_J0yd * 1000;
            Program.print($"Расход топлива = {Math.Round(r_m, 4)}\n");

            Console.Write("Введите значение k = "); double k = Convert.ToDouble(Console.ReadLine());

            double r_mg = (1 / (1 + k)) * r_m;
            Program.print($"Расход горючего = {Math.Round(r_mg, 4)}\n");

            double r_mo = (k / (1 + k)) * r_m;
            Program.print($"Расход окислителя = {Math.Round(r_mo, 4)}\n");

            double r_Fkp = Fkp / q00c / 1000;
            Program.print($"Площадь критического сечения = {Math.Round(r_Fkp, 4)}\n");

            double r_Fc = Fc / q00c;
            Program.print($"Площадь сопла = {Math.Round(r_Fc, 4)}\n");

            double r_dkp = Math.Sqrt((4 * r_Fkp) / Math.PI);
            Program.print($"Диаметр критического сечения = {Math.Round(r_dkp, 4)}\n");

            double r_dc = Math.Sqrt((4 * r_Fc) / Math.PI);
            Program.print($"Диаметр сопла = {Math.Round(r_dc, 4)}\n");

            double r_P00 = r_J00yd * r_m / 1000;
            Program.print($"Тяга в пустоте = {Math.Round(r_P00, 4)}\n");

            double r_B = qk * B;
            Program.print($"Расходный комплекс = {Math.Round(r_B, 4)}\n");

            double r_k00T = ((r_P00 * Math.Pow(10, 3)) / ((Pk * Math.Pow(10, 6)) * (r_Fkp * Math.Pow(10, -3)))) / 1000;
            Program.print($"Коэффициент тяги = {Math.Round(r_k00T, 4)}\n");


            Program.print("\nПОСТОРОЕНИЕ ПРОФИЛЯ КАМЕРЫ СГОРЯНИЯ:\n");

            Console.Write("Введите первый коэфициент от 12.5 до 15 = "); double koef1 = Convert.ToDouble(Console.ReadLine());
            double r_Lpr = koef1 * Math.Pow(10, 3) / Math.Sqrt(10 * Pk * Math.Pow(10, 6));
            Program.print($"Приведённая длина канала = {Math.Round(r_Lpr, 4)}\n");

            Console.Write("Введите второй коэфициент от до 0.95 = "); double koef2 = Convert.ToDouble(Console.ReadLine());
            double r_Lk = koef2 * Math.Sqrt((r_dkp / 1000)) * 100;
            Program.print($"Условная длина канала = {Math.Round(r_Lk, 2)}\n");

            double r__Fk = r_Lpr / r_Lk;
            Program.print($"Относительная площадь канала = {Math.Round(r__Fk, 4)}\n");

            double r_Vk = r_Lpr * r_Fkp;
            Program.print($"Объём камеры сгорания = {Math.Round(r_Vk, 4)}\n");

            double r_Fk = r__Fk * r_Fkp;
            Program.print($"Площадь поперечного сечения канала = {Math.Round(r_Fk, 4)}\n");

            double r_Rk = Math.Sqrt(r_Fk / Math.PI);
            MixingHead.Rk = r_Rk;
            Program.print($"Радиус цилиндрической части канала = {Math.Round(r_Rk, 4)}\n");

            double r_p = 0.25 * Pk;
            double r_lvh = 0.5 * r_dkp * Math.Sqrt(Math.Pow((2 + r_p * Math.Sqrt(r__Fk)), 2) - (Math.Pow(((r_p - 1) * Math.Sqrt(r__Fk) + 3), 2)));
            Program.print($"Длина конфузора = {Math.Round(r_lvh, 4)}\n");

            double r_h = (2 * 0.175) / (2 + r_p * Math.Sqrt(r__Fk));
            Program.print($"Размер конфузора h = {Math.Round(r_h, 4)}\n");

            double r_H = r_lvh - r_h;
            Program.print($"Размер конфузора H = {Math.Round(r_H, 4)}\n");

            double r__y = (r_h / r_lvh) * Math.Sqrt(r__Fk) + (r_H / r_lvh);
            Program.print($"Размер конфузора _y = {Math.Round(r__y, 4)}\n");

            double r_y = r__y * r_dkp / 2;
            Program.print($"Размер конфузора y = {Math.Round(r_y, 4)}\n");

            double r_Vkonf = r_Fkp * r_lvh * (((2 * r__Fk + Math.Pow(r__y, 2)) * (r_H / (3 * r_lvh))) + ((Math.Pow(r__y, 2) + r__y + 4) * (r_h / (6 * r_lvh))));
            Program.print($"Обьём конфузора = {Math.Round(r_Vkonf, 4)}\n");

            double r_lc = (r_Vk - r_Vkonf) / r_Fk;
            Program.print($"Длина цилиндрической части = {Math.Round(r_lc, 4)}\n");

            double r_R1 = r_p * (r_dkp / 2);
            Program.print($"Pадиус сопряжения 1 = {Math.Round(r_R1, 4)}\n");

            double r_R2 = 2 * r_Rk;
            Program.print($"Pадиус сопряжения 2 = {Math.Round(r_R2, 4)}\n");

            Console.Write("Комментарий к файлу (по желанию)\nКомментарий: "); string comment = Convert.ToString(Console.ReadLine());
            Program.sw.Write(comment + "\n\n");
        }
    }
}