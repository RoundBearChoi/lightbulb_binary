using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightBulbBinary
{
    public static class BinaryToInteger
    {
        static int intOutput;

        public static string GetIntString(string binaryString)
        {
            intOutput = System.Convert.ToInt32(binaryString, 2);
            return intOutput.ToString("n0");
        }
    }
}