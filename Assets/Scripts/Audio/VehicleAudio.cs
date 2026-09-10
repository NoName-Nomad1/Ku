using UnityEngine;

namespace QazaqCity.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class VehicleAudio : MonoBehaviour
    {
        [SerializeField] private AudioSource engine;
        [SerializeField] private Rigidbody vehicleBody;
        [SerializeField] private float minPitch = 0.8f;
        [SerializeField] private float maxPitch = 1.8f;
        [SerializeField] private float maxSpeed = 30f;

        private void Awake()
        {
            if (engine == null) engine = GetComponent<AudioSource>();
            if (vehicleBody == null) vehicleBody = GetComponentInParent<Rigidbody>();
            engine.loop = true;
        }

        private void Update()
        {
            if (vehicleBody == null) return;
            float speed = vehicleBody.linearVelocity.magnitude;
            engine.pitch = Mathf.Lerp(minPitch, maxPitch, Mathf.Clamp01(speed / maxSpeed));
            engine.volume = Mathf.Clamp01(0.2f + speed / maxSpeed);
        }
    }
}
