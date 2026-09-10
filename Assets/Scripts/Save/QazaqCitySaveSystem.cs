using UnityEngine;
using QazaqCity.Economy;

namespace QazaqCity.Save
{
    public class QazaqCitySaveSystem : MonoBehaviour
    {
        [SerializeField] private WalletSystem wallet;
        private const string MoneyKey = "QazaqCity.Money";

        private void Start() => Load();

        public void Save()
        {
            if (wallet == null) return;
            PlayerPrefs.SetInt(MoneyKey, wallet.Money);
            PlayerPrefs.Save();
        }

        public void Load()
        {
            if (wallet == null) return;
            if (PlayerPrefs.HasKey(MoneyKey))
            {
                int saved = Mathf.Max(0, PlayerPrefs.GetInt(MoneyKey));
                int delta = saved - wallet.Money;
                if (delta > 0) wallet.AddMoney(delta);
                else if (delta < 0) wallet.Spend(-delta);
            }
        }

        private void OnApplicationPause(bool pause) { if (pause) Save(); }
        private void OnApplicationQuit() => Save();
    }
}
