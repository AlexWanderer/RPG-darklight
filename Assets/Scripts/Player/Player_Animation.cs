using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于处理播放人物的动作动画
/// </summary>
public class Player_Animation : MonoBehaviour {

    private Player_Move move;
    private Animation anima;

	void Start () {
        move = this.GetComponent<Player_Move>();
        anima = this.GetComponent<Animation>();
	}
	
	void LateUpdate () {
        if (move.state == PlayState.Moving)
        {
            anima.Play(Animations.magc_Run);
        }
        else if (move.state == PlayState.Idle)
        {
            anima.Play(Animations.magc_Idle);
        }

	}

}
