using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardHealth : MonoBehaviour {

	public Camera billboardCamera;

	void Update()
	{
		transform.LookAt(transform.position + billboardCamera.transform.rotation * Vector3.back, billboardCamera.transform.rotation * Vector3.down);
	}
}
