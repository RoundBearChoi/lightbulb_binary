using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LightBulbBinary
{
    public class BinaryToInt : MonoBehaviour
    {
        char[] arrBinaryChar = new char[32];

        [Header("Results")]
        public string binaryOutput;
        public int intOutput;
        public string intStringOutput;

        [Space(10)]

        public List<LightBulb> ListLightBulbs_B0 = new List<LightBulb>();
        public List<LightBulb> ListLightBulbs_B1 = new List<LightBulb>();
        public List<LightBulb> ListLightBulbs_B2 = new List<LightBulb>();
        public List<LightBulb> ListLightBulbs_B3 = new List<LightBulb>();

        [Space(10)]
        public Text result;

        void GetBinary(int index, List<LightBulb> lightBulbs)
        {
            for (int i = 0; i < lightBulbs.Count; i++)
            {
                int b = i + (index * 8);

                if (lightBulbs[i].On)
                {
                    arrBinaryChar[b] = '1';
                }
                else
                {
                    arrBinaryChar[b] = '0';
                }
            }
        }

        public void GetBinarySequence()
        {
            GetBinary(0, ListLightBulbs_B0);
            GetBinary(1, ListLightBulbs_B1);
            GetBinary(2, ListLightBulbs_B2);
            GetBinary(3, ListLightBulbs_B3);

            binaryOutput = new string(arrBinaryChar);
            intOutput = System.Convert.ToInt32(binaryOutput, 2);
            intStringOutput = intOutput.ToString("n0");

            result.text = intStringOutput;
        }
    }
}