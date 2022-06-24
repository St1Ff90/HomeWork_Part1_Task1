namespace HomeWork_ITIA
{
    public class Program
    {
        public static string Convert(string input, int from, int to)
        {
            if (string.IsNullOrEmpty(input) || from < 2 || from > 16 || to < 2 || to > 16)
            {
                throw new ArgumentException("Wrong arguments!");
            }
            string result = "";
            char[] chars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            char[] currentCharsArr = chars[0..from];
            int decimalConvertationResult = 0;
            char[] inputArray = input.ToCharArray();
            Array.Reverse(inputArray);

            for (int i = 0; i < inputArray.Length; i++)
            {
                int decimalValue = Array.IndexOf(currentCharsArr, inputArray[i]);

                if (decimalValue < 0)
                {
                    throw new ArgumentException("Wrong arguments!");
                }
                else
                {
                    decimalConvertationResult += decimalValue * (int)Math.Pow(from, i);
                }
            }

            if (decimalConvertationResult == 0)
            {
                return "0";
            }

            while (decimalConvertationResult % to > 0 || decimalConvertationResult / to > 0)
            {
                result = chars[decimalConvertationResult % to].ToString() + result;
                decimalConvertationResult /= to;
            }

            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Convert("15651", 8, 16);
        }
    }
}