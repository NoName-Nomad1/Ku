using UnityEngine;
using System;

namespace QazaqCity.Player
{
    public class HealthSystem : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private Transform respawnPoint;
        public int Health { get; private set; }
        public event Action<int> HealthChanged;
        public bool IsDead => Health <= 0;

        private void Awake()
        {
            Health = maxHealth;
            HealthChanged?.Invoke(Health);
        }

        public void TakeDamage(int damage)
        {
            if (damage <= 0 || IsDead) return;
            Health = Mathf.Max(0, Health - damage);
            HealthChanged?.Invoke(Health);
            if (IsDead) Invoke(nameof(Respawn), 2f);
        }

        public void Heal(int amount)
        {
            if (amount <= 0 || IsDead) return;
            Health = Mathf.Min(maxHealth, Health + amount);
            HealthChanged?.Invoke(Health);
        }

        private void Respawn()
        {
            if (respawnPoint != null) transform.position = respawnPoint.position;
            Health = maxHealth;
            HealthChanged?.Invoke(Health);
        }
    }
}
