using UnityEngine;

namespace QazaqCity.Player
{
    public class PlayerHealthRespawn : MonoBehaviour
    {
        [SerializeField] private int maxHealth = 100;
        [SerializeField] private Transform respawnPoint;
        [SerializeField] private float respawnDelay = 2f;
        public int Health { get; private set; }
        private CharacterController controller;
        private bool respawning;

        private void Awake()
        {
            Health = maxHealth;
            controller = GetComponent<CharacterController>();
        }

        public void TakeDamage(int damage)
        {
            if (respawning || damage <= 0) return;
            Health = Mathf.Max(0, Health - damage);
            if (Health == 0) Invoke(nameof(Respawn), respawnDelay);
        }

        public void Heal(int amount) => Health = Mathf.Clamp(Health + Mathf.Max(0, amount), 0, maxHealth);

        private void Respawn()
        {
            if (respawnPoint != null)
            {
                if (controller != null) controller.enabled = false;
                transform.SetPositionAndRotation(respawnPoint.position, respawnPoint.rotation);
                if (controller != null) controller.enabled = true;
            }
            Health = maxHealth;
            respawning = false;
        }
    }
}
