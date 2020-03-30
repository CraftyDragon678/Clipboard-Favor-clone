using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClipboardCavor
{
    static class Calculator
    {
        public static bool IsFormula(string str)
        {
            Regex rx = new Regex(@"^(\d+\.?\d*)(([+\-*/])(\d+\.?\d*))+$");
            return rx.Matches(str).Count == 1;
        }

        public static string Calcutate(string str)
        {
            if (IsFormula(str))
            {
                // double result = 0;
                // 
                // Regex rx = new Regex(@"([+\-*/])(\d+\.?\d*)");
                // MatchCollection matches = rx.Matches(str);
                // string first = str.Substring(0, matches[0].Index);
                // result = Double.Parse(first);
                // 
                // for (int i = 0; i < matches.Count; i++)
                // {
                //     string op = matches[i].Groups[1].Value;
                //     double val = Double.Parse(matches[i].Groups[2].Value);
                // 
                //     switch (op)
                //     {
                //         case "+":
                //             result += val;
                //             break;
                //         case "-":
                //             result -= val;
                //             break;
                //         case "*":
                //             result *= val;
                //             break;
                //         case "/":
                //             result /= val;
                //             break;
                //     }
                // }
                // 
                // return result;

                return new DataTable().Compute(str, null).ToString();
            }
            return "error";
        }
    }
}
