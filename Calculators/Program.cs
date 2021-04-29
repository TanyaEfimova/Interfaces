using System;

namespace Calculators
{
    class Program
    {
        public delegate long EnteredDelegate(int[] array);
        public static event EnteredDelegate TwoNumbersEnteredEvent;
        static ILogger Logger { get; set; }
        static void Main()
        {
            Logger = new Logger();
            CalculatorMini calculatorMini = new CalculatorMini();
            TwoNumbersEnteredEvent += ((ISummable)calculatorMini).Summing;

            EnterChecker enterChecker = new EnterChecker();

            while (true)
            {
                Console.WriteLine("Для нахождения суммы двух целых чисел");
                int[] numbers = new int[2];
                int i = 0;
                do
                {
                    try
                    {
                        Console.WriteLine("введите целое число номер {0}:", i + 1);
                        string number = Console.ReadLine();
                        enterChecker.CheckNumber(number, out numbers[i]);
                        i++;
                    }
                    catch (FormatException)
                    {
                        Logger.Error("Введено некорректное значение!");
                    }
                }
                while (i < 2);

                long? summa = TwoNumbersEnteredEvent?.Invoke(numbers);
                Logger.Event("Сумма чисел " + numbers[0].ToString() + " и " + numbers[1].ToString() + " равна " + summa.ToString());
                Console.WriteLine("____________________________________________________");
            }
        }
    }
}
