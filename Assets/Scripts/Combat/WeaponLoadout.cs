using System;
using UnityEngine;

namespace QazaqCity.Combat
{
    public enum WeaponType { Pistol, Shotgun, Rifle }

    [Serializable]
    public struct WeaponData
    {
        public WeaponType type;
        public int damage;
        public int magazineSize;
        public int ammo;
        public float fireInterval;

        public WeaponData(WeaponType type, int damage, int magazineSize, float fireInterval)
        {
            this.type = type;
            this.damage = damage;
            this.magazineSize = magazineSize;
            this.ammo = magazineSize;
            this.fireInterval = fireInterval;
        }
    }

    public class WeaponLoadout : MonoBehaviour
    {
        [SerializeField] private Camera aimCamera;
        private WeaponData[] weapons;
        private int index;
        private float nextShot;

        public WeaponType CurrentType => weapons[index].type;
        public int CurrentAmmo => weapons[index].ammo;

        private void Awake()
        {
            weapons = new[]
            {
                new WeaponData(WeaponType.Pistol, 25, 12, 0.25f),
                new WeaponData(WeaponType.Shotgun, 60, 6, 0.8f),
                new WeaponData(WeaponType.Rifle, 18, 30, 0.1f)
            };
            if (aimCamera == null) aimCamera = Camera.main;
        }

        public void SelectWeapon(int slot)
        {
            if (slot < 0 || slot >= weapons.Length) return;
            index = slot;
        }

        public bool Fire()
        {
            if (Time.time < nextShot || weapons[index].ammo <= 0 || aimCamera == null) return false;
            nextShot = Time.time + weapons[index].fireInterval;
            weapons[index].ammo--;
            Ray ray = aimCamera.ViewportPointToRay(new Vector3(.5f, .5f));
            if (Physics.Raycast(ray, out RaycastHit hit, 80f))
                hit.collider.SendMessage("TakeDamage", weapons[index].damage, SendMessageOptions.DontRequireReceiver);
            return true;
        }

        public void Reload() => weapons[index].ammo = weapons[index].magazineSize;
    }
}
