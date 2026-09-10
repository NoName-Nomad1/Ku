using UnityEngine;

namespace QazaqCity.World
{
    public class RespawnPoint : MonoBehaviour
    {
        [SerializeField] private float radius = 2f;
        public Vector3 GetPoint() => transform.position + new Vector3(Random.Range(-radius, radius), 0f, Random.Range(-radius, radius));
    }
}
