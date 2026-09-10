using UnityEngine;

namespace QazaqCity.Player
{
    public class PlayerMobileController : MonoBehaviour
    {
        [Header("Қозғалыс")]
        [SerializeField] private float walkSpeed = 4f;
        [SerializeField] private float runSpeed = 7f;
        [SerializeField] private float rotationSpeed = 12f;
        [SerializeField] private Transform cameraTransform;

        private CharacterController controller;
        private Vector2 moveInput;
        private bool running;
        private float verticalVelocity;

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            if (cameraTransform == null && Camera.main != null)
                cameraTransform = Camera.main.transform;
        }

        // UI joystick осы әдісті шақырады.
        public void SetMoveInput(Vector2 input) => moveInput = Vector2.ClampMagnitude(input, 1f);
        public void SetRunning(bool value) => running = value;

        private void Update()
        {
            Vector3 forward = cameraTransform ? cameraTransform.forward : Vector3.forward;
            Vector3 right = cameraTransform ? cameraTransform.right : Vector3.right;
            forward.y = 0f;
            right.y = 0f;
            forward.Normalize();
            right.Normalize();

            Vector3 direction = (forward * moveInput.y + right * moveInput.x);
            if (direction.sqrMagnitude > 0.01f)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
            }

            if (controller.isGrounded) verticalVelocity = -2f;
            else verticalVelocity += Physics.gravity.y * Time.deltaTime;

            float speed = running ? runSpeed : walkSpeed;
            Vector3 velocity = direction * speed;
            velocity.y = verticalVelocity;
            controller.Move(velocity * Time.deltaTime);
        }
    }
}
