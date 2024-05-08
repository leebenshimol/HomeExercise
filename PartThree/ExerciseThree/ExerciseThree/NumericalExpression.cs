
namespace PartThree
{
    class NumericalExpression
    {
        private int Value;
        public NumericalExpression(int value) 
        {
            Value = value;
        }

        public int GetValue()
        {
            return Value;
        }
       
        public override string ToString()
        {
            String[] units = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            String[] tens = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
            double amountOfDigits = Math.Log10(Value) + 1;
            string numberInWords = "";
            if(amountOfDigits == 1)
            {
                numberInWords = units[Value];
            }
            if (amountOfDigits == 2)
            {
                numberInWords = units[Value / 10];
                if (Value % 10 != 0)
                    numberInWords += units[Value % 10];
            }
            if (amountOfDigits == 3)
            {
                numberInWords = units[Value / 100] + " hundreds";
                if (Value % 100 != 0)
                    numberInWords += units[Value % 100];
                if (Value % 10 != 0)
                    numberInWords += units[Value % 10];
            }
            return numberInWords;
        }
    }
}
