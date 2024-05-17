
namespace PartThree
{
    class NumericalExpression
    {
        private int _value;
        private readonly String[] _units = { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private readonly String[] _numberSize = { "", "Thousand", "Million", "Billion"}; 
        private readonly String[] _tens = { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        public NumericalExpression(int value)
        {
            _value = value;
        }

        public int GetValue()
        {
            return _value;
        }

        public override string ToString()
        {
            if (_value == 0)
                return "Zero";

            bool isMinus = false;

            if (_value < 0)
            {
                isMinus = true;
                _value = Math.Abs(_value);
            }

            string numberInWords = "";
            
            for (int i = 0; _value > 0; i++) 
            {
                if (_value % 1000 != 0)
                {
                    numberInWords = ConvertingHundredsToWords(_value % 1000) + _numberSize[i] + " " + numberInWords;
                }
                _value /= 1000;
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
                numberInWords += _units[value / 100] + " Hundred";
                value %= 100;
            }

            if (value >= 10 && value <= 19)
            {
                numberInWords += _units[value % 10] + " ";
            }
            else
            {
                numberInWords += _tens[value / 10] + " ";
                numberInWords += _units[value % 10] + " ";
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
