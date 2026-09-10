using UnityEngine;

namespace QazaqCity.Police
{
    public class PoliceSystem : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private float wantedRadius = 35f;
        [SerializeField] private float chaseSpeed = 4.5f;
        [SerializeField] private int wantedLevel;

        public int WantedLevel => wantedLevel;

        public void AddWantedLevel(int amount = 1)
        {
            wantedLevel = Mathf.Clamp(wantedLevel + amount, 0, 5);
        }

        public void ClearWantedLevel() => wantedLevel = 0;

        private void Update()
        {
            if (player == null || wantedLevel <= 0) return;
            Vector3 direction = player.position - transform.position;
            direction.y = 0f;
            if (direction.magnitude > wantedRadius) return;
            transform.position += direction.normalized * chaseSpeed * Time.deltaTime;
            if (direction.sqrMagnitude > 0.1f)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 5f * Time.deltaTime);
        }
    }
}
