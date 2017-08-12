using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagItemGrid : MonoBehaviour
{
    public int id = 0;  //物品ID
    private int count = 0;  //物品数量
    private ObjectInfo info = null;  //物品信息
    private Text itemCount;  //用于显示物品数量

    private void Start()
    {
        itemCount = this.GetComponentInChildren<Text>();
    }

    /// <summary>
    /// 将对应的物品显示在Grid方格中
    /// </summary>
    /// <param name="id">物品id</param>
    /// <param name="num">物品数量</param>
    public void SetByID(int id, int num = 1)
    {
        this.id = id;
        info = ObjectsInfo._instance.GetObjectInfoById(id);
        BagItem item = this.GetComponentInChildren <BagItem>();
        item.setIconName(info.name_Icon);
        count = num;
        itemCount.enabled = true;
        itemCount.text = count.ToString();

    }

    public void PlusCount(int num = 1)
    {
        this.count += num;
        itemCount.text = count.ToString();
    }

    /// <summary>
    /// 清空方格中的物品信息
    /// </summary>
    public void Clear()
    {
        id = 0;
        info = null;
        count = 0;
        itemCount.enabled = false;
    }
}
