using UnityEngine;
using System.Collections;


//[ExecuteInEditMode]
public class Procedural_Generation : MonoBehaviour {

    private GameObject container1;
    private GameObject container2;
    private GameObject container3;
    private GameObject container4;


    [Space(10)]
    [Header("The Size Of The Spawn Area")]
    //bounds
    public Vector3 origin;
    [Range(0.0f, 500.0f)]
    public float spawnRadius;


    [Space(10)]
    [Header("Objects To Be Spawned")]
    public GameObject[] group1;
    public GameObject[] group2;
    public GameObject[] group3;
    public GameObject[] group4;

    [Space(10)]
    [Header("How Many Objects You Want Spawned")]
    public int maxNumOfGroupOneObjs;
	public int maxNumOfGroupTwoObjs;
    public int maxNumOfGroupThreeObjs;
    public int maxNumOfGroupFourObjs;



    //temp instances
    private GameObject randOne;
    private GameObject randTwo;
    private GameObject randThree;
    private GameObject randFour;

	//random placement
    private int randNum;
    private float randX;
    private float randZ;

    private Ray detector1;
    private Ray detector2;
    private Ray detector3;
    private Ray detector4;

    private float rangeMinX;
    private float rangeMaxX;
    private float rangeMinZ;
    private float rangeMaxZ;
    private float lengthX;
    private float lengthZ;

    private Vector3 randOnePlacer;
	private Vector3 randTwoPlacer;
	private Vector3 randThreePlacer;
	private Vector3 randFourPlacer;

    [Space(10)]
    [Header("How Much Space To Give Objects")]
    [Range(0.0f, 50.0f)]
    public float groupOneMargin;
    [Range(0.0f, 50.0f)]
    public float groupTwoMargin;
    [Range(0.0f, 50.0f)]
    public float groupThreeMargin;
    [Range(0.0f, 50.0f)]
    public float groupFourMargin;



    [Space(10)]
    [Header("Misc Settings")]
    public bool terrainIsOneObject;
    public bool terrainIsTiles;

    [Space(10)]
    public int highestPointInTerrain = 75;

    [Space(10)]
    public float spawnInterval = .1f;

    [Space(10)]
    public bool SpawnInfinitely;
    public bool stopSpawning = false;

    [Space(10)]
    [Header("How Many Have Been Spawned")]
    public int groupOneSpawned;
    public int groupTwoSpawned;
    public int groupThreeSpawned;
    public int groupFourSpawned;

    void Start() 
	{
        if (GameObject.Find("Group1Container"))
        {
            container2 = GameObject.Find("Group1Container");
        }
        else
        {
            container2 = new GameObject();
            container2.name = "Group1Container";
            container2.transform.parent = transform;
        }

        if (GameObject.Find("Group2Container"))
        {
            container1 = GameObject.Find("Group2Container");
        }
        else
        {
            container1 = new GameObject();
            container1.name = "Group2Container";
            container1.transform.parent = transform;
        }

        if (GameObject.Find("Group3Container"))
        {
            container3 = GameObject.Find("Group3Container");
        }
        else
        {
            container3 = new GameObject();
            container3.name = "Group3Container";
            container3.transform.parent = transform;
        }

        if (GameObject.Find("Group4Container"))
        {
            container4 = GameObject.Find("Group4Container");
        }
        else
        {
            container4 = new GameObject();
            container4.name = "Group4Container";
            container4.transform.parent = transform;
        }

        if(terrainIsTiles)
        {
            StartCoroutine(detectEdgesFromOrigin());
        }

        if(terrainIsOneObject)
        {
            StartCoroutine(detectEdgesFromProbes());
        }
	}

    IEnumerator spawnObject()
    {
        while(!stopSpawning)
        {
        //Places Group1Container
        if (groupOneSpawned < maxNumOfGroupOneObjs || SpawnInfinitely == true)
        {
            randX = Random.Range(rangeMinX, rangeMaxX);
            randZ = Random.Range(rangeMinZ, rangeMaxZ);

            randNum = Random.Range(0, group1.Length);

            randOne = group1[randNum];

            detector1 = new Ray(new Vector3(randX, highestPointInTerrain, randZ) + transform.position, Vector3.down);

            RaycastHit hit;

            if (Physics.Raycast(detector1, out hit, 1000f))
            {
                Debug.DrawLine(detector1.origin, hit.point);
                randOnePlacer = hit.point;
            }

            if (hit.collider.gameObject.tag == "Ground")
            {
                bool tooTight1 = false;

                Collider[] adjacentObjects1 = Physics.OverlapSphere(hit.point, groupOneMargin);
                foreach (Collider x in adjacentObjects1)
                {
                        if (x.gameObject.tag != "Ground" && x.gameObject.tag != "Wall")
                        {
                            if (Vector3.Distance(x.transform.position, hit.point) < groupOneMargin)
                            {
                                tooTight1 = true;
                            }
                        }
                }

                if (!tooTight1)
                {
                    GameObject tempObj1 = Instantiate(randOne, randOnePlacer, Quaternion.identity) as GameObject;
                    tempObj1.transform.parent = container1.transform;
                    groupOneSpawned = groupOneSpawned + 1;
                }
            }
        }


        //Place Group2Container
        if (groupTwoSpawned < maxNumOfGroupTwoObjs || SpawnInfinitely == true)
        {
            randX = Random.Range(rangeMinX, rangeMaxX);
            randZ = Random.Range(rangeMinZ, rangeMaxZ);

            randNum = Random.Range(0, group2.Length);

            randTwo = group2[randNum];

            detector2 = new Ray(new Vector3(randX, highestPointInTerrain, randZ) + transform.position, Vector3.down);

            //			detector = new Vector3 (randX, highestPointInTerrain, randZ);

            RaycastHit hit2;

            if (Physics.Raycast(detector2, out hit2, highestPointInTerrain + 5f))
            {
                Debug.DrawLine(detector2.origin, hit2.point);
                randTwoPlacer = hit2.point;
            }



            if (hit2.collider.gameObject.tag == "Ground")
            {
                bool tooTight2 = false;

                Collider[] adjacentObjects2 = Physics.OverlapSphere(hit2.point, groupTwoMargin);
                foreach (Collider x in adjacentObjects2)
                {
                        if (x.gameObject.tag != "Ground" && x.gameObject.tag != "Wall")
                        {
                            if (Vector3.Distance(x.transform.position, hit2.point) < groupTwoMargin)
                            {
                                tooTight2 = true;
                            }
                        }
                }

                if(!tooTight2)
                    {
                        GameObject tempObj2 = Instantiate(randTwo, randTwoPlacer, Quaternion.identity) as GameObject;
                        tempObj2.transform.parent = container2.transform;
                        groupTwoSpawned = groupTwoSpawned + 1;
                    }
            }
        }

        //Places Group3Container
        if (groupThreeSpawned < maxNumOfGroupThreeObjs || SpawnInfinitely == true)
        {
            randX = Random.Range(rangeMinX, rangeMaxX);
            randZ = Random.Range(rangeMinZ, rangeMaxZ);

            randNum = Random.Range(0, group3.Length);

            randThree = group3[randNum];

            detector3 = new Ray(new Vector3(randX, highestPointInTerrain, randZ) + transform.position, Vector3.down);

            //			detector = new Vector3 (randX, highestPointInTerrain, randZ);

            RaycastHit hit3;

            if (Physics.Raycast(detector3, out hit3, highestPointInTerrain + 5f))
            {
                Debug.DrawLine(detector3.origin, hit3.point);
                randThreePlacer = hit3.point;
            }

            if (hit3.collider.gameObject.tag == "Ground")
            {
                    bool tooTight = false;

                    Collider[] adjacentObjects3 = Physics.OverlapSphere(hit3.point, groupThreeMargin);
                    foreach(Collider x in adjacentObjects3)
                    {
                        if (x.gameObject.tag != "Ground" && x.gameObject.tag != "Wall")
                        {
                            if (Vector3.Distance(x.transform.position, hit3.point) < groupThreeMargin)
                            {
                                tooTight = true;
                            }
                        }
                    }

                    if(!tooTight)
                    {
                        GameObject tempObj3 = Instantiate(randThree, randThreePlacer, Quaternion.identity) as GameObject;
                        tempObj3.transform.parent = container3.transform;
                        groupThreeSpawned = groupThreeSpawned + 1;
                    }
            }
        }

        //Places Group4Container
        if (groupFourSpawned < maxNumOfGroupFourObjs || SpawnInfinitely == true)
        {
            randX = Random.Range(rangeMinX, rangeMaxX);
            randZ = Random.Range(rangeMinZ, rangeMaxZ);

            randNum = Random.Range(0, group4.Length);

            randFour = group4[randNum];
           
            detector4 = new Ray(new Vector3(randX, highestPointInTerrain, randZ) + transform.position, Vector3.down);

            //			detector = new Vector3 (randX, highestPointInTerrain, randZ);

            RaycastHit hit4;

            if (Physics.Raycast(detector4, out hit4, highestPointInTerrain + 5f))
            {
                Debug.DrawLine(detector4.origin, hit4.point);
                randFourPlacer = hit4.point;
            }

            if (hit4.collider.gameObject.tag == "Ground")
                {
                    bool tooTight4 = false;

                    Collider[] adjacentObjects4 = Physics.OverlapSphere(hit4.point, groupFourMargin);
                    foreach (Collider x in adjacentObjects4)
                    {
                        if(x.gameObject.tag != "Ground" && x.gameObject.tag != "Wall")
                        {
                            if (Vector3.Distance(x.transform.position, hit4.point) < groupFourMargin)
                            {
                                tooTight4 = true;
                            }
                        }
                    }

                    if (!tooTight4)
                    {
                        GameObject tempObj4 = Instantiate(randFour, randFourPlacer, Quaternion.identity) as GameObject;
                        tempObj4.transform.parent = container4.transform;
                        groupFourSpawned = groupFourSpawned + 1;
                    }
            }
        }
        yield return new WaitForSeconds(spawnInterval);

            if (groupOneSpawned == maxNumOfGroupOneObjs && groupTwoSpawned == maxNumOfGroupTwoObjs && groupThreeSpawned == maxNumOfGroupThreeObjs && groupFourSpawned == maxNumOfGroupFourObjs && SpawnInfinitely == false)
            {
                stopSpawning = true;
            }
        }
    }

    IEnumerator detectEdgesFromOrigin()
    {
        rangeMaxX = origin.x + spawnRadius;
        rangeMinX = origin.x - spawnRadius;
        rangeMaxZ = origin.z + spawnRadius;
        rangeMinZ = origin.z - spawnRadius;

        StartCoroutine(spawnObject());
        yield return null;
    }

    IEnumerator detectEdgesFromProbes()
    {
        bool edgeXAcquired = false;
        bool edgeZAcquired = false;
        bool edgesAcquired = false;
        float currentPointX = 0;
        float currentPointZ = 0;

        while(edgesAcquired == false)
        {
            Ray edgeDetectorX = new Ray(new Vector3(currentPointX, highestPointInTerrain, 0) + transform.position, Vector3.down);
            Ray edgeDetectorZ = new Ray(new Vector3(0, highestPointInTerrain, currentPointZ) + transform.position, Vector3.down);

            RaycastHit hit;

            if (Physics.Raycast(edgeDetectorX, out hit, highestPointInTerrain + 5f))
            {
                Debug.DrawLine(edgeDetectorX.origin, hit.point);
                randFourPlacer = hit.point;

                if (hit.collider.gameObject.tag == "Ground")
                {
                    currentPointX++;
                }
                else
                {
                    lengthX = (currentPointX) * 2;
                    edgeXAcquired = true;
                }
            }
            else
            {
                lengthX = (currentPointX) * 2;
                edgeXAcquired = true;
            }

            if (Physics.Raycast(edgeDetectorZ, out hit, highestPointInTerrain + 5f))
            {
                Debug.DrawLine(edgeDetectorZ.origin, hit.point);
                randFourPlacer = hit.point;

                if (hit.collider.gameObject.tag == "Ground")
                {
                    currentPointZ++;
                }
                else
                {
                    lengthZ = (currentPointZ) * 2;
                    edgeZAcquired = true;
                }
            }
            else
            {
                lengthZ = (currentPointZ) * 2;
                edgeZAcquired = true;
            }

            if(edgeXAcquired == true && edgeZAcquired == true)
            {
                rangeMinX = -(lengthX / 2) + 1;
                rangeMaxX = (lengthX / 2) - 1;
                rangeMinZ = -(lengthZ / 2) + 1;
                rangeMaxZ = (lengthZ / 2) - 1;
                edgesAcquired = true;
            }

            StartCoroutine(spawnObject());
            yield return null;
        }

    }
}
