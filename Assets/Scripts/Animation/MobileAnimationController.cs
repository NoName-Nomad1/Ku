using UnityEngine;

namespace QazaqCity.Animation
{
    public class MobileAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator animator;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float smoothing = 8f;

        private float speed;
        private bool grounded;

        private void Awake()
        {
            if (animator == null) animator = GetComponentInChildren<Animator>();
            if (characterController == null) characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            if (animator == null) return;
            Vector3 v = characterController != null ? characterController.velocity : Vector3.zero;
            speed = Mathf.Lerp(speed, new Vector3(v.x, 0f, v.z).magnitude, smoothing * Time.deltaTime);
            grounded = characterController == null || characterController.isGrounded;
            animator.SetFloat("Speed", speed);
            animator.SetBool("Grounded", grounded);
            animator.SetBool("Running", speed > 5.5f);
        }

        public void SetShooting(bool value)
        {
            if (animator != null) animator.SetBool("Shooting", value);
        }
    }
}
