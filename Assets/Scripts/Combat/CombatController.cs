using UnityEngine;

namespace QazaqCity.Combat
{
    public class CombatController : MonoBehaviour
    {
        [SerializeField] private WeaponInventory inventory;
        [SerializeField] private Camera aimCamera;
        [SerializeField] private float range = 60f;
        [SerializeField] private LayerMask hitMask = ~0;
        [SerializeField] private float fireCooldown = 0.2f;
        private float nextFire;

        public void Fire()
        {
            if (Time.time < nextFire || inventory == null || !inventory.ConsumeAmmo()) return;
            nextFire = Time.time + fireCooldown;
            if (aimCamera == null) aimCamera = Camera.main;
            if (aimCamera == null) return;
            Ray ray = aimCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out RaycastHit hit, range, hitMask))
                hit.collider.SendMessage("TakeDamage", inventory.Current.damage, SendMessageOptions.DontRequireReceiver);
        }
    }
}
