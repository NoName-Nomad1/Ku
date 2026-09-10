using UnityEngine;

namespace QazaqCity.Map
{
    public class MiniMapSystem : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private RectTransform playerIcon;
        [SerializeField] private float mapWorldSize = 500f;
        [SerializeField] private float mapUiSize = 180f;

        private void LateUpdate()
        {
            if (player == null || playerIcon == null) return;
            Vector3 p = player.position;
            float x = Mathf.Clamp(p.x / mapWorldSize * mapUiSize, -mapUiSize * .5f, mapUiSize * .5f);
            float y = Mathf.Clamp(p.z / mapWorldSize * mapUiSize, -mapUiSize * .5f, mapUiSize * .5f);
            playerIcon.anchoredPosition = new Vector2(x, y);
            playerIcon.localRotation = Quaternion.Euler(0f, 0f, -player.eulerAngles.y);
        }

        public void SetPlayer(Transform target) => player = target;
    }
}
