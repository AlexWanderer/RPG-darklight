using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class DragItemUI : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = this.GetComponent<Image>();
    }
    /// <summary>
    /// 显示鼠标按下后跟随的图标DragItem
    /// </summary>
    public void Show()
    {
        gameObject.SetActive(true);
        
    }

    /// <summary>
    /// 隐藏鼠标按下后跟随的图标DragItem
    /// </summary>
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 图标跟随鼠标移动
    /// </summary>
    /// <param name="postion">鼠标当前位置的世界坐标</param>
    public void SetLocalPositon(Vector2 postion)
    {
        transform.localPosition = postion;
    }

    public void setImage(int id)
    {
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(id);
        image.name = info.name_Icon;
        string path = "Icon/" + info.name_Icon;
        image.sprite = Resources.Load(path) as Sprite;
        
    }
}
