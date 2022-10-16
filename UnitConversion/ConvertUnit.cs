using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml;

namespace UnitConversion
{
    //Length, data, temperature
    //SI prefixes
    //Input is String, String
    //output is String
    //E.g. ("3 kiloinches", "meter") -> "76.2 meter"
    
    public static class ConvertUnit
    {
        public static string ConverterMethod(string input, string target)
        {
            List<string> variables = new List<string>();
            double i = 0;
            
            try
            {
                variables = Splitter(input, target);
                i = Calculate(variables);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            string output = i.ToString() + " " + target;

            return output;
        }
         private static double Calculate(List<string> variables)
        {
            
            var prefixes = new Prefixes();

            //Dissects the split variables into a more readable format

            double unit_num = double.Parse(variables[0]);
            string unit_prefix = variables[1];
            string unit = variables[2];
            string target_prefix = variables[3];
            string target = variables[4];

            
            if ((target_prefix + target).Equals(unit_prefix + unit))//If Input & target are same
            {
                return unit_num;
            }
            else if(!prefixes.Get_UnitType(variables[2]).Equals(prefixes.Get_UnitType(target)))//If input & target are different types e.g. inch to celsius
            {
                throw (new UnitMisMatchException("Wrong Input & Target Unit Types"));
            }

            double unitPref = Math.Pow(10, prefixes.Get_Prefix(unit_prefix));//Calculate prefix for input
            unit_num = unit_num * unitPref;

            Calculator converter = new Calculator(unit_num, unit, target, target_prefix);
            return converter.Get_Calc();
        }
        private static List<string> Splitter(string input, string target) //Splits input&output into multiple parts
        {
            List<string> output = new List<string>();
            string type = "";
            //Splits input into 2 sections
            string[] splitter = input.Split(' ');
            if(splitter.Length != 2)
            {
                throw (new WrongFormatException("Wrong Format - Please use: Number Unit\nE.g. 1 kilometer"));
            }
            output.Add(splitter[0]);

            target = target.ToLower();
            splitter[1] = splitter[1].ToLower();

            //Check whether a prefix exists
            string prefix = CheckForPrefix(splitter[1]);
            if(prefix != "")
            {
                output.Add(prefix);
            }
            else
            {
                output.Add("");
            }
            type = CheckForType(splitter[1], prefix.Length);
            output.Add(type);

            prefix = CheckForPrefix(target);
            if(prefix != "")
            {
                output.Add(prefix);
            }
            else
            {
                output.Add("");
            }
            type = CheckForType(target, prefix.Length);
            output.Add(type);

            return output;
        }
        //Check whether a prefix exists by looping through the string until it matches
        private static string CheckForPrefix(string check)
        {
            var Prefixes = new Prefixes();
            string strs = "";
            foreach (var str in check)
            {
                strs = strs + str;
                if (Prefixes.Get_Prefix(strs) != 0)
                {
                    return strs;
                }
            }
            return "";
        }
        //Check whether a type exists by looping through the string until it matches
        //if not, throw exception
        private static string CheckForType(string check, int startLength)
        {
            var Prefixes = new Prefixes();
            string strs = "";
            for(int i = startLength; i < check.Length; i++)
            {
                strs = strs + check[i];
                if(Prefixes.Get_UnitType(strs) != "")
                {
                    return strs;
                }
                else if (strs.Equals("metre"))
                {
                    strs = "meter";
                    return strs;
                }
                else if(strs.Equals("foot"))
                {
                    strs = "feet";
                    return "feet";
                }
            }
            throw (new WrongFormatException("Wrong Format or unknown unit - Please use: Unit\nE.g. kilometer"));
        }
    }
}
public class UnitMisMatchException : Exception
{
    public UnitMisMatchException(string message):base(message){}
}
public class WrongFormatException : Exception
{
    public WrongFormatException(string message) : base(message) { }
}