using UnityEngine;

namespace QazaqCity.AI
{
    public class PoliceChaseAI : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float chaseSpeed = 5f;
        [SerializeField] private float stopDistance = 3f;
        [SerializeField] private float detectionRange = 45f;

        public void SetTarget(Transform value) => target = value;

        private void Update()
        {
            if (target == null) return;
            Vector3 delta = target.position - transform.position;
            delta.y = 0f;
            if (delta.sqrMagnitude > detectionRange * detectionRange) return;
            if (delta.magnitude <= stopDistance) return;
            Vector3 direction = delta.normalized;
            transform.position += direction * chaseSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 8f * Time.deltaTime);
        }
    }
}
