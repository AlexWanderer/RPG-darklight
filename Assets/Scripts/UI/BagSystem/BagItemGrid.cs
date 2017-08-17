using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagItemGrid : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
    ,IPointerEnterHandler,IPointerExitHandler
{
    public int id = 0;  //物品ID

    public int count = 0;  //物品数量
    public ObjectInfo info = null;  //物品信息
    public Text itemCount;  //用于显示物品数量

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

    /// <summary>
    /// 左键按下开始拖拽的回调函数
    /// </summary>
    public static Action<Transform> OnLeftBeginDrag;
    /// <summary>
    /// 结束拖拽的回调函数
    /// </summary>
    public static Action<Transform,Transform> OnLeftEndDrag;

    /// <summary>
    /// 开始拖拽事件
    /// </summary>
    /// <param name="eventData"></param>
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (OnLeftBeginDrag != null)
            {
                OnLeftBeginDrag(transform);
            }
        }
    }

    /// <summary>
    /// 拖拽中
    /// </summary>
    /// <param name="eventData"></param>
    public void OnDrag(PointerEventData eventData)
    {
    }

    /// <summary>
    /// 结束拖拽时
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (eventData.pointerEnter == null)
            {
                OnLeftEndDrag(transform,null);
            }else
            {
                OnLeftEndDrag(transform, eventData.pointerEnter.transform);
            }
        }
    }

    /// <summary>
    /// 用于处理鼠标进入Item显示详情的回调函数
    /// </summary>
    public static Action<Transform> OnEnter;
    /// <summary>
    /// 用于处理鼠标离开Item隐藏详情的回调函数
    /// </summary>
    public static Action OnExit;

    /// <summary>
    /// 当鼠标进入Item
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag == Tags.grid)
        {
            if (OnEnter != null)
            {
                OnEnter(transform);
            }
        }
    }

    /// <summary>
    /// 当鼠标离开Item
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag == Tags.grid)
        {
            if (OnExit != null)
            {
                OnExit();
            }
        }
    }

   
}
