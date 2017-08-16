using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour {

    public static Equipment _instanceEquip;

    private GameObject headgear;
    private GameObject armor;
    private GameObject leftHand;
    private GameObject rightHand;
    private GameObject shoe;
    private GameObject accessory;

    private Image icon;
    
    private void Awake()
    {
        _instanceEquip = this;

        headgear = transform.Find("Headgear").gameObject;
        armor = transform.Find("Armor").gameObject;
        leftHand = transform.Find("LeftHand").gameObject;
        rightHand = transform.Find("RightHand").gameObject;
        shoe = transform.Find("Shoe").gameObject;
        accessory = transform.Find("Accessory").gameObject;
    }

    /// <summary>
    /// 用于判断能否穿戴，能就穿戴并返回true，不能返回false
    /// </summary>
    public bool DressEquipment(ObjectInfo info)
    {
        if (info.type != objectType.Equip)
        {
            return false;
        }
        if (info.appType != AppType.Common || info.appType.ToString() != Player_State._instancePlayerState.profession.ToString())
        {
            return false;
        }

        switch (info.equipmentType)
        {
            case EquipmentType.Accessory:
                icon = accessory.GetComponent<Image>();
                string path = "Icon/" + info.name_Icon;
                icon.sprite = Resources.Load(path) as Sprite;
                break;
            case EquipmentType.Armor:
                icon = armor.GetComponent<Image>();
                path = "Icon/" + info.name_Icon;
                icon.sprite = Resources.Load(path) as Sprite;
                break;
            case EquipmentType.Headgear:
                icon = headgear.GetComponent<Image>();
                path = "Icon/" + info.name_Icon;
                icon.sprite = Resources.Load(path) as Sprite;
                break;
            case EquipmentType.LeftHand:
                icon = leftHand.GetComponent<Image>();
                path = "Icon/" + info.name_Icon;
                icon.sprite = Resources.Load(path) as Sprite;
                break;
            case EquipmentType.RightHand:
                icon = rightHand.GetComponent<Image>();
                path = "Icon/" + info.name_Icon;
                icon.sprite = Resources.Load(path) as Sprite;
                break;
            case EquipmentType.Shoe:
                icon = shoe.GetComponent<Image>();
                path = "Icon/" + info.name_Icon;
                icon.sprite = Resources.Load(path) as Sprite;
                break;
        }
        return true;
    }
}
