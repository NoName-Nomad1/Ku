using UnityEngine;

namespace QazaqCity.Vehicles
{
    public class VehicleController : MonoBehaviour
    {
        [SerializeField] private float acceleration = 18f;
        [SerializeField] private float maxSpeed = 18f;
        [SerializeField] private float turnSpeed = 75f;
        private float throttle;
        private float steering;
        private float speed;
        private bool controlled;

        public void SetInput(float throttleInput, float steeringInput)
        {
            throttle = Mathf.Clamp(throttleInput, -1f, 1f);
            steering = Mathf.Clamp(steeringInput, -1f, 1f);
        }

        public void SetControlled(bool value) => controlled = value;

        private void Update()
        {
            if (!controlled) return;
            speed = Mathf.MoveTowards(speed, throttle * maxSpeed, acceleration * Time.deltaTime);
            transform.Rotate(0f, steering * turnSpeed * Mathf.Clamp01(Mathf.Abs(speed) / maxSpeed) * Time.deltaTime, 0f);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
