using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 用于题目的从无到有的缓慢显示
/// </summary>
public class Title : MonoBehaviour {

    public float speed = 1;  //显示速度
    public float timer = 2;  //延时多少秒开始显示
    Image title;

	void Start () {
        title = GetComponent<Image>();
	}
	
	void Update () {
        timer = timer - Time.deltaTime;
        if (timer < 0)
        {
            //因为color是一个const 无法直接复制，需要通过new进行赋值
            title.color = new Color(title.color.r, title.color.g, title.color.b,
                title.color.a + Time.deltaTime * speed);
        }
    }
}
