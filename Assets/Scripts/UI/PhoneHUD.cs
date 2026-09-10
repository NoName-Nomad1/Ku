using UnityEngine;
using TMPro;

namespace QazaqCity.UI
{
    public class PhoneHUD : MonoBehaviour
    {
        [SerializeField] private TMP_Text clockText;
        [SerializeField] private TMP_Text wantedText;
        [SerializeField] private TMP_Text locationText;

        private void Update()
        {
            if (clockText != null) clockText.text = System.DateTime.Now.ToString("HH:mm");
        }

        public void SetWanted(int level)
        {
            if (wantedText != null) wantedText.text = level > 0 ? $"ҚАЛАУ: {level}/5" : "ТЫНЫШ";
        }

        public void SetLocation(string location)
        {
            if (locationText != null) locationText.text = location;
        }
    }
}
