using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour {

    public static Equipment _instanceEquip;
    public GameObject iconPrefab;

    private GameObject headgear;
    private GameObject armor;
    private GameObject leftHand;
    private GameObject rightHand;
    private GameObject shoe;
    private GameObject accessory;

    private int headgearID = 0;
    private int armorID = 0;
    private int leftHandID = 0;
    private int rightHandID = 0;
    private int shoeID = 0;
    private int accessoryID = 0;

    private GameObject icon;
    
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
        if (info.appType != AppType.Common && info.appType.ToString() != Player_State._instancePlayerState.profession.ToString())
        {
            return false;
        }
        
        switch (info.equipmentType)
        {
            case EquipmentType.Accessory:
                if (accessoryID == 0)
                {
                    icon = Instantiate(iconPrefab, accessory.transform);
                    accessoryID = info.ID;
                    SetIcon(icon, info);
                }
                else
                {
                    int oldId = accessoryID;
                    accessoryID = info.ID;
                    SetIcon(accessory.transform.GetChild(0).gameObject, info);
                    Bag._intanceBag.GetID(oldId, 1);
                }    
                break;
            case EquipmentType.Armor:
                if (armorID == 0)
                {
                    icon = Instantiate(iconPrefab, armor.transform);
                    armorID = info.ID;
                    SetIcon(icon, info);
                }
                else
                {
                    int oldId = armorID;
                    armorID = info.ID;
                    SetIcon(armor.transform.GetChild(0).gameObject, info);
                    Bag._intanceBag.GetID(oldId, 1);
                }
                break;
            case EquipmentType.Headgear:
                if (headgearID == 0)
                {
                    icon = Instantiate(iconPrefab, headgear.transform);
                    headgearID = info.ID;
                    SetIcon(icon, info);
                }
                else
                {
                    int oldId = headgearID;
                    headgearID = info.ID;
                    SetIcon(headgear.transform.GetChild(0).gameObject, info);
                    Bag._intanceBag.GetID(oldId, 1);
                }
                break;
            case EquipmentType.LeftHand:
                if (leftHandID == 0)
                {
                    icon = Instantiate(iconPrefab, leftHand.transform);
                    leftHandID = info.ID;
                    SetIcon(icon, info);
                }
                else
                {
                    int oldId = leftHandID;
                    leftHandID = info.ID;
                    SetIcon(leftHand.transform.GetChild(0).gameObject, info);
                    Bag._intanceBag.GetID(oldId, 1);
                }
                break;
            case EquipmentType.RightHand:
                if (rightHandID == 0)
                {
                    icon = Instantiate(iconPrefab, rightHand.transform);
                    rightHandID = info.ID;
                    SetIcon(icon, info);
                }
                else
                {
                    int oldId = rightHandID;
                    rightHandID = info.ID;
                    SetIcon(rightHand.transform.GetChild(0).gameObject, info);
                    Bag._intanceBag.GetID(oldId, 1);
                }
                break;
            case EquipmentType.Shoe:
                if (shoeID == 0)
                {
                    icon = Instantiate(iconPrefab, shoe.transform);
                    shoeID = info.ID;
                    SetIcon(icon, info);
                }
                else
                {
                    int oldId = shoeID;
                    shoeID = info.ID;
                    SetIcon(shoe.transform.GetChild(0).gameObject, info);
                    Bag._intanceBag.GetID(oldId, 1);
                }
                break;
        }
        return true;
    }


    /// <summary>
    /// 用于设置图标
    /// </summary>
    /// <param name="icon"></param>
    private void SetIcon(GameObject iconTemp,ObjectInfo infoTemp)
    {
        iconTemp.transform.localPosition = Vector3.zero;
        string path = null;
        path = "Icon/" + infoTemp.name_Icon;
        iconTemp.GetComponent<Image>().sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        iconTemp.GetComponent<RectTransform>().sizeDelta = new Vector2(30, 30);
    }

    
}
