using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pressanykeytostart : MonoBehaviour {

    public float speed = 1;
    public float timer = 2;
    Image key;

    private bool anykeydown = false;
    private bool flag = true;
    private GameObject button;

    void Start () {
        key = GetComponent<Image>();
        button = this.transform.parent.Find("Button").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            if (flag == true)
            {
                key.color = new Color(key.color.r, key.color.g, key.color.b,
                  key.color.a + Time.deltaTime * speed);
                if (key.color.a >= 1)
                    flag = false;
            }

            if (flag == false)
            {
                key.color = new Color(key.color.r, key.color.g, key.color.b,
                  key.color.a - Time.deltaTime * speed);
                if (key.color.a <= 0)
                    flag = true;
            }

            ShowBotton();

        }
    }

    void ShowBotton()
    {
        if(Input.anyKey)
        {
            gameObject.SetActive(false);
            button.SetActive(true);
            anykeydown = true;
        }
    }
}
