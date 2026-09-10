using UnityEngine;
using TMPro;

namespace QazaqCity.UI
{
    public class KazakhUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text moneyText;
        [SerializeField] private TMP_Text missionText;

        private int money;

        private void Start()
        {
            SetMoney(0);
            SetMission("Алғашқы тапсырма: қалаға кір");
        }

        public void SetMoney(int value)
        {
            money = Mathf.Max(0, value);
            if (moneyText != null) moneyText.text = $"Ақша: {money} ₸";
        }

        public void AddMoney(int amount) => SetMoney(money + amount);

        public void SetMission(string text)
        {
            if (missionText != null) missionText.text = $"Тапсырма: {text}";
        }
    }
}
