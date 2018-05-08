using UnityEngine;
using System.Collections;

public class PlayerCamera : MonoBehaviour {


    protected Vector3 initialOffsetToTarget;
    public Vector3 _InitialOffsetToTarget { get { return this.initialOffsetToTarget; } }
    public GameObject player;

    [Header("Specific")]
    [SerializeField] private float _movementSmoothingFactor = 1.5f;

    private void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, this.player.transform.position - this.initialOffsetToTarget, Time.deltaTime * this._movementSmoothingFactor);
    }

    protected void Awake()
    {
        this.initialOffsetToTarget = this.player.transform.position - this.transform.position;
    }
}
