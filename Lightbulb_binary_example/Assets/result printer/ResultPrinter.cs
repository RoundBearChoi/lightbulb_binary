using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LightBulbBinary
{
    public class ResultPrinter : MonoBehaviour
    {
        char[] arrBinaryChar = new char[32];
        string binaryInput;

        public Text intResultText;
        public Text floatResultText;

        [Header("Decimal Results")]
        public decimal decOutput;

        [Space(10)]

        public List<LightBulb> ListLightBulbs_B0 = new List<LightBulb>();
        public List<LightBulb> ListLightBulbs_B1 = new List<LightBulb>();
        public List<LightBulb> ListLightBulbs_B2 = new List<LightBulb>();
        public List<LightBulb> ListLightBulbs_B3 = new List<LightBulb>();

        void GetBinaryInput(int index, List<LightBulb> lightBulbs)
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
            GetBinaryInput(0, ListLightBulbs_B0);
            GetBinaryInput(1, ListLightBulbs_B1);
            GetBinaryInput(2, ListLightBulbs_B2);
            GetBinaryInput(3, ListLightBulbs_B3);

            binaryInput = new string(arrBinaryChar);

            intResultText.text = BinaryToInteger.GetIntString(binaryInput);

            decimal decimalPoint = BinaryToFloat.GetDecimalPoint(binaryInput);
            floatResultText.text = decimalPoint.ToString("F7");
        }
    }
}