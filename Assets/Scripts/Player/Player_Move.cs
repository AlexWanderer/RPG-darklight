using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实现人物的移动
/// </summary>
public class Player_Move : MonoBehaviour {

    public float moveSpeed = 4;  //人物移动速度
    public PlayState state = PlayState.Idle;  //人物动作状态，默认为站立
    public bool isMoving = false;  //是否行走标致位
    private CharacterController controller;  //获取人物控制组件
    private Player_Strc strc;  //获取人物朝向脚本

	void Start () {
        strc = this.GetComponent<Player_Strc>();
        controller = transform.GetComponent<CharacterController>();
	}
	

	void Update () {
        float distance = Vector3.Distance(strc.target, transform.position);
        if (distance > 0.1f)
        {
            isMoving = true;
            state = PlayState.Moving;
            controller.SimpleMove(transform.forward * moveSpeed);
        }
        else {
            isMoving = false;
            state = PlayState.Idle;
        }
	}
}
