using UnityEngine;

namespace QazaqCity.Optimization
{
    public class MobilePerformanceController : MonoBehaviour
    {
        [SerializeField] private int targetFps = 60;
        [SerializeField] private int mobileLodBias = 1;

        private void Awake()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = Mathf.Clamp(targetFps, 30, 120);
            QualitySettings.lodBias = Mathf.Clamp(mobileLodBias, 0.25f, 2f);
            QualitySettings.maximumLODLevel = 1;
        }
    }
}
