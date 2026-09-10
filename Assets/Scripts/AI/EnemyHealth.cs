using UnityEngine;

namespace QazaqCity.AI
{
    public class EnemyHealth : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        public int Health { get; private set; }

        private void Awake() => Health = maxHealth;

        public void TakeDamage(int damage)
        {
            if (damage <= 0 || Health <= 0) return;
            Health = Mathf.Max(0, Health - damage);
            if (Health == 0) Die();
        }

        private void Die()
        {
            SendMessage("OnEnemyDefeated", SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject, 2f);
        }
    }
}
