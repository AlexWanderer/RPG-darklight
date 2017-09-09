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
    public GameObject statusUI;

    private EquipmentGrid headgearGrid;
    private EquipmentGrid armorGrid;
    private EquipmentGrid leftHandGrid;
    private EquipmentGrid rightHandGrid;
    private EquipmentGrid shoeGrid;
    private EquipmentGrid accessoryGrid;

    private GameObject icon;
    private Transform tempTransform = null;
    
    private void Awake()
    {
        _instanceEquip = this;

        headgear = transform.Find("Headgear").gameObject;
        armor = transform.Find("Armor").gameObject;
        leftHand = transform.Find("LeftHand").gameObject;
        rightHand = transform.Find("RightHand").gameObject;
        shoe = transform.Find("Shoe").gameObject;
        accessory = transform.Find("Accessory").gameObject;



        EquipmentGrid.OnEnterEquip += EquipmentGrid_OnEnterEquip;
        EquipmentGrid.OnExitEquip += EquipmentGrid_OnExitEquip;
    }

    private void Start()
    {
        getEquipmentGrid();
    }

    private void Update()
    {
        if (tempTransform != null&& Input.GetMouseButtonDown(1))
        {
            if (tempTransform.childCount != 0)
            {
                Destroy(tempTransform.GetChild(0).gameObject);
                EquipmentGrid temp = tempTransform.gameObject.GetComponent<EquipmentGrid>();
                ObjectInfo tempInfo = ObjectsInfo._instance.GetObjectInfoById(temp.id);
                Player_State._instancePlayerState.attack_plus -= tempInfo.attackValue;
                Player_State._instancePlayerState.def_plus -= tempInfo.defValue;
                Player_State._instancePlayerState.speed_plus -= tempInfo.speedValue;
                if (statusUI.activeInHierarchy == true)
                {
                    StatusUI._instanceStatus.UpdateStatus();
                }
                Bag._intanceBag.GetID(temp.id);
                temp.id = 0;
                tempTransform = null;
            }
        }
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
        int oldId = 0;
        switch (info.equipmentType)
        {
            
            case EquipmentType.Accessory:
                if (accessoryGrid.id == 0)
                {
                    icon = Instantiate(iconPrefab, accessory.transform);
                    accessoryGrid.id = info.ID;
                    SetIcon(icon, info);
                }
                else
                {
                    oldId = accessoryGrid.id;
                    accessoryGrid.id = info.ID;
                    SetIcon(accessory.transform.GetChild(0).gameObject, info);
                    Bag._intanceBag.GetID(oldId, 1);
                }    
                break;
            case EquipmentType.Armor:
                if (armorGrid.id == 0)
                {
                    icon = Instantiate(iconPrefab, armor.transform);
                    armorGrid.id = info.ID;
                    SetIcon(icon, info);
                }
                else
                {
                    oldId = armorGrid.id;
                    armorGrid.id = info.ID;
                    SetIcon(armor.transform.GetChild(0).gameObject, info);
                    Bag._intanceBag.GetID(oldId, 1);
                }
                break;
            case EquipmentType.Headgear:
                if (headgearGrid.id == 0)
                {
                    icon = Instantiate(iconPrefab, headgear.transform);
                    headgearGrid.id = info.ID;
                    SetIcon(icon, info);
                }
                else
                {
                    oldId = headgearGrid.id;
                    headgearGrid.id = info.ID;
                    SetIcon(headgear.transform.GetChild(0).gameObject, info);
                    Bag._intanceBag.GetID(oldId, 1);
                }
                break;
            case EquipmentType.LeftHand:
                if (leftHandGrid.id == 0)
                {
                    icon = Instantiate(iconPrefab, leftHand.transform);
                    leftHandGrid.id = info.ID;
                    SetIcon(icon, info);
                }
                else
                {
                    oldId = leftHandGrid.id;
                    leftHandGrid.id = info.ID;
                    SetIcon(leftHand.transform.GetChild(0).gameObject, info);
                    Bag._intanceBag.GetID(oldId, 1);
                }
                break;
            case EquipmentType.RightHand:
                if (rightHandGrid.id == 0)
                {
                    icon = Instantiate(iconPrefab, rightHand.transform);
                    rightHandGrid.id = info.ID;
                    SetIcon(icon, info);
                }
                else
                {
                    oldId = rightHandGrid.id;
                    rightHandGrid.id = info.ID;
                    SetIcon(rightHand.transform.GetChild(0).gameObject, info);
                    Bag._intanceBag.GetID(oldId, 1);
                }
                break;
            case EquipmentType.Shoe:
                if (shoeGrid.id == 0)
                {
                    icon = Instantiate(iconPrefab, shoe.transform);
                    shoeGrid.id = info.ID;
                    SetIcon(icon, info);
                }
                else
                {
                    oldId = shoeGrid.id;
                    shoeGrid.id = info.ID;
                    SetIcon(shoe.transform.GetChild(0).gameObject, info);
                    Bag._intanceBag.GetID(oldId, 1);
                }
                break;
        }

        if (oldId != 0)
        {
            ObjectInfo temp = ObjectsInfo._instance.GetObjectInfoById(oldId);
            Player_State._instancePlayerState.attack_plus -= temp.attackValue;
            Player_State._instancePlayerState.def_plus -= temp.defValue;
            Player_State._instancePlayerState.speed_plus -= temp.speedValue;
        }
        Player_State._instancePlayerState.attack_plus += info.attackValue;
        Player_State._instancePlayerState.def_plus += info.defValue;
        Player_State._instancePlayerState.speed_plus += info.speedValue;
        if (statusUI.activeInHierarchy == true)
        {
            StatusUI._instanceStatus.UpdateStatus();
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

    /// <summary>
    /// 用于获取每个装备格子中的脚本
    /// </summary>
    private void getEquipmentGrid()
    {
        armorGrid = armor.GetComponent<EquipmentGrid>();
        headgearGrid = headgear.GetComponent<EquipmentGrid>();
        leftHandGrid = leftHand.GetComponent<EquipmentGrid>();
        rightHandGrid = rightHand.GetComponent<EquipmentGrid>();
        shoeGrid = shoe.GetComponent<EquipmentGrid>();
        accessoryGrid = accessory.GetComponent<EquipmentGrid>();

    }

    /// <summary>
    /// 鼠标进入格子缓存鼠标所在的格子
    /// </summary>
    /// <param name="gridTransform"></param>
    private void EquipmentGrid_OnEnterEquip(Transform gridTransform)
    {
        tempTransform = gridTransform;
    }

    private void EquipmentGrid_OnExitEquip()
    {
        tempTransform = null;
    }
}
