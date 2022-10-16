using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitConversion
{
    internal class Calculator
    {
        private double unit_num;
        private string unit;
        private string target;
        private string target_type;
        private Prefixes checkPrefix = new Prefixes();

        public Calculator(double unit_num, string unit, string target, string target_type)
        {
            this.unit_num = unit_num;
            this.unit = unit;
            this.target = target;
            this.target_type = target_type;
        }
        public double Get_Calc()
        {
            return Calc();
        }

        private double Calc()
        {
            double conversionRate = 0;
            string symbol = "";
            List<string[]> conversions = checkPrefix.Get_unit_Conversion(unit);

            foreach(var conversion in conversions)//Looksup the target in unit_Conversions
            {
                if (conversion[0] == target)
                {
                    conversionRate = double.Parse(conversion[1]);
                    symbol = conversion[2];
                }
            }
            if (symbol != "")//Lookup symbol, then calculate
            {
                switch (symbol)
                {
                    case "*":
                        unit_num *= conversionRate;
                        break;
                    case "/":
                        unit_num /= conversionRate;
                        break;
                    case "+":
                        unit_num += conversionRate;
                        break;
                    case "-":
                        unit_num -= conversionRate;
                        break;
                }
            }
            else//Temperature calculation
            {
                if (target.Equals("fahrenheit"))
                {
                    unit_num = (unit_num * 9 / 5) + 32;
                }
                else if (target.Equals("celsius"))
                {
                    unit_num = (unit_num - 32) * 5 / 9;
                }
            }
       
            if(checkPrefix.Get_Prefix(target_type) != 0)// If contains prefix
            {
                double pref = 0;
                if(checkPrefix.Get_Prefix(target_type) > 0)//If exponent larger than 0
                {
                    pref = Math.Pow(10, (checkPrefix.Get_Prefix(target_type) * -1));
                    unit_num = unit_num * pref;
                }
                else// If exponent smaller than 0
                {
                    pref = Math.Pow(10, Math.Abs(checkPrefix.Get_Prefix(target_type)));
                    unit_num = unit_num * pref;
                }
            }
            return unit_num;
        }
    }
}
