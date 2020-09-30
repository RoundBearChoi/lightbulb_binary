using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LightBulbBinary
{
    public class LightBulb : MonoBehaviour
    {
        public bool On;
        public SpriteRenderer renderer_0;
        public SpriteRenderer renderer_1;
        SpriteRenderer renderer_bulb;
        BinaryToInt binaryToInt;

        private void Start()
        {
            renderer_bulb = this.gameObject.GetComponent<SpriteRenderer>();
            binaryToInt = FindObjectOfType<BinaryToInt>();
        }

        private void Update()
        {
            if (On)
            {
                if (!renderer_1.enabled)
                {
                    renderer_1.enabled = true;
                }

                if (renderer_0.enabled)
                {
                    renderer_0.enabled = false;
                }

                if (renderer_bulb.color != Color.yellow)
                {
                    renderer_bulb.color = Color.yellow;
                }
            }
            else
            {
                if (renderer_1.enabled)
                {
                    renderer_1.enabled = false;
                }

                if (!renderer_0.enabled)
                {
                    renderer_0.enabled = true;
                }

                if (renderer_bulb.color != Color.white)
                {
                    renderer_bulb.color = Color.white;
                }
            }
        }

        private void OnMouseDown()
        {
            if (On)
            {
                On = false;
            }
            else
            {
                On = true;
            }

            binaryToInt.GetBinarySequence();
        }
    }
}