using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于管理物品信息
/// </summary>
public class ObjectsInfo : MonoBehaviour {

    public static ObjectsInfo _instance;
    public TextAsset objectsInfoListText;  //用于获得文本中的物品信息

    private Dictionary<int,ObjectInfo> objectInfoDic= new Dictionary<int,ObjectInfo>();//创建一个存放物品信息的字典 通过ID查找

    private void Awake()
    {
        _instance = this;
        ReadInfo();
    }

    /// <summary>
    /// 查找对应物品的信息
    /// </summary>
    /// <param name="id">物品的ID</param>
    /// <returns></returns>
    public ObjectInfo GetObjectInfoById(int id)
    {
        ObjectInfo info = null;
        objectInfoDic.TryGetValue(id, out info);
        return info;
    }

    /// <summary>
    /// 读取数据创建字典
    /// </summary>
    void ReadInfo()
    {
        string text = objectsInfoListText.text; //获得文本所有信息
        string[] strArray = text.Split('\n');  //获得每个物品的所有信息

        //获得每个物品中的属性，并保存到objectInfoDic中
        foreach (string str in strArray)
        {
            string[] proArray = str.Split(',');
            ObjectInfo info = new ObjectInfo();
        
            info.ID = int.Parse(proArray[0]);
            info.name = proArray[1];
            info.name_Icon = proArray[2];
            string str_type = proArray[3]; //设置一个缓存，在判断是哪种类型物品
            switch (str_type)
            {
                case "Drug":
                    info.type = objectType.Drug;
                    break;
                case "Equip":
                    info.type = objectType.Equip;
                    break;
                case "Mat":
                    info.type = objectType.Mat;
                    break;
            }

            if (info.type == objectType.Drug)
            {
                info.recover_HP = int.Parse(proArray[4]);
                info.recover_MP = int.Parse(proArray[5]);
                info.price_Sell = int.Parse(proArray[6]);
                info.price_Buy = int.Parse(proArray[7]);

            }
            else if (info.type == objectType.Equip)
            {
                info.attackValue = int.Parse(proArray[4]);
                info.defValue = int.Parse(proArray[5]);
                info.speedValue = int.Parse(proArray[6]);
                string temp = proArray[7];
                switch (temp)
                {
                    case "Armor":
                        info.equipmentType = EquipmentType.Armor;
                        break;
                    case "Headgear":
                        info.equipmentType = EquipmentType.Headgear;
                        break;
                    case "Shoe":
                        info.equipmentType = EquipmentType.Shoe;
                        break;
                    case "LeftHand":
                        info.equipmentType = EquipmentType.LeftHand;
                        break;
                    case "RightHand":
                        info.equipmentType = EquipmentType.RightHand;
                        break;
                    case "Accessory":
                        info.equipmentType = EquipmentType.Accessory;
                        break;
                }
                temp = null;
                temp = proArray[8];
                switch (temp)
                {
                    case "Swordman":
                        info.appType = AppType.Swordman;
                        break;
                    case "Magician":
                        info.appType = AppType.Magician;
                        break;
                    case "Common":
                        info.appType = AppType.Common;
                        break;
                }
                info.price_Sell = int.Parse(proArray[9]);
                info.price_Buy = int.Parse(proArray[10]);

                
            }
          
            objectInfoDic.Add(info.ID, info);
        }
    }

}



/// <summary>
/// 物品类型枚举
/// </summary>
public enum objectType
{
    Drug,
    Equip,
    Mat
}

/// <summary>
/// 装备类型
/// </summary>
public enum EquipmentType
{
    Armor,
    Headgear,
    Shoe,
    LeftHand,
    RightHand,
    Accessory
}

/// <summary>
/// 角色类型
/// </summary>
public enum AppType
{
    Swordman,
    Magician,
    Common
}
/*   
     * ID 
     * 名称 
     * Icon名称 
     * 类型  药品Drug（1000），装备Equip（2000），材料Mat（3000）
     * 加血值 
     * 加蓝值 
     * 出售价 
     * 购买价*/

/// <summary>
/// 管理单个物品的信息
/// </summary>
public class ObjectInfo
{
    public int ID;
    public string name;
    public string name_Icon;
    public objectType type;
    public int recover_HP;
    public int recover_MP;
    public int price_Sell;
    public int price_Buy;

    public int attackValue;
    public int defValue;
    public int speedValue;
    public EquipmentType equipmentType;
    public AppType appType;
}
