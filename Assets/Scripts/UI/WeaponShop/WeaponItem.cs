using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponItem : MonoBehaviour {

    private Image icon;
    private Text weaponName;
    private Text price;
    private Text property;
    private ObjectInfo info;
    
    private void Init()
    {
        icon = transform.FindChild("Icon").GetComponent<Image>();
        weaponName = transform.FindChild("Name").GetComponent<Text>();
        price = transform.FindChild("Price").GetComponent<Text>();
        property = transform.FindChild("Property").GetComponent<Text>();
    }

    public void SetWeaponInfo(int id)
    {
        Init();
        info =  ObjectsInfo._instance.GetObjectInfoById(id);
        string path = "Icon/" + info.name_Icon;
        icon.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        weaponName.text = info.name;
        price.text = "价格：" + info.price_Buy + "金";
        property.text = "攻击+" + info.attackValue + " 防御+" + info.defValue + " 速度+" + info.speedValue;
    }

    public void BuyWeapon()
    {
        Bag._intanceBag.GetID(info.ID);
        Player_State._instancePlayerState.AddGold(-info.price_Buy);
        Bag._intanceBag.UpdateGold();
    }

	
}
