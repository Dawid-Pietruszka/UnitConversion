using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConversion
{
    internal class Prefixes
    {
        private Dictionary<string, int> si_Prefixes = new Dictionary<string, int>// All prefixes
        {
            {"yotta",24 },
            {"zetta",21 },
            {"exa",18  },
            {"peta",15 },
            {"tera",12 },
            {"giga",9  },
            {"mega",6 },
            {"kilo",3 },
            {"hecto",2 },
            {"deca",1 },
            {"deci",-1 },
            {"centi",-2 },
            {"mili",-3 },
            {"micro",-6 },
            {"nano",-9  },
            {"pico",-12 },
            {"femto",-15 },
            {"atto",-18  },
            {"zepto",-21 },
            {"yocto",-24 },
        };
        private Dictionary<string, string> unit_Type = new Dictionary<string, string>//All compatible types
        {
            {"celsius","temp" },
            {"fahrenheit","temp" },
            {"meter", "length" },
            {"inch", "length" },
            {"mile", "length" },
            {"feet", "length" },
            {"byte", "data" },
            {"bit", "data" }
        };
        private Dictionary<string, List<string[]>> unit_Conversions = new Dictionary<string, List<string[]>>()//Conversions with rates & symbols
        {
            { "meter", new List<string[]> 
            {
                new string[]{"feet", "3.281", "*" },
                new string[]{"inch", "39.37", "*" },
                new string[]{"mile", "1609", "/" }
            } },
            {"feet", new List<string[]> 
            {
                new string[]{"inch", "12", "*"},
                new string[]{"mile", "5280", "/"},
                new string[]{"meter", "3.281", "/"},
            } },
            {"mile", new List<string[]>
            {
                new string[]{"inch", "63360", "*"},
                new string[]{"feet", "5280", "*"},
                new string[]{"meter", "1609", "*"},
            } },
            {"inch", new List<string[]>
            {
                new string[]{"feet", "12", "/"},
                new string[]{"mile", "63360", "/"},
                new string[]{"meter", "39.37", "/"},
            } },
            {"bit", new List<string[]>
            {
                new string[]{"byte", "8", "/"},
            } },
            {"byte", new List<string[]>
            {
                new string[]{"bit", "8", "*"},
            } },
        };
        public void Set_Prefix(string key, int value)//Getters & Setters
        {
            if (si_Prefixes.ContainsKey(key))
            {
                si_Prefixes[key] = value;
            }
            else
            {
                si_Prefixes.Add(key, value);
            }
        }
        public int Get_Prefix(string key)
        {
            int result = 0;

            if (si_Prefixes.ContainsKey(key))
            {
                result = si_Prefixes[key];
            }

            return result;
        }
        public void Set_unit_Conversion(string key, List<string[]> value)
        {
            if (unit_Conversions.ContainsKey(key))
            {
                unit_Conversions[key] = value;
            }
            else
            {
                unit_Conversions.Add(key, value);
            }
        }
        public List<string[]> Get_unit_Conversion(string key)
        {
            List<string[]> result = new List<string[]>();

            if (unit_Conversions.ContainsKey(key))
            {
                result = unit_Conversions[key];
            }

            return result;
        }
        public void Set_UnitType(string key, string value)
        {
            if (unit_Type.ContainsKey(key))
            {
                unit_Type[key] = value;
            }
            else
            {
                unit_Type.Add(key, value);
            }
        }
        public string Get_UnitType(string key)
        {
            string result = "";

            if (unit_Type.ContainsKey(key))
            {
                result = unit_Type[key];
            }

            return result;
        }
    }
}
