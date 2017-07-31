using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 通过射线碰撞RayColider跟随鼠标调整朝向
/// </summary>
public class Player_Strc : MonoBehaviour {


    public GameObject walk_effect_prefab;
    public Vector3 target = Vector3.zero;  //鼠标点击地点，即为目标地点
    private bool isMoving = false;  //是否移动标志位
    private Player_Move playerMove;  //获取人物移动脚本
    

    private void Start()
    {
        playerMove = this.GetComponent<Player_Move>();
        target = transform.position;  
    }

    void Update () {
        //若按下鼠标左键一下，则调整人物朝向
        if (Input.GetMouseButtonDown(0))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  //获取从屏幕到鼠标点击位置的射线
            RaycastHit hitInfo;  
            bool isCollider = Physics.Raycast(ray,out hitInfo);  //判断射线是否发生碰撞，并返回射线信息
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
        else if (playerMove.isMoving)  //如果人物在移动中，则持续更新人物朝向以排除地形的干扰
        {
            LookAtTarget(target);
        }
        

	}

    /// <summary>
    /// 生成鼠标点击的效果
    /// </summary>
    /// <param name="onClikPoint">鼠标点击的位置</param>
    void EffectWalk(Vector3 onClikPoint) 
    {
        onClikPoint = new Vector3(onClikPoint.x, onClikPoint.y + 0.2f, onClikPoint.z);
        GameObject.Instantiate(walk_effect_prefab, onClikPoint, Quaternion.identity);
    }

    /// <summary>
    /// 使玩家朝向目标点
    /// </summary>
    /// <param name="onClikPoint">鼠标点击的位置</param>
    void LookAtTarget(Vector3 onClikPoint)  
    {
        target = new Vector3(onClikPoint.x, transform.position.y, onClikPoint.z);
        transform.LookAt(target);
    }
}
