using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Components
{
    internal class Calculate
    {
        //int result = 0;
        //public int Plus(int A, int B)
        //{
        //    result = A + B;
        //    return result;
        //}
        //public int Minus(int A, int B)
        //{
        //    result = A - B;
        //    return result;
        //}
        //public int Multiply(int A, int B)
        //{
        //    result = A * B;
        //    return result;
        //}
        //public int Divide(int A, int B)
        //{
        //    result = A / B;
        //    return result;
        //}
        public int ConvertToMath(string mathString)
        {
            string input = mathString;
            DataTable dt = new DataTable();
            var result = dt.Compute(input, "");
            decimal decimalResult;
            if (decimal.TryParse(result.ToString(), out decimalResult))
            {
                return Convert.ToInt32(Math.Round(decimalResult, MidpointRounding.AwayFromZero));
            }
            else
            {
                return 0;
            }
        }
    }
}
