using UnityEngine;

namespace QazaqCity.NPC
{
    public class NPCController : MonoBehaviour
    {
        [SerializeField] private float speed = 1.8f;
        [SerializeField] private float radius = 12f;
        private Vector3 target;

        private void Start() => PickTarget();

        private void Update()
        {
            Vector3 flat = target - transform.position;
            flat.y = 0f;
            if (flat.magnitude < 0.5f) { PickTarget(); return; }
            transform.position += flat.normalized * speed * Time.deltaTime;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(flat), 5f * Time.deltaTime);
        }

        private void PickTarget()
        {
            Vector2 p = Random.insideUnitCircle * radius;
            target = transform.position + new Vector3(p.x, 0f, p.y);
        }
    }
}
