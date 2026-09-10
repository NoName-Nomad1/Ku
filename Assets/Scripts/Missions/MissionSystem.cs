using UnityEngine;
using QazaqCity.UI;
using QazaqCity.Economy;

namespace QazaqCity.Missions
{
    public class MissionSystem : MonoBehaviour
    {
        [SerializeField] private KazakhUI hud;
        [SerializeField] private WalletSystem wallet;
        [SerializeField] private Transform target;
        [SerializeField] private float targetDistance = 4f;
        [SerializeField] private int reward = 500;

        private int missionIndex;
        private readonly string[] missions =
        {
            "1. Қалаға кір", "2. Көлікке отыр", "3. Белгіленген жерге бар", "4. Тапсырманы аяқта"
        };

        private void Start() => UpdateHud();

        private void Update()
        {
            if (target == null || missionIndex >= missions.Length) return;
            if (Vector3.Distance(transform.position, target.position) <= targetDistance)
                CompleteMission();
        }

        public void CompleteMission()
        {
            if (missionIndex >= missions.Length) return;
            missionIndex++;
            if (wallet != null) wallet.AddMoney(reward);
            UpdateHud();
        }

        private void UpdateHud()
        {
            if (hud == null) return;
            if (wallet != null) hud.SetMoney(wallet.Money);
            hud.SetMission(missionIndex < missions.Length ? missions[missionIndex] : $"Миссия орындалды! +{reward} ₸");
        }
    }
}
