using UnityEngine;

namespace QazaqCity.Vehicles
{
    [RequireComponent(typeof(Rigidbody))]
    public class VehicleRigidbodyController : MonoBehaviour
    {
        [SerializeField] private float motorForce = 850f;
        [SerializeField] private float maxSpeed = 24f;
        [SerializeField] private float steeringTorque = 6f;
        [SerializeField] private float brakeForce = 1100f;

        private Rigidbody rb;
        private float throttle;
        private float steering;
        private bool braking;
        private bool active;

        private void Awake() => rb = GetComponent<Rigidbody>();

        public void SetInput(float throttleInput, float steeringInput, bool brake = false)
        {
            throttle = Mathf.Clamp(throttleInput, -1f, 1f);
            steering = Mathf.Clamp(steeringInput, -1f, 1f);
            braking = brake;
        }

        public void SetActive(bool value) => active = value;

        private void FixedUpdate()
        {
            if (!active) return;
            Vector3 localVelocity = transform.InverseTransformDirection(rb.linearVelocity);
            if (localVelocity.z < maxSpeed || throttle < 0f)
                rb.AddForce(transform.forward * throttle * motorForce, ForceMode.Force);

            float steerPower = steering * steeringTorque * Mathf.Clamp01(Mathf.Abs(localVelocity.z) / 4f);
            rb.AddTorque(Vector3.up * steerPower, ForceMode.Force);

            if (braking)
                rb.AddForce(-rb.linearVelocity.normalized * brakeForce, ForceMode.Force);
        }
    }
}
