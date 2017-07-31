using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 用于Pressanykey的缓慢显示以及闪烁播放
/// </summary>
public class Pressanykeytostart : MonoBehaviour {

    public float speed = 1;  //显示及闪烁速度
    public float timer = 2;  //延时显示时间
    Image key;   //获得pressanykey组件

    private bool anykeydown = false;  //用于判断是否有按键按下
    private bool flag = true;  //用于判断是缓慢消失还是显示 
    private GameObject button;  //获得开始游戏按钮的组件

    void Start () {
        key = gameObject.GetComponent<Image>();
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

    /// <summary>
    /// 判断是否按下任何键，按下便隐藏pressanykey，显示开始游戏的按钮
    /// </summary>
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
