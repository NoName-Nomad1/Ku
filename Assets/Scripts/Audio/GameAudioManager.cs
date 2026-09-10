using UnityEngine;

namespace QazaqCity.Audio
{
    public class GameAudioManager : MonoBehaviour
    {
        public static GameAudioManager Instance { get; private set; }
        [SerializeField] private AudioSource musicSource;
        [SerializeField] private AudioSource sfxSource;
        [Range(0f, 1f)] [SerializeField] private float musicVolume = 0.65f;
        [Range(0f, 1f)] [SerializeField] private float sfxVolume = 0.85f;

        private void Awake()
        {
            if (Instance != null && Instance != this) { Destroy(gameObject); return; }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            ApplyVolumes();
        }

        public void PlaySfx(AudioClip clip)
        {
            if (clip == null || sfxSource == null) return;
            sfxSource.PlayOneShot(clip, sfxVolume);
        }

        public void PlayMusic(AudioClip clip, bool loop = true)
        {
            if (clip == null || musicSource == null) return;
            musicSource.loop = loop;
            musicSource.clip = clip;
            musicSource.volume = musicVolume;
            musicSource.Play();
        }

        public void SetMusicVolume(float value) { musicVolume = Mathf.Clamp01(value); ApplyVolumes(); }
        public void SetSfxVolume(float value) => sfxVolume = Mathf.Clamp01(value);

        private void ApplyVolumes()
        {
            if (musicSource != null) musicSource.volume = musicVolume;
            if (sfxSource != null) sfxSource.volume = sfxVolume;
        }
    }
}
