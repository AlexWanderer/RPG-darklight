using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 枚举人物动作
/// </summary>
public enum PlayState {
    Moving,
    Idle
}

/// <summary>
/// 枚举小狼的动作
/// </summary>
public enum WolfBabyState
{
    Idle,
    Walk,
    Attack,
    Death
}

/// <summary>
/// 用于存储有关的动作的名字，可直接调用对应的变量名，减少出错
/// </summary>
public class Animations : MonoBehaviour {

    public const string magc_Attack1 = "Attack1";
    public const string magc_Attack2 = "Attack2";
    public const string magc_AttackCritical = "AttackCritical";
    public const string magc_Cast = "Cast";
    public const string magc_Death = "Death";
    public const string magc_Run = "Run";
    public const string magc_Skill_GroundImpact = "Skill-GroundImpact";
    public const string magc_Skill_MagicBall = "Skill-MagicBall";
    public const string magc_TakeDamage1 = "TakeDamage1";
    public const string magc_TakeDamage2 = "TakeDamage2";
    public const string magc_Walk = "Walk";
    public const string magc_Idle = "Idle";

    public const string wbaby_Idel = "WolfBaby-Idle";
    public const string wbaby_Death = "WolfBaby-Death";
    public const string wbaby_Attack1 = "WolfBaby-Attack1";
    public const string wbaby_Attack2 = "WolfBaby-Attack2";
    public const string wbaby_TakeDamage1 = "WolfBaby-TakeDamage1";
    public const string wbaby_TakeDamage2 = "WolfBaby-TakeDamage2";
    public const string wbaby_Walk = "WolfBaby-Walk";

}
