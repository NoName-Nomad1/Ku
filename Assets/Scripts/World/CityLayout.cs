using UnityEngine;

namespace QazaqCity.World
{
    public class CityLayout : MonoBehaviour
    {
        [SerializeField] private int gridSize = 8;
        [SerializeField] private float blockSize = 45f;
        [SerializeField] private float roadWidth = 12f;
        [SerializeField] private float buildingHeightMin = 8f;
        [SerializeField] private float buildingHeightMax = 30f;
        [SerializeField] private Transform cityRoot;
        [SerializeField] private Material roadMaterial;
        [SerializeField] private Material buildingMaterial;

        [ContextMenu("Generate City")]
        public void GenerateCity()
        {
            if (cityRoot == null) cityRoot = transform;
            for (int i = cityRoot.childCount - 1; i >= 0; i--)
                DestroyImmediate(cityRoot.GetChild(i).gameObject);

            float half = (gridSize - 1) * blockSize * 0.5f;
            for (int x = 0; x < gridSize; x++)
            {
                for (int z = 0; z < gridSize; z++)
                {
                    Vector3 center = new Vector3(x * blockSize - half, 0f, z * blockSize - half);
                    CreateRoad(center + Vector3.forward * (blockSize - roadWidth) * 0.5f, new Vector3(blockSize, .1f, roadWidth));
                    CreateRoad(center + Vector3.right * (blockSize - roadWidth) * 0.5f, new Vector3(roadWidth, .1f, blockSize));
                    CreateBuilding(center + new Vector3(9f, 0f, 9f), Random.Range(10f, 19f));
                    CreateBuilding(center + new Vector3(-9f, 0f, -9f), Random.Range(10f, 19f));
                }
            }
        }

        private void CreateRoad(Vector3 position, Vector3 scale)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name = "Жол";
            go.transform.SetParent(cityRoot);
            go.transform.position = position;
            go.transform.localScale = scale;
            if (roadMaterial != null) go.GetComponent<Renderer>().sharedMaterial = roadMaterial;
        }

        private void CreateBuilding(Vector3 position, float width)
        {
            float height = Random.Range(buildingHeightMin, buildingHeightMax);
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.name = "Ғимарат";
            go.transform.SetParent(cityRoot);
            go.transform.position = position + Vector3.up * height * .5f;
            go.transform.localScale = new Vector3(width, height, width);
            if (buildingMaterial != null) go.GetComponent<Renderer>().sharedMaterial = buildingMaterial;
        }
    }
}
