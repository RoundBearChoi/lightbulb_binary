using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightBulbBinary
{
    public static class BinaryToFloat
    {
        public static decimal GetDecimalPoint(string binaryString)
        {
            int exponent = GetExponent(binaryString);
            decimal mantissa = GetMantissa(binaryString);
            decimal finalResult = GetDecimal(binaryString, mantissa, exponent);

            return finalResult;
        }

        static int Two_Or_Zero(string binaryString, int index)
        {
            if (binaryString[index].Equals('1'))
            {
                return 2;
            }

            return 0;
        }

        static int GetExponent(string binaryString)
        {
            int i1 = (int)Mathf.Pow(Two_Or_Zero(binaryString, 1), 7);
            int i2 = (int)Mathf.Pow(Two_Or_Zero(binaryString, 2), 6);
            int i3 = (int)Mathf.Pow(Two_Or_Zero(binaryString, 3), 5);
            int i4 = (int)Mathf.Pow(Two_Or_Zero(binaryString, 4), 4);
            int i5 = (int)Mathf.Pow(Two_Or_Zero(binaryString, 5), 3);
            int i6 = (int)Mathf.Pow(Two_Or_Zero(binaryString, 6), 2);
            int i7 = (int)Mathf.Pow(Two_Or_Zero(binaryString, 7), 1);
            int i8 = (int)Mathf.Pow(Two_Or_Zero(binaryString, 8), 0);

            return i1 + i2 + i3 + i4 + i5 + i6 + i7 + i8;
        }

        static decimal GetMantissa(string binaryString)
        {
            int MantissaStart = 9;
            int ExponentStart = -1;
            decimal result = 0;

            for (int i = 0; i < 23; i++)
            {
                int exponent = ExponentStart - i;
                int two = Two_Or_Zero(binaryString, MantissaStart + i);

                if (two != 0)
                {
                    result += (decimal)Mathf.Pow(two, exponent);
                }
            }

            return result;
        }

        static decimal GetDecimal(string binaryString, decimal mantissa, int exponent)
        {
            try
            {
                int sign = GetSign(binaryString);
                decimal a = (decimal)1 + mantissa;
                decimal b = (decimal)Mathf.Pow(2, exponent - 127);

                return sign * a * b;
            }
            catch(System.Exception e)
            {
                Debug.Log(e);

                return 0;
            }
        }

        static int GetSign(string binaryString)
        {
            if (binaryString[0].Equals('1'))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }
}