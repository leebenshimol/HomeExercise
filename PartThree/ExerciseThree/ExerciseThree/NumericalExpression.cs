
namespace PartThree
{
    class NumericalExpression
    {
        private int Value;
        private readonly String[] Units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private readonly String[] NumberSize = { "", "Thousand", "Million", "Billion"}; 
        private readonly String[] Tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
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
            if (Value == 0)
                return "Zero";

            bool isMinus = false;

            if (Value < 0)
            {
                isMinus = true;
                Value = Math.Abs(Value);
            }

            string numberInWords = "";
            
            for (int i = 0; Value > 0; i++) 
            {
                if (Value % 1000 != 0)
                {
                    numberInWords = ConvertingHundredsToWords(Value % 1000) + NumberSize[i] + " " + numberInWords;
                }
                Value /= 1000;
            }
            if (isMinus)
                return "Minus " + numberInWords;
            return numberInWords;
        }


        private string ConvertingHundredsToWords(int value)
        {
            string numberInWords = "";
            if (value >= 100)
            {
                numberInWords += Units[value / 100] + " Hundred";
                value %= 100;
            }

            if (value >= 10 && value <= 19)
            {
                numberInWords += Units[value % 10] + " ";
            }
            else
            {
                numberInWords += Tens[value / 10] + " ";
                numberInWords += Units[value % 10] + " ";
            }
            return numberInWords;
        }


        public static int SumLetters(int number)
        {
            NumericalExpression numericalExpression = new NumericalExpression(number);
            int sumLetters = 0;
            while (number >= 0) 
            {
                sumLetters += ((numericalExpression.ToString().Trim().Length));
                number -= 1;
            }
            return sumLetters;
                
        }        

        /*
         * כאן בעצם מובא לידי ביטוי פולימורפיזם - עקרון הרב צורתיות.
        נראה כי למעשה יצרנו מצב של העמסה - overloading, מאחר ויש לנו שתי פעולות בעלות חתימה זהה פרט לפרמטר אותו הפונקציה מקבלת .
         */
        public static int SumLetters(NumericalExpression numericalExpression)
        {
            int number = numericalExpression.GetValue();
            int sumLetters = 0;
            while (number >= 0) 
            {
                sumLetters += ((numericalExpression.ToString().Trim().Length));
                number -= 1;
            }
            return sumLetters;
                
        }
    }
}



//double amountOfDigits = Math.Ceiling(Math.Log10(Value));
//string numberInWords = "";
//if (amountOfDigits == 1)
//{
//    numberInWords = units[Value];
//}
//if (amountOfDigits == 2)
//{
//    numberInWords = units[Value / 10];
//    if (Value % 10 != 0)
//        numberInWords += units[Value % 10];
//}
//if (amountOfDigits == 3)
//{
//    numberInWords = units[Value / 100] + " hundreds";
//    if (Value % 100 != 0)
//        numberInWords += units[(Value % 100) / 10];
//    if (Value % 10 != 0)
//        numberInWords += units[Value % 10];
//}
//return numberInWords;