using UnityEngine;
using QazaqCity.UI;

namespace QazaqCity.Missions
{
    public class MissionSystem : MonoBehaviour
    {
        [SerializeField] private KazakhUI hud;
        [SerializeField] private Transform target;
        [SerializeField] private float targetDistance = 4f;
        private int missionIndex;
        private int money;
        private readonly string[] missions =
        {
            "1. Қалаға кір", "2. Көлікке отыр", "3. Белгіленген жерге бар", "4. Тапсырманы аяқта"
        };

        private void Start()
        {
            missionIndex = 0;
            UpdateHud();
        }

        private void Update()
        {
            if (target == null || missionIndex >= missions.Length) return;
            if (Vector3.Distance(transform.position, target.position) <= targetDistance)
            {
                missionIndex++;
                money += 500;
                UpdateHud();
            }
        }

        public void CompleteMission()
        {
            if (missionIndex >= missions.Length) return;
            missionIndex++;
            money += 500;
            UpdateHud();
        }

        private void UpdateHud()
        {
            if (hud == null) return;
            hud.SetMoney(money);
            hud.SetMission(missionIndex < missions.Length ? missions[missionIndex] : "Миссия орындалды! +500 ₸");
        }
    }
}
