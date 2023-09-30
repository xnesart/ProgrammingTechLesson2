using System;

namespace ProgrammingTechLesson2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Создать консольное приложение C# для расчета будущей стоимости капиталовложений,
            // которые имеют фиксированную ставку для прибыли на инвестиционный капитал.
            
            Console.WriteLine("Введите первоначальную стоимость вклада, внесите больше 5000$");
            decimal balance = decimal.Parse(Console.ReadLine());
            if (balance < 5000) Console.WriteLine("Предупреждение, минимальный остаток меньше 5000$");
            if (balance <= 0)
            {
                throw new ArgumentException("Вы ввели нулевой или отрицательный баланс, ошибка!");
            }
            //объявляем переменные - стартовая ставка, расчет процента от текущего баланса и расчет выплат
            decimal startBid = balance;
            decimal interestRate = 0;
            decimal payments = 0;
            decimal percent = 8;
            for (int i = 0; i <= 9; i++)
            {
                //вычисляем норму прибыли за год
                interestRate = balance * percent / 100;
                //присваиваем переменной выплаты значение нормы прибыли за год
                payments = interestRate;
                //прибавляем к балансу платежи за год
                balance += interestRate;
                Console.WriteLine($"Выплаты за {i + 1} год = " + Math.Round(payments, 3)+ "$");
                Console.WriteLine($"Общая сумма в {i + 1} год = " + Math.Round(balance, 3) + "$");
            }
            //вычисляем эффективную процентную ставку
            decimal newBid = 0;
            if (balance > startBid)
            {
                newBid = (balance / startBid) * 100 - 100;
            }
            else
            {
                newBid = (startBid / balance) * 100 - 100;
            }
            Console.WriteLine($"Эффективная процентная ставка = {Math.Round(newBid,3)}");
            
            
            //Вызов задания 2 и 3
            Console.WriteLine("Введите количество месяцев для расчета, от 12 до 48");
            int months = int.Parse(Console.ReadLine());
            //обрабатываем ошибку, если введено неверное количество месяцев для расчета
            if (months <= 0 || months < 12 || months > 48)
            {
                throw new ArgumentException("Вы ввели недопустимое количество месяцев, ошибка!");
            }
            balance = GetAnInvestment(balance,months);
            Console.WriteLine($"Итоговый баланс = {Math.Round(balance,3)}$");
        }

        /// <summary>
        /// рассчёт изменения капитала в акциях за 12 - 48 месяцев 
        /// </summary>
        /// <param name="balance"></param>
        /// <returns></returns>
        public static decimal GetAnInvestment(decimal balance, int monhts)
        {
            //Объявляем переменные - приращение, начальный баланс, норма инвестиций в месяц и месячный процент
            decimal increment = 0;
            decimal startBalance = balance;
            decimal monhtlyInterestRate = 0;
            decimal monthlyPercent = 0;
            decimal averrageValue = 0;

            for (int i = 0; i < monhts; i++)
            {
                //вычисляем процент за месяц
                monthlyPercent = Convert.ToDecimal(0.1 + 0.02 * i * i + 0.5 * Math.Sin(2 * i) + Math.Cos(3 * i));
                //вычисляем норму прибыли за месяц
                monhtlyInterestRate = balance * monthlyPercent / 100;
                //высчитываем среднее значение
                averrageValue += monhtlyInterestRate;
                //расчет нового баланса
                balance += monhtlyInterestRate;
                //вычисляем процент приращения вложений
                increment += monthlyPercent;
                Console.WriteLine($"Баланс за {i+1} месяц = {Math.Round(balance,3)}$, норма прибыли = {Math.Round(monhtlyInterestRate,3)}$");
            }
            //вычисление среднее значение нормы прибыли за n месяцев
            averrageValue /= monhts;
            Console.WriteLine($"Процент приращения вложений = {Math.Round(increment,3)} Сумма приращения вложений = {Math.Round(balance - startBalance,3)}$, среднее значение нормы прибыли за период в {monhts} месяцев = {Math.Round(averrageValue,3)}");
            
            return balance;
        }
    }
}