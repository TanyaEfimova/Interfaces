namespace Calculators
{
    public class CalculatorMini : ISummable
    {
        long ISummable.Summing(int[] numbers)
        {
            long sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }
    }
}