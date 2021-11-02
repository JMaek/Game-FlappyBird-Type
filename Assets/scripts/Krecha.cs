using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.scripts
{
    public class Krecha : MonoBehaviour
    {
        public TextMeshProUGUI pos;
        public TextMeshProUGUI scor;
        public TextMeshProUGUI nam;
        public void SetData(string username, string score, int i)
        {
            nam.text = username;
            scor.text = score;
            pos.text = $"{i + 1}.";
        }

        internal void Highlight(bool highlight)
        {
            RectTransform krecha = GetComponent<RectTransform>();

            if (highlight)
            {
                krecha.GetComponent<Image>().color = new Color32(94, 49, 0, 88);
            }
            else
            {
                krecha.GetComponent<Image>().color = Color.clear;
            }
        }
    }
}
