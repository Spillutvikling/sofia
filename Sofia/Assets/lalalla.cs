using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lalalla : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        float dx_door = 1.0f;
        float delta = Time.deltaTime;
        GameObject axel = gameObject;
        float speed = dx_door * delta;

        bool accel_x = true;
        axel.transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
	}
}
