using UnityEngine;
using QazaqCity.Player;

namespace QazaqCity.Vehicles
{
    public class VehicleEnterExit : MonoBehaviour
    {
        [SerializeField] private VehicleController vehicle;
        [SerializeField] private Transform seat;
        [SerializeField] private Transform exitPoint;
        [SerializeField] private float enterDistance = 3f;
        private PlayerMobileController player;
        private bool inside;

        public bool IsOccupied => inside;

        public void TryEnter(PlayerMobileController target)
        {
            if (inside || target == null || vehicle == null) return;
            if (Vector3.Distance(target.transform.position, transform.position) > enterDistance) return;

            player = target;
            player.gameObject.SetActive(false);
            if (seat != null) player.transform.SetPositionAndRotation(seat.position, seat.rotation);
            vehicle.SetControlled(true);
            inside = true;
        }

        public void SetVehicleInput(float throttle, float steering)
        {
            if (inside && vehicle != null) vehicle.SetInput(throttle, steering);
        }

        public void Exit()
        {
            if (!inside || player == null) return;
            vehicle.SetControlled(false);
            player.gameObject.SetActive(true);
            Transform point = exitPoint != null ? exitPoint : transform;
            player.transform.SetPositionAndRotation(point.position, point.rotation);
            inside = false;
            player = null;
        }
    }
}
