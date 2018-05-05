using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Globes : MonoBehaviour {
    public Slider healthSlider;
    public float refillSpeed = 0.3f;
    public bool refilling;

	// Use this for initialization
	void Start ()
    {
        healthSlider = GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        if (refilling) {
            healthSlider.value = healthSlider.value < 1 ? healthSlider.value + (refillSpeed * Time.deltaTime) : healthSlider.value;
            if (healthSlider.value >= 1) {
                refilling = false;
            }
        }

        if (Input.GetKeyDown("q")) {
                healthSlider.value = healthSlider.value - 0.1f;
        }

        if (Input.GetKeyDown("q")) {
                refilling = true;
            }	
        }
}
