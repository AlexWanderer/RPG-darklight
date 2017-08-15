using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionNPC : NPC {

    public GameObject shopDrug;
    private bool showingShopDrug = false; //用于判断商店是否已经显示
    
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!showingShopDrug)
            {
                shopDrug.SetActive(true);
                showingShopDrug = true;
            }
            
        }
        
    }

    public void CloseShopDrug()
    {
        showingShopDrug = false;
        shopDrug.SetActive(false);
    }
}
