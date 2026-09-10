using UnityEngine;
using QazaqCity.Player;

namespace QazaqCity.Vehicles
{
    public class VehicleEnterExit : MonoBehaviour
    {
        [SerializeField] private VehicleController vehicle;
        [SerializeField] private Transform seat;
        [SerializeField] private float enterDistance = 3f;
        private PlayerMobileController player;
        private bool inside;

        public void TryEnter(PlayerMobileController target)
        {
            if (inside || target == null || vehicle == null) return;
            if (Vector3.Distance(target.transform.position, transform.position) > enterDistance) return;
            player = target;
            player.gameObject.SetActive(false);
            vehicle.SetControlled(true);
            inside = true;
        }

        public void Exit()
        {
            if (!inside || player == null) return;
            vehicle.SetControlled(false);
            player.gameObject.SetActive(true);
            player.transform.position = transform.position + transform.right * 2f;
            inside = false;
            player = null;
        }
    }
}
