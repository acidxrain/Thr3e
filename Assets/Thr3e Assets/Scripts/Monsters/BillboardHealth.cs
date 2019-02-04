using UnityEngine;

public class BillboardHealth : MonoBehaviour {

	public Camera billboardCamera;

    private void Start()
    {
        billboardCamera = Camera.main;
    }

    void Update()
	{
		transform.LookAt(transform.position + billboardCamera.transform.rotation * Vector3.back, billboardCamera.transform.rotation * Vector3.down);
	}
}
