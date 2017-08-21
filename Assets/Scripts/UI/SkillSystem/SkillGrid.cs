using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillGrid : MonoBehaviour {

    private int skillID;
    private SkillInfo skillInfo;

    private Image skillIcon_Img;
    private Text skillName_Tex;
    private Text skillCD_Tex;
    private Text skillDes_Tex;
    private Text skillApplyType_Tex;
    private Text needMP_Tex;

    /// <summary>
    /// 初始化显示的组件
    /// </summary>
    private void InitProprety()
    {
        skillIcon_Img = transform.Find("SkillIcon").gameObject.GetComponent<Image>();
        skillName_Tex = transform.Find("SkillName").gameObject.GetComponent<Text>();
        skillCD_Tex = transform.Find("CD").gameObject.GetComponent<Text>();
        skillDes_Tex = transform.Find("SkillDes").gameObject.GetComponent<Text>();
        skillApplyType_Tex = transform.Find("ApplyType").gameObject.GetComponent<Text>();
        needMP_Tex = transform.Find("NeedMP").gameObject.GetComponent<Text>();
    }

    /// <summary>
    /// 通过ID显示相关属性
    /// </summary>
    public void SetSkill(int id)
    {
        InitProprety();
        skillID = id;
        Debug.Log(skillID);
        skillInfo = SkillsInfo._instanceSkill.GetSkillInfo(skillID);
        if (skillInfo == null)
        {
            Debug.Log("warry");
        }
        Debug.Log(skillInfo.iconName);
        string temp = "Icon/" + skillInfo.iconName;
        skillIcon_Img.sprite = Resources.Load(temp, typeof(Sprite)) as Sprite;
        skillName_Tex.text = skillInfo.name;
        skillCD_Tex.text = skillInfo.cD + "s";
        skillDes_Tex.text = skillInfo.des;
        skillApplyType_Tex.text = skillInfo.applyType.ToString();
        needMP_Tex.text = skillInfo.needMP + "MP";
    }

}
