using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragItemUI : BagItem {

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
	
}
