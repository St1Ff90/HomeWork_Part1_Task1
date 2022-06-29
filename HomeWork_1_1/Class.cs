using System.Text;

namespace HomeWork_1_1
{
    public class Class
    {
        public static string Convert(string input, int from, int to)
        {
            const int minSys = 2;
            const int maxSys = 16;

            if (string.IsNullOrEmpty(input) || from < minSys || from > maxSys || to < minSys || to > maxSys)
            {
                throw new ArgumentException("Wrong arguments!");
            }

            if (input == 0.ToString())
            {
                return 0.ToString();
            }

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

            StringBuilder result = new StringBuilder();

            while (decimalConvertationResult % to > 0 || decimalConvertationResult / to > 0)
            {
                result.Insert(0, chars[decimalConvertationResult % to].ToString());
                decimalConvertationResult /= to;
            }

            return result.ToString();
        }
    }
}