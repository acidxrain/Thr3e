using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterSpawner : MonoBehaviour
{

    [SerializeField]
    public GameObject[] monsterPrefab;
    [Range(1, 100)] // Creates a slider with min+max values.
    public int clusterSizeMin; // Specifies the minimum amount of monsters the generator can spawn.
    [Range(1, 100)] 
    public int clusterSizeMax; // Specifies the maximum amount of monster the generator can spawn.
    [Range(-100.0f, 100.0f)]
    public float clusterDistanceMinX; // Specifies the minimum distance between each monster that another monster can spawn.
    [Range(-100.0f, 100.0f)] 
    public float clusterDistanceMaxX; // Specifies the minimum distance between each monster that another monster can spawn.
    [Range(-100.0f, 100.0f)] 
    public float clusterDistanceMinZ; // Specifies the minimum distance between each monster that another monster can spawn.
    [Range(-100.0f, 100.0f)]
    public float clusterDistanceMaxZ; // Specidies the maximum distance between each monster that another monster can spawn.
    [Range(-100.0f, 100.0f)]
    public float monsterYDifference; // A random value on the Y plane to specify how high or low monsters should spawn.

    public int amountOfMonstersToSpawn; // A random value between min and max cluster size.
    private float distanceBetweenEachMonsterX; // A random value between min and max distance X to spawn monsters away from others in a cluster.
    private float distanceBetweenEachMonsterZ; // A random value between min and max distance Z to spawn monsters away from others in a cluster.

    private Vector3 monsterSpawnVector; // The Vector3 that will delegate spawning positions for monsters.

    private Ray checkForGround; // The raycast that checks for ground.
    public LayerMask layerToSpawnMonsters; // The layer used by the generator to spawn monsters.
    private GameObject goThatWasHit; // The gameObject that was hit by the ray that checks for ground.

    private void Start()
    {
        SpawnMonster();
    }

    public void SpawnMonster()
    {
        // Find a random range between the min and max value for the amount of monsters our cluster will have.
        amountOfMonstersToSpawn = Random.Range(clusterSizeMin, clusterSizeMax);
        Debug.Log("The cluster size will be " + amountOfMonstersToSpawn);

        RaycastHit hit;

        // Change each Vector3 position and cast the amount of rays random to the min and max cluster size
        for (int i = amountOfMonstersToSpawn; i < clusterSizeMax; i++)
        {
            // Find a random range between the min and max values of the X and Z planes to spawn monsters at.
            distanceBetweenEachMonsterX = Random.Range(clusterDistanceMinX, clusterDistanceMaxX);
            distanceBetweenEachMonsterZ = Random.Range(clusterDistanceMinZ, clusterDistanceMaxZ);

            RandomVector3();


            Debug.Log("Casting spawn rays...");
            if (Physics.Raycast(transform.position, monsterSpawnVector, out hit))
            {
                Debug.DrawRay(transform.position, monsterSpawnVector, Color.red, 60);
                //check if we hit ground
                int goThatWasHit = hit.collider.gameObject.layer;
                Debug.Log("We hit " + goThatWasHit);

                if (goThatWasHit == Mathf.Log(layerToSpawnMonsters.value, 2))
                {
                    Debug.Log("Spawning Monster!");
                    foreach (var monster in monsterPrefab)
                    {
                        if (amountOfMonstersToSpawn < clusterSizeMax)
                        {
                            monsterSpawnVector.y = 0;
                            Instantiate(monster, monsterSpawnVector, Quaternion.identity);
                            Debug.Log("Monster Spawned!");
                        }
                        else
                        {
                            Debug.Log("Max cluser size reached... stop spawning!");
                        }
                    }
                }
                else
                {
                    // Attempt to find a spawn 99 times.
                    for (int a = 1; a < 99;)
                    {
                        if (Physics.Raycast(transform.position, monsterSpawnVector, out hit))
                        {
                            Debug.DrawRay(transform.position, monsterSpawnVector, Color.red, 60);
                            // Check if we hit ground.
                            goThatWasHit = hit.collider.gameObject.layer;
                            Debug.Log("We hit " + goThatWasHit);
                            if (goThatWasHit == Mathf.Log(layerToSpawnMonsters.value, 2))
                            {
                                Debug.Log("Spawning monster!");
                                var monster = monsterPrefab[Random.Range(0, monsterPrefab.Length)];
                                Instantiate(monster, monsterSpawnVector, Quaternion.identity);
                                Debug.Log("Monster spawned!");
                            }
                            else
                            {
                                Debug.Log("Didn't find a suitable place to spawn. Trying again, up to 99 times...");
                                monsterSpawnVector = RandomVector3();
                                a++;
                            }
                        }
                        else
                        {
                            Debug.Log("Didn't hit anything, trying again...");
                        }
                    }
                    Debug.Log("Failed to find a suitable location to place monster");
                    Debug.Log("Layer we hit: " + goThatWasHit + " Layer we want to spawn on:" + Mathf.Log(layerToSpawnMonsters.value, 2));
                }
            }
        }
    }

    Vector3 RandomVector3()
    {
        // After randomizing, set the random values into the Vector3.
        monsterSpawnVector.x = distanceBetweenEachMonsterX;
        monsterSpawnVector.y = monsterYDifference;
        monsterSpawnVector.z = distanceBetweenEachMonsterZ;
        return new Vector3(monsterSpawnVector.x, monsterSpawnVector.y, monsterSpawnVector.z);
    }
}
