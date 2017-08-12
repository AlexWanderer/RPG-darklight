using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BagItem : MonoBehaviour {

    /*
    public Image itemImage;
    /// <summary>
    /// 用于更新物品的显示图片
    /// </summary>
    /// <param name="s"></param>
    public void UpdateImage(Sprite s)
    {
        itemImage.sprite = s;
    }*/

    private Image itemImage;
    private void Awake()
    {
        itemImage = this.GetComponent<Image>();
    }

    /// <summary>
    /// 通过物品ID设置Item显示的图标
    /// </summary>
    /// <param name="id">要显示物品的ID</param>
    public void SetById(int id)
    {
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        itemImage.name = info.name_Icon;
        string path = "Icon/" + info.name_Icon;
        Debug.Log(path);
        itemImage.sprite = Resources.Load(path)as Sprite;
    }

    /// <summary>
    /// 通过物品图标的名字的更新Item
    /// </summary>
    /// <param name="nameIcon">物品图标的名字</param>
    public void setIconName(string nameIcon)
    {
        itemImage.name = nameIcon;
        string path = "Icon/" + nameIcon;
        Debug.Log(path);
        itemImage.sprite = Resources.Load(path,typeof(Sprite)) as Sprite;
    }
}
