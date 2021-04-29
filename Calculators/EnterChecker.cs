using System;

namespace Calculators
{
    class EnterChecker
    {
        public void CheckNumber(string number, out int num)
        {
            if (!int.TryParse(number, out int numberChecked)) throw new FormatException();

            num = numberChecked;
        }
    }
}
