using UnitConversion;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Input e.g. 1 kilometer: ");
        string unit = Console.ReadLine();
        Console.WriteLine("Input Target: ");
        string target = Console.ReadLine();

        string str = UnitConversion.ConvertUnit.ConverterMethod(unit, target);
        Console.WriteLine(str.ToString());
    }
}