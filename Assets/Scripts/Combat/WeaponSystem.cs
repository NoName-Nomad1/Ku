using UnityEngine;

namespace QazaqCity.Combat
{
    public class WeaponSystem : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float range = 60f;
        [SerializeField] private int damage = 25;
        [SerializeField] private LayerMask hitMask = ~0;

        public void Fire()
        {
            if (playerCamera == null) playerCamera = Camera.main;
            if (playerCamera == null) return;

            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (Physics.Raycast(ray, out RaycastHit hit, range, hitMask))
            {
                hit.collider.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
            }
        }
    }
}
