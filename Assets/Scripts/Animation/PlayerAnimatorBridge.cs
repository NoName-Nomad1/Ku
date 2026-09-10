using UnityEngine;
using QazaqCity.Player;

namespace QazaqCity.Animation
{
    public class PlayerAnimatorBridge : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerMobileController controller;
        [SerializeField] private string speedParameter = "Speed";
        [SerializeField] private string groundedParameter = "Grounded";
        [SerializeField] private string fireTrigger = "Fire";

        private void Awake()
        {
            if (animator == null) animator = GetComponentInChildren<Animator>();
            if (controller == null) controller = GetComponent<PlayerMobileController>();
        }

        private void Update()
        {
            if (animator == null || controller == null) return;
            animator.SetFloat(speedParameter, controller.GetMoveAmount(), 0.15f, Time.deltaTime);
            animator.SetBool(groundedParameter, controller.IsGrounded());
        }

        public void TriggerFire()
        {
            if (animator != null) animator.SetTrigger(fireTrigger);
        }
    }
}
