using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于管理Menu_Button中的按键
/// </summary>
public class MenuButton : MonoBehaviour {

    public bool showingStatus = false;
    public bool showingEquipment = false;
    public GameObject statusUI;
    public GameObject equipment;

    /// <summary>
    /// 按下Status按键
    /// </summary>
    public void ClickBtStatusDown()
    {
        StatusState();
    }

    /// <summary>
    /// 按下Skill按键
    /// </summary>
    public void ClickBtSkillDown()
    {

    }

    /// <summary>
    /// 按下Equip按键
    /// </summary>
    public void ClickBtEquipDown()
    {
        EquipmentState();
    }

    /// <summary>
    /// 按下Bag按键
    /// </summary>
    public void ClickBtBagDown()
    {
        Bag._intanceBag.BagState();
    }

    /// <summary>
    /// 按下Setting按键
    /// </summary>
    public void ClickBtSettingDown()
    {

    }


    /// <summary>
    /// 控制属性面板的显示与隐藏
    /// </summary>
    private void StatusState()
    {
        if (!showingStatus)
        {
            statusUI.SetActive(true);
            StatusUI._instanceStatus.UpdateStatus();
            showingStatus = true;
        }
        else
        {
            showingStatus = false;
            statusUI.SetActive(false);
        }

    }

    /// <summary>
    /// 装备面板属性的显示与隐藏
    /// </summary>
    private void EquipmentState()
    {
        if (!showingEquipment)
        {
            equipment.SetActive(true);
            showingEquipment = true;
        }
        else
        {
            showingEquipment = false;
            equipment.SetActive(false);
        }
    }
}
