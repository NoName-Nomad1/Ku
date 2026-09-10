using UnityEngine;
using QazaqCity.Combat;

namespace QazaqCity.AI
{
    public class NPCCombatAI : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private float attackRange = 12f;
        [SerializeField] private float attackCooldown = 1.2f;
        [SerializeField] private int damage = 10;
        private float nextAttack;

        public void SetTarget(Transform value) => target = value;

        private void Update()
        {
            if (target == null) return;
            Vector3 delta = target.position - transform.position;
            delta.y = 0f;
            if (delta.sqrMagnitude > attackRange * attackRange) return;
            if (delta.sqrMagnitude > 0.01f)
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(delta), 10f * Time.deltaTime);
            if (Time.time < nextAttack) return;
            nextAttack = Time.time + attackCooldown;
            target.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }
    }
}
