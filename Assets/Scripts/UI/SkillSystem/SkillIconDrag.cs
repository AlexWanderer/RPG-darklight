using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkillIconDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static Action<int> BeginDrag;
    public static Action<Transform,int> EndDrag;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (BeginDrag != null)
            {
                SkillGrid skillGrid = transform.parent.gameObject.GetComponent<SkillGrid>();
                BeginDrag(skillGrid.skillID);
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (EndDrag != null)
            {
                SkillGrid skillGrid = transform.parent.gameObject.GetComponent<SkillGrid>();
                EndDrag(eventData.pointerEnter.transform,skillGrid.skillID);
            }
        }
    }
}
