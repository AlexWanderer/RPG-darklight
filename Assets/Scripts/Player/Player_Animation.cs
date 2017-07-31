using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animation : MonoBehaviour {

    private Player_Move move;
    private Animation anima;

	void Start () {
        move = this.GetComponent<Player_Move>();
        anima = this.GetComponent<Animation>();
	}
	
	// Update is called once per frame
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
