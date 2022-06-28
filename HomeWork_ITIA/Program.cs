using System.Text;

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

            StringBuilder result = new StringBuilder();
            char[] chars = "0123456789ABCDEF".ToCharArray();
            char[] currentCharsArr = chars[0..from];
            int decimalConvertationResult = 0;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                int decimalValue = Array.IndexOf(currentCharsArr, input[i]);

                if (decimalValue >= 0)
                {
                    decimalConvertationResult += decimalValue * (int)Math.Pow(from, input.Length - 1 - i); 
                }
                else
                {
                    throw new ArgumentException("Wrong arguments!");
                }
            }

            if (decimalConvertationResult == 0)
            {
                return 0.ToString();
            }

            while (decimalConvertationResult % to > 0 || decimalConvertationResult / to > 0)
            {
                result.Insert(0, chars[decimalConvertationResult % to].ToString());
                decimalConvertationResult /= to;
            }

            return result.ToString();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Convert("15651", 8, 16);
        }
    }
}