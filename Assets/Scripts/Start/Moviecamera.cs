using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于场景开始摄像机由远至近
/// </summary>
public class Moviecamera : MonoBehaviour {

    public float speed = 10.0f;  //摄像机移动速度
    public float end_Z = -20;   //摄像机停止位置

	void Update () {
        if (transform.position.z < end_Z)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
	}
}
