using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour {

    public float moveSpeed = 4;
    public PlayState state = PlayState.Idle;
    public bool isMoving = false;
    private CharacterController controller;
    private Player_Strc strc;

	void Start () {
        strc = this.GetComponent<Player_Strc>();
        controller = transform.GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
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
