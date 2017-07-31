using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviecamera : MonoBehaviour {

    public float speed = 10.0f;

    public float end_Z = -20;
	
	void Start () {
		
	}

	void Update () {
        if (transform.position.z < end_Z)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
	}
}
