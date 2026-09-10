using UnityEngine;

namespace QazaqCity.Combat
{
    public class WeaponInventory : MonoBehaviour
    {
        [System.Serializable]
        public struct Weapon
        {
            public string name;
            public int damage;
            public int ammo;
        }

        [SerializeField] private Weapon[] weapons =
        {
            new Weapon { name = "Тапанша", damage = 25, ammo = 60 },
            new Weapon { name = "Шолақ мылтық", damage = 50, ammo = 24 },
            new Weapon { name = "Автомат", damage = 30, ammo = 120 }
        };

        public int SelectedIndex { get; private set; }
        public Weapon Current => weapons.Length == 0 ? default : weapons[SelectedIndex];

        public void Select(int index)
        {
            if (index >= 0 && index < weapons.Length) SelectedIndex = index;
        }

        public bool ConsumeAmmo()
        {
            if (weapons.Length == 0 || weapons[SelectedIndex].ammo <= 0) return false;
            var w = weapons[SelectedIndex];
            w.ammo--;
            weapons[SelectedIndex] = w;
            return true;
        }
    }
}
