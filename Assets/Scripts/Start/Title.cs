using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title : MonoBehaviour {

    public float speed = 1;
    public float timer = 2;
    Image title;

	void Start () {
        title = GetComponent<Image>();
	}
	
	void Update () {
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            title.color = new Color(title.color.r, title.color.g, title.color.b,
                title.color.a + Time.deltaTime * speed);
        }
    }
}
