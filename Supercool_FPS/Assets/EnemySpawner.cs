using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    float timeToNextSpawn = 0f;
    public float timeBetweenSpawns = 2f;
    public GameObject EnemyPrefab;
    //public Transform Ground;
    Transform[] spawnPoints;

    private void Awake()
    {
        spawnPoints = new Transform[GetActiveChildCount()];
        int i = 0;
        foreach (Transform child in transform)
        {
            if (child.gameObject.activeSelf)
            {
                Debug.Log("Appending " + child.name);
                spawnPoints[i] = child;
            }
        }
    }

    void Update()
    {
        if(Time.timeSinceLevelLoad >= timeToNextSpawn)
        {
            //TODO
            int currentSpawnIndex = Random.Range(0,spawnPoints.Length);
            Debug.Log("Spawning At: " + currentSpawnIndex);
            GameObject currentSpawn = Instantiate(EnemyPrefab,spawnPoints[currentSpawnIndex]);
            Rigidbody rb = currentSpawn.GetComponent<Rigidbody>();
            if(rb != null)
                rb.isKinematic = false;
            timeToNextSpawn += timeBetweenSpawns;
        }
    }

    int GetActiveChildCount()
    {
        int count = 0;
        foreach (Transform child in transform)
        {
            if(child.gameObject.activeSelf)
                count++;
        }
        return count;
    }
}
