using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Strc : MonoBehaviour {


    public GameObject walk_effect_prefab;
    public Vector3 target = Vector3.zero;
    private bool isMoving = false;
    private Player_Move playerMove;
    

    private void Start()
    {
        playerMove = this.GetComponent<Player_Move>();
        target = transform.position;
    }

    void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray,out hitInfo);
            if (isCollider && hitInfo.collider.tag == Tags.ground)
            {
                isMoving = true;
                EffectWalk(hitInfo.point);
                LookAtTarget(hitInfo.point);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMoving = false;
        }

        if (isMoving)  //如果一直按下左键，那么持续更新射线碰撞到的点
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isCollider = Physics.Raycast(ray, out hitInfo);
            if (isCollider && hitInfo.collider.tag == Tags.ground)
            {
                LookAtTarget(hitInfo.point);
            }
        }
        else if (playerMove.isMoving)
        {
            LookAtTarget(target);
        }
        

	}

    void EffectWalk(Vector3 onClikPoint)  //生成鼠标点击的效果
    {
        onClikPoint = new Vector3(onClikPoint.x, onClikPoint.y + 0.2f, onClikPoint.z);
        GameObject.Instantiate(walk_effect_prefab, onClikPoint, Quaternion.identity);
    }

    void LookAtTarget(Vector3 onClikPoint)  //使玩家朝向目标点
    {
        target = new Vector3(onClikPoint.x, transform.position.y, onClikPoint.z);
        transform.LookAt(target);
    }
}
