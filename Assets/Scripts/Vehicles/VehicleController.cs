using UnityEngine;

namespace QazaqCity.Vehicles
{
    public class VehicleController : MonoBehaviour
    {
        [SerializeField] private float acceleration = 18f;
        [SerializeField] private float braking = 28f;
        [SerializeField] private float maxSpeed = 22f;
        [SerializeField] private float reverseSpeed = 8f;
        [SerializeField] private float turnSpeed = 85f;
        private float throttle;
        private float steering;
        private float speed;
        private bool controlled;

        public bool IsControlled => controlled;
        public float Speed => speed;

        public void SetInput(float throttleInput, float steeringInput)
        {
            throttle = Mathf.Clamp(throttleInput, -1f, 1f);
            steering = Mathf.Clamp(steeringInput, -1f, 1f);
        }

        public void SetControlled(bool value)
        {
            controlled = value;
            if (!value) SetInput(0f, 0f);
        }

        private void Update()
        {
            if (!controlled) return;

            float targetSpeed = throttle >= 0f ? throttle * maxSpeed : throttle * reverseSpeed;
            float rate = Mathf.Abs(throttle) < 0.01f ? braking : acceleration;
            speed = Mathf.MoveTowards(speed, targetSpeed, rate * Time.deltaTime);

            float steeringFactor = Mathf.Clamp01(Mathf.Abs(speed) / maxSpeed);
            transform.Rotate(0f, steering * turnSpeed * steeringFactor * Time.deltaTime, 0f);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
