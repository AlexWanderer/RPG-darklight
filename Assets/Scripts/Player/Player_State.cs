using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于记录人物的状态信息
/// </summary>
public class Player_State : MonoBehaviour {

    public enum Profession
    {
        Swordman,
        Magician
    }

    public Profession profession = Profession.Magician;
    public int level = 1;  //等级
    public string playerName = "HandsomeBoy";  //玩家名称
    public int HP = 100;   //血量
    public int MP = 100;   //魔力值
    public float hpRemain = 100; //剩余血量
    public float mpRemain = 100; //剩余蓝量
    public int gold = 1000; //金币数
    public int exp = 0;

    public int attack = 20; //初始攻击力
    public int def = 20; //初始防御力
    public int speed = 20; //初始速度

    public int attack_plus = 0;
    public int def_plus = 0;
    public int speed_plus = 0;

    public int point_remain = 0;  //加点数

    public static Player_State _instancePlayerState;

    private void Awake()
    {
        _instancePlayerState = this;
    }

    private void Start()
    {
        GetExp(0);
    }

    public void AddGold(int count)
    {
        gold += count;
    }

    public bool GetPoint(int point = 1)
    {
        if (point_remain >= point)
        {
            point_remain -= point;
            return true;
        }
        return false;
    }

    public void GetExp(int getExp)
    {
        this.exp += getExp;
        int totalExp = 100 + (level - 1) * 30;
        while (this.exp >= totalExp)
        {

            this.level++;
            this.exp -= totalExp;
            totalExp = 100 + (level - 1) * 30;
        }

        ExpBar._instanceExp.UpdateExp(exp / totalExp);
    }

    
}
