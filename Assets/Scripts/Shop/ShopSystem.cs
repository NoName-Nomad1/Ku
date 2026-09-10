using UnityEngine;
using QazaqCity.Economy;

namespace QazaqCity.Shop
{
    public class ShopSystem : MonoBehaviour
    {
        [SerializeField] private WalletSystem wallet;

        public bool Buy(string itemName, int price)
        {
            if (wallet == null || !wallet.Spend(price)) return false;
            Debug.Log($"Сатып алынды: {itemName}");
            return true;
        }
    }
}
