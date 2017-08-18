using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentGrid : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static Action<Transform> OnEnterEquip;
    public static Action OnExitEquip;
    public int id = 0;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag == Tags.equipGrid)
        {
            if (OnEnterEquip != null)
            {
                OnEnterEquip(transform);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter.tag == Tags.equipGrid)
        {
            if (OnEnterEquip != null)
            {
                OnExitEquip();
            }
        }

    }
}
