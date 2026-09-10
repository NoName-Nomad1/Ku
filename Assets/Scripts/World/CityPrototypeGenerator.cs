using UnityEngine;

namespace QazaqCity.World
{
    public class CityPrototypeGenerator : MonoBehaviour
    {
        [SerializeField] private int blocks = 5;
        [SerializeField] private float blockSize = 24f;
        [SerializeField] private float roadWidth = 8f;
        [SerializeField] private int seed = 2026;

        private void Start()
        {
            Random.InitState(seed);
            Generate();
        }

        private void Generate()
        {
            CreatePrimitive("Жер", PrimitiveType.Plane, new Vector3(0, -0.05f, 0), new Vector3(8, 1, 8));
            float total = blocks * blockSize;
            for (int x = -blocks; x <= blocks; x++)
            {
                CreatePrimitive("Жол", PrimitiveType.Cube, new Vector3(x * blockSize, 0, 0), new Vector3(roadWidth, 0.12f, total));
            }
            for (int z = -blocks; z <= blocks; z++)
            {
                CreatePrimitive("Жол", PrimitiveType.Cube, new Vector3(0, 0.01f, z * blockSize), new Vector3(total, 0.12f, roadWidth));
            }
            for (int x = -blocks; x < blocks; x++)
            for (int z = -blocks; z < blocks; z++)
            {
                float px = x * blockSize + blockSize * 0.5f;
                float pz = z * blockSize + blockSize * 0.5f;
                float h = Random.Range(5f, 18f);
                CreatePrimitive("Ғимарат", PrimitiveType.Cube, new Vector3(px, h * 0.5f, pz), new Vector3(10f, h, 10f));
            }
        }

        private static GameObject CreatePrimitive(string objectName, PrimitiveType type, Vector3 position, Vector3 scale)
        {
            var go = GameObject.CreatePrimitive(type);
            go.name = objectName;
            go.transform.position = position;
            go.transform.localScale = scale;
            return go;
        }
    }
}
