using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于记录人物的状态信息
/// </summary>
public class Player_State : MonoBehaviour {

    public int level = 1;  //等级
    public int HP = 100;   //血量
    public int MP = 100;   //魔力值
    public int gold = 200; //金币数

    public void AddGold(int count)
    {
        gold += count;
    }

	
}
