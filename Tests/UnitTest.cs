using HomeWork_ITIA;

namespace Tests
{
    public class Tests
    {
        [TestCase("0", 2, 10, "0")]
        [TestCase("567", 8, 10, "375")]
        [TestCase("15D", 16, 2, "101011101")]
        public void ConvertFromOneNumeralSysToOther_WhenInputStrIsNotNullOrHasWrongCharsAndNumeralSystemsAreMoreThenTwoAndLessThenSixten_ShouldConvertFromOneNumeralSysToOther(
            string inputStr, 
            int convertFrom, 
            int convertTo, 
            string outputStr)
        {
            string expeectedResult = HomeWork_ITIA.Program.Convert(inputStr, convertFrom, convertTo);

            Assert.AreEqual(outputStr, expeectedResult);
        }

        [TestCase(null, 2, 10)]
        [TestCase("0", 1, 10)]
        [TestCase("0", 17, 10)]
        [TestCase("0", 10, 1)]
        [TestCase("0", 10, 17)]
        [TestCase("123", 2, 10)]
        [TestCase("15B", 10, 8)]
        [TestCase("15G", 16, 10)]
        public void ConvertFromOneNumeralSysToOther_WhenInputStrIsNullOrHasWrongCharsAndNumeralSystemsAreMoreThenTwoAndLessThenSixten_ShouldThrowException(
            string inputStr, 
            int convertFrom, 
            int convertTo)
        {
            try
            {
                HomeWork_ITIA.Program.Convert(inputStr, convertFrom, convertTo);
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("Wrong arguments!", ex.Message);
                Assert.Pass();
            }

            Assert.Fail();
        }
    }
}