using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrugItem : MonoBehaviour {

    public int id;
    public ShopDrugUI shopDrug;

 

    /// <summary>
    /// 用于获得购买物品的ID
    /// </summary>
    public void GetBuyID()
    {
        shopDrug.drugID = id;
    }
}
