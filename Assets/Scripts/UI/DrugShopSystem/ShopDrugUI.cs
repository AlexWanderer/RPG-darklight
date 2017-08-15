using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopDrugUI : MonoBehaviour {

    public GameObject buyCount;
    public int drugID;  //购买物品的ID
    public Text buyCountText;  //用于获取购买的数量
    public Text placeholder;

    public GameObject tip;
    public Text tipText;
    public Camera uiCamera;

    private int count = 1;


    /// <summary>
    /// 按下buyButton后
    /// </summary>
    public void BuyButtonClick()
    {
        Vector2 pos = GetMousePosition();
        buyCount.SetActive(true);
        buyCount.transform.localPosition = pos;
    }

    /// <summary>
    /// 按下Ok按钮后
    /// </summary>
    public void OKButtonClick()
    {
        //获取买的什么
        ObjectInfo info = ObjectsInfo._instance.GetObjectInfoById(drugID);
        //获取买了多少

        count = int.Parse(buyCountText.text.ToString()) ;
        

        int totalMoney = count * info.price_Buy;  //购买的总价
        //判断金钱是否足够
        if (totalMoney <= Player_State._instancePlayerState.gold)
        {
            //足够
            //判断背包是否已经有了这个物品
            //有，扣除金币放入背包，既更改物品的数量
            //没有
            //判断背包是否有空余位置
            //有，扣除金币放入背包，既在空的位置创建新的物品
            //没有，给出提示

            bool getSuccess = false;  //用于获取放入背包是否成功
            getSuccess = Bag._intanceBag.GetID(drugID, count);
            if (getSuccess)
            {
                Player_State._instancePlayerState.AddGold(-totalMoney);
                Bag._intanceBag.UpdateGold();
            }
            else
            {
                tip.SetActive(true);
                tipText.text = "背包满了";
            }
        }
        else
        {
            //不够，给出提示
            tip.SetActive(true);
            tipText.text = "金币不足";
        }

        buyCount.SetActive(false);
    }

    /// <summary>
    /// 用于获得鼠标位置
    /// </summary>
    private Vector2 GetMousePosition()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("DrugShop").transform as RectTransform, Input.mousePosition
            , uiCamera, out position);
        return position;
    }

    /// <summary>
    /// 按下TipOkButton
    /// </summary>
    public void TipOKButtonClick()
    {
        tip.gameObject.SetActive(false);
    }
	
}
