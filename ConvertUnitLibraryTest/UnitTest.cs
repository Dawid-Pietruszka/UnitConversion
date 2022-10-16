using System.Runtime.CompilerServices;
using UnitConversion;

namespace ConvertUnitLibraryTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestLengthConversionCorrect()
        {
            string[] measurements = {"3 kiloinches", "0 kilometer", "1 kilometer", "2 meteR", "3 centimeter", "4 inches", "5 feet", "12 kilomiles", "1000 milimetre", "1 kilometre" };
            string[] target = {"meter", "feet", "inches", "kilometerS", "feet", "meters", "kiloinches", "kilomiles","kilometer", "milimetre" };
            double[] output = { 76.2001524003048, 0, 39370, 0.002, 0.09843, 0.10160020320040641, 0.06, 12, 0.001, 1000000 };
            string variable = "";
            for (int i = 0; i < measurements.Length; i++)
            {
                variable = ConvertUnit.ConverterMethod(measurements[i], target[i]);
                Assert.AreEqual((output[i].ToString() + " " + target[i]), variable);
            }
        }
        
        [TestMethod]
        public void TestByteConversion()
        {
            string[] measurements = { "0 bits", "1 byte", "2 biT", "3 kilobit", "4 megabyte", "5 bytes", "12 bit", };
            string[] target = { "bytes", "byte", "bit", "bytE", "gigabit", "kilobits", "bytes", };
            double[] output = { 0, 1, 2, 375, 0.032, 0.04, 1.5 };
            string variable = "";
            for (int i = 0; i < measurements.Length; i++)
            {
                variable = ConvertUnit.ConverterMethod(measurements[i], target[i]);
                Assert.AreEqual((output[i].ToString() + " " + target[i]), variable);
            }
        }
        [TestMethod]
        public void TestTemperatureConversion()
        {
            string[] measurements = { "0 celsius", "1 celsius", "2 fahrenheiT", "3 kilofahrenheit", "4 megacelsius", "5 celsius", "12 fahrenheit", };
            string[] target = { "fahrenheit", "celsius", "fahrenheiT", "celsius", "gigafahrenheit", "kilofahrenheits", "celsius", };
            double[] output = { 32, 1, 2, 1648.888888888889, 0.007200032, 0.041, -11.11111111111111 };
            string variable = "";
            for (int i = 0; i < measurements.Length; i++)
            {
                variable = ConvertUnit.ConverterMethod(measurements[i], target[i]);
                Assert.AreEqual((output[i].ToString() + " " + target[i]), variable);
            }
        }
        [TestMethod]
        public void TestConversionNotCorrect()
        {
            string[] measurements = { "0 kilometer", "1 ceLsius", "2 byte", "3 centimeter", "4 celsius", "5 feet", };
            string[] target = { "bit", "inches", "kilometerS", "centicelsius", "bytes", "fahrenheit", };
            string variable = "";
            for (int i = 0; i < measurements.Length; i++)
            {
                try
                {
                    variable = ConvertUnit.ConverterMethod(measurements[i], target[i]);
                    Assert.Fail();
                }
                catch (Exception e) { }
            }
        }
        [TestMethod]
        public void TestFormatNotCorrect()
        {
            string[] measurements = { "kilometer", "1 ceius", "2 byte", "3 centimeter",};
            string[] target = { "bit", "inches", "kilomeerS", "cetnticelsius", };
            string variable = "";
            for (int i = 0; i < measurements.Length; i++)
            {
                try
                {
                    variable = ConvertUnit.ConverterMethod(measurements[i], target[i]);
                    Assert.Fail();
                }
                catch (Exception e) { }
            }
        }
    }
}