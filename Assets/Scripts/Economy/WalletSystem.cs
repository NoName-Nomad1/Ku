using UnityEngine;

namespace QazaqCity.Economy
{
    public class WalletSystem : MonoBehaviour
    {
        [SerializeField] private int startingMoney = 1000;
        public int Money { get; private set; }
        public event System.Action<int> MoneyChanged;

        private void Awake() => Money = Mathf.Max(0, startingMoney);

        public void AddMoney(int amount)
        {
            if (amount <= 0) return;
            Money += amount;
            MoneyChanged?.Invoke(Money);
        }

        public bool Spend(int amount)
        {
            if (amount <= 0 || Money < amount) return false;
            Money -= amount;
            MoneyChanged?.Invoke(Money);
            return true;
        }
    }
}
