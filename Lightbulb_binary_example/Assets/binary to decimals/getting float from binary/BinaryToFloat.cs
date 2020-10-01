using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightBulbBinary
{
    public static class BinaryToFloat
    {
        static int power_two_23 = 8388608;

        public static decimal GetFloatingPoint(string binaryString)
        {
            decimal E = GetExponent(binaryString);
            Debug.Log("E: " + E);

            decimal M = GetMantissa(binaryString);
            Debug.Log("M: " + M);

            return CalcFloatingPoint(binaryString, M, E);
        }

        static decimal GetMantissa(string binaryString)
        {
            string twentythree_bits = binaryString.Substring(9); // 111 1111 1111 1111 1111 1111
            int seven_digit_int = System.Convert.ToInt32(twentythree_bits, 2); // max = 8,388,607 (what you can express with 23 bits)

            return 1 + (decimal)seven_digit_int / power_two_23; // "power_two_23" = 2^23 = 8,388,608
        }

        static decimal GetExponent(string binaryString)
        {
            try
            {
                string exponent_part = binaryString.Substring(1, 8); // 1111 1111
                int intResult = System.Convert.ToInt32(exponent_part, 2); // max = 255 (what you can express with 8 bits)

                Debug.Log("0~255: " + intResult);

                return (decimal)Mathf.Pow(2, intResult - 127);
            }
            catch(System.Exception e)
            {
                Debug.Log(e);
                return 0;
            }
        }

        static decimal CalcFloatingPoint(string binaryString, decimal mantissa, decimal exponent)
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