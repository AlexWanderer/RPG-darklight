using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNPC : NPC {

    public GameObject shopUI;
    private bool showingWeaponShop = false;


    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (!showingWeaponShop)
            {
                shopUI.SetActive(true);
                showingWeaponShop = true;
            }
            else
            {
                CloseWeaponShop();
            }
        }
    }

    public void CloseWeaponShop()
    {
        shopUI.SetActive(false);
        showingWeaponShop = false;
    }
}
