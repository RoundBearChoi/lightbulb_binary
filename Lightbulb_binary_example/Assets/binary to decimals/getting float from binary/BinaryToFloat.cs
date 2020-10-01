using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightBulbBinary
{
    public static class BinaryToFloat
    {
        static int two_twentythird = 8388608;

        public static decimal GetFloatingPoint(string binaryString)
        {
            int E = GetExponent(binaryString);
            Debug.Log("E: " + E);

            decimal M = GetMantissa(binaryString);
            Debug.Log("M: " + M);

            return CalcFloatingPoint(binaryString, M, E);
        }

        static int GetExponent(string binaryString)
        {
            string exponentString = binaryString.Substring(1, 8);
            int intResult = System.Convert.ToInt32(exponentString, 2);

            return (int)Mathf.Pow(2, intResult - 127);
        }

        static decimal GetMantissa(string binaryString)
        {
            string mantissaString = binaryString.Substring(9);
            int intResult = System.Convert.ToInt32(mantissaString, 2);

            return 1 + (decimal)intResult / two_twentythird;
        }

        static decimal CalcFloatingPoint(string binaryString, decimal mantissa, int exponent)
        {
            int sign = GetSign(binaryString);
            return sign * mantissa * exponent;
        }

        static int GetSign(string binaryString)
        {
            if (binaryString[0].Equals('1'))
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }
}