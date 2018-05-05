using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {
    private GameObject Player;
    public float offsetX;
    public float offsetY;
    public float offsetZ;


    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

    }

    // Update is called once per frame
	void LateUpdate ()
    {
        offsetX = -8.58f;
        offsetY = 7f;
        offsetZ = -8.26f;
        transform.position = new Vector3(Player.transform.position.x + offsetX, Player.transform.position.y + offsetY, Player.transform.position.z + offsetZ);
    }
}
