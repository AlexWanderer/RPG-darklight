using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private Transform player;
    private Vector3 offsetposition;  //玩家与摄像机之间的偏移
    private bool isRotaing = false;

    public float rotaSpeed = 1;
    public float distance = 0;
    public float scrollSpeed = 5;  //视角拉近拉远的速度
    public float maxdistance = 18;   //视角拉远最大距离
    public float mindistance = 3;  //视角拉近最小距离

	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player);
        offsetposition = player.position - transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = player.position - offsetposition;

        RotaView();
        ScrollView();
        

    }

    /// <summary>
    /// 通过滑轮控制视角拉近拉远
    /// </summary>
    void ScrollView()
    {
        distance = offsetposition.magnitude; //位置偏移的大小就是距离
        float ScrollWheel = Input.GetAxis("Mouse ScrollWheel");
        distance -= ScrollWheel * scrollSpeed;
        distance = Mathf.Clamp(distance, mindistance, maxdistance);//将distance控制在两数之间
        offsetposition = offsetposition.normalized * distance;
       

    }

    /// <summary>
    /// 控制视角旋转
    /// </summary>
    void RotaView()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isRotaing = true;
        }
        if(Input.GetMouseButtonUp(1))
        {
            isRotaing = false;
        }
        if (isRotaing)
        {
            transform.RotateAround(player.position, player.up, Input.GetAxis("Mouse X")); //将transform围绕玩家水平旋转

            Vector3 oldposition = transform.position;
            Quaternion oldrotation = transform.rotation;
            transform.RotateAround(player.position, transform.right, -Input.GetAxis("Mouse Y")); //将transform围绕玩家垂直旋转
                                                                                                //他会影响position与rotation
            //控制垂直旋转在一定的范围之内,若超出范围则让垂直的旋转无效
            float x = transform.eulerAngles.x;
            if (x < 10 || x > 80)
            {
                transform.position = oldposition;
                transform.rotation = oldrotation;
            }
            
        }

        offsetposition = player.position - transform.position;//因为旋转后摄像头方向发生改变，因此需要更新他们的偏移
    }
}
