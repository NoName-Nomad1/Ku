using UnityEngine;

namespace QazaqCity.Audio
{
    public class GameAudioController : MonoBehaviour
    {
        [SerializeField] private AudioSource engineSource;
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource effectsSource;
        [SerializeField] private AudioClip engineLoop;

        private void Start()
        {
            if (engineSource != null && engineLoop != null)
            {
                engineSource.clip = engineLoop;
                engineSource.loop = true;
                engineSource.Play();
            }
        }

        public void SetEngine(float throttle)
        {
            if (engineSource == null) return;
            float t = Mathf.Clamp01(Mathf.Abs(throttle));
            engineSource.pitch = Mathf.Lerp(0.85f, 1.45f, t);
            engineSource.volume = Mathf.Lerp(0.15f, 0.85f, t);
        }

        public void PlayEffect(AudioClip clip)
        {
            if (effectsSource != null && clip != null)
                effectsSource.PlayOneShot(clip);
        }

        public void SetMusic(bool enabled)
        {
            if (musicSource == null) return;
            if (enabled && !musicSource.isPlaying) musicSource.Play();
            if (!enabled && musicSource.isPlaying) musicSource.Stop();
        }
    }
}
