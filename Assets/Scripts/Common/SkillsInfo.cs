using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsInfo : MonoBehaviour {

    public static SkillsInfo _instanceSkill;
    public TextAsset skillsInfoText;
    private Dictionary<int, SkillInfo> skillsInfoDictionary = new Dictionary<int, SkillInfo>();

    private void Awake()
    {
        _instanceSkill = this;
        ReadSkillText();
    }

    /// <summary>
    /// 通过id查找技能信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public SkillInfo GetSkillInfo(int id)
    {
        SkillInfo info = null;
        skillsInfoDictionary.TryGetValue(id, out info);
        return info;
    }


    /// <summary>
    /// 获取Txt文件中的信息
    /// </summary>
    private void ReadSkillText()
    {
        string text = skillsInfoText.text;
        string[] strArray = text.Split('\n');

        foreach (string str in strArray)
        {
            string[] proArray = str.Split(',');
            SkillInfo info = new SkillInfo();

            info.ID = int.Parse(proArray[0]);
            info.name = proArray[1];
            info.iconName = proArray[2];
            info.des = proArray[3];
            switch (proArray[4])
            {
                case "Passive":
                    info.applyType = ApplyType.Passive;
                    break;
                case "Buff":
                    info.applyType = ApplyType.Buff;
                    break;
                case "SingleTarget":
                    info.applyType = ApplyType.SingleTarget;
                    break;
                case "MultiTarget":
                    info.applyType = ApplyType.MultiTarget;
                    break;
            }

            switch (proArray[5])
            {
                case "Attack":
                    info.applyProperty = ApplyProperty.Attack;
                    break;
                case "Def":
                    info.applyProperty = ApplyProperty.Def;
                    break;
                case "Speed":
                    info.applyProperty = ApplyProperty.Speed;
                    break;
                case "AttackSpeed":
                    info.applyProperty = ApplyProperty.AttackSpeed;
                    break;
                case "HP":
                    info.applyProperty = ApplyProperty.HP;
                    break;
                case "MP":
                    info.applyProperty = ApplyProperty.MP;
                    break;
            }

            info.applyValus = int.Parse(proArray[6]);
            info.applyTime = float.Parse(proArray[7]);
            info.needMP = int.Parse(proArray[8]);
            info.cD = float.Parse(proArray[9]);

            switch (proArray[10])
            {
                case "Swordman":
                    info.applicableRole = ApplicableRole.Swordman;
                    break;
                case "Magician":
                    info.applicableRole = ApplicableRole.Magician;
                    break;
            }

            info.applicableLevel = int.Parse(proArray[11]);
            switch (proArray[12])
            {
                case "Self":
                    info.releaseType = ReleaseType.Self;
                    break;
                case "Enemy":
                    info.releaseType = ReleaseType.Enemy;
                    break;
                case "Position":
                    info.releaseType = ReleaseType.Position;
                    break;
            }

            info.releaseDec = float.Parse(proArray[13]);
            skillsInfoDictionary.Add(info.ID, info);
        }
    }

}

/// <summary>
/// 适用角色
/// </summary>
public enum ApplicableRole
{
    Swordman,
    Magician
}

/// <summary>
/// 作用类型
/// </summary>
public enum ApplyType
{
    Passive, //增益
    Buff,
    SingleTarget,
    MultiTarget
}

/// <summary>
/// 作用属性
/// </summary>
public enum ApplyProperty
{
    Attack,
    Def,
    Speed,
    AttackSpeed,
    HP,
    MP
}

/// <summary>
/// 释放类型
/// </summary>
public enum ReleaseType
{
    Self,
    Enemy,
    Position
}

/// <summary>
/// 技能信息
/// </summary>
public class SkillInfo
{
    public int ID = 0;  //技能ID
    public string name = null;//名称
    public string iconName = null;//icon名称
    public string des = null;//描述
    public ApplyType applyType;//作用类型
    public ApplyProperty applyProperty;//作用属性
    public int applyValus = 0;//作用值
    public float applyTime = 0;//作用时间
    public int needMP = 0;//消耗魔法
    public float cD = 0;//冷却时间
    public ApplicableRole applicableRole; //适用角色
    public int applicableLevel;//适用等级
    public ReleaseType releaseType;//释放类型
    public float releaseDec;//释放距离
}
