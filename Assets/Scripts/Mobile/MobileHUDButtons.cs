using UnityEngine;
using QazaqCity.Vehicles;
using QazaqCity.Combat;

namespace QazaqCity.Mobile
{
    public class MobileHUDButtons : MonoBehaviour
    {
        [SerializeField] private VehicleController vehicle;
        [SerializeField] private WeaponSystem weapon;

        public void Gas() => vehicle?.SetInput(1f, 0f);
        public void Reverse() => vehicle?.SetInput(-1f, 0f);
        public void Brake() => vehicle?.SetInput(0f, 0f);
        public void SteerLeft(float value) => vehicle?.SetInput(value, -1f);
        public void SteerRight(float value) => vehicle?.SetInput(value, 1f);
        public void Shoot() => weapon?.Fire();
    }
}
