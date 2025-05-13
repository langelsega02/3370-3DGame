using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBuildingSpawn : MonoBehaviour
{
    public GameObject[] buildingPrefabs; //array
    public GameObject coinPrefab;
    public GameObject skewedBuilding;
    public float spawnRate = 2f; // faster spawn for city look
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBuilding();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnBuilding();
            timer = 0;
        }
    }

    void SpawnBuilding()
    {
        int randomIndex1 = Random.Range(0, buildingPrefabs.Length);
        int randomSpawn1 = Random.Range(0, 10);
        int hazard = Random.Range(0, 4);

        GameObject selectedBuilding = buildingPrefabs[randomIndex1];


        if (hazard > 1)
        {
            //middle row
            if (randomIndex1 == 0)
            {
                Instantiate(selectedBuilding, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(new Vector3(-90, 0, 0)));
                if (randomSpawn1 == 9)
                {
                    Instantiate(coinPrefab, new Vector3(transform.position.x, transform.position.y + 15f, transform.position.z), Quaternion.Euler(new Vector3(-90, 0, 0)));
                }
            }
            else
            {
                Instantiate(selectedBuilding, new Vector3(transform.position.x + 1.5f, transform.position.y, transform.position.z + 1), Quaternion.Euler(new Vector3(-90, 0, 0)));
                if (randomSpawn1 == 9)
                {
                    Instantiate(coinPrefab, new Vector3(transform.position.x, transform.position.y + 15f, transform.position.z), Quaternion.Euler(new Vector3(-90, 0, 0)));
                }
            }
        }
        else if (hazard == 1)
        {
            Instantiate(skewedBuilding, new Vector3(transform.position.x-10f, transform.position.y, transform.position.z+7), Quaternion.Euler(new Vector3(-57, 90, 180)));
        }
        else
        {
            //do nothing so it has a gap
        }
    }
}
