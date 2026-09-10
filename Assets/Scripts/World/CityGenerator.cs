using UnityEngine;

namespace QazaqCity.World
{
    public class CityGenerator : MonoBehaviour
    {
        [SerializeField] private int blocks = 6;
        [SerializeField] private float blockSize = 32f;
        [SerializeField] private float roadWidth = 8f;
        [SerializeField] private int buildingsPerBlock = 5;

        private void Start() => Generate();

        [ContextMenu("Қаланы жасау")]
        public void Generate()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
                Destroy(transform.GetChild(i).gameObject);

            float city = blocks * blockSize;
            CreatePrimitive("Жер", PrimitiveType.Cube, new Vector3(0, -0.6f, 0), new Vector3(city, 1, city));

            for (int x = -blocks / 2; x <= blocks / 2; x++)
            {
                CreatePrimitive("Жол", PrimitiveType.Cube, new Vector3(x * blockSize, -0.05f, 0), new Vector3(roadWidth, 0.1f, city));
                CreatePrimitive("Жол", PrimitiveType.Cube, new Vector3(0, -0.04f, x * blockSize), new Vector3(city, 0.1f, roadWidth));
            }

            for (int bx = -blocks / 2; bx < blocks / 2; bx++)
            for (int bz = -blocks / 2; bz < blocks / 2; bz++)
            for (int b = 0; b < buildingsPerBlock; b++)
            {
                float px = bx * blockSize + Random.Range(-blockSize / 2 + 5f, blockSize / 2 - 5f);
                float pz = bz * blockSize + Random.Range(-blockSize / 2 + 5f, blockSize / 2 - 5f);
                float h = Random.Range(5f, 22f);
                CreatePrimitive("Ғимарат", PrimitiveType.Cube, new Vector3(px, h / 2f, pz), new Vector3(Random.Range(5f, 9f), h, Random.Range(5f, 9f)));
            }
        }

        private GameObject CreatePrimitive(string name, PrimitiveType type, Vector3 position, Vector3 scale)
        {
            GameObject go = GameObject.CreatePrimitive(type);
            go.name = name;
            go.transform.SetParent(transform);
            go.transform.position = position;
            go.transform.localScale = scale;
            return go;
        }
    }
}
