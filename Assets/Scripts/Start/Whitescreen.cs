using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Whitescreen : MonoBehaviour {

    public float speed = 3;
    public  float timer = 1;
    Image whitescreen;
	
	void Start () {
        whitescreen = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            whitescreen.color = new Color(whitescreen.color.r, whitescreen.color.g, whitescreen.color.b,
                whitescreen.color.a - Time.deltaTime * speed);
        }
        
	}
}
