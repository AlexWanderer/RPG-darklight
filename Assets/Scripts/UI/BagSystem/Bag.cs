using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 用于管理背包
/// </summary>
public class Bag : MonoBehaviour {

    public static Bag _intanceBag;

    public Vector3 closeBagPos = new Vector3(650, 0, 0);
    public Vector3 showBagPos = new Vector3(180, 0, 0);

    public List<BagItemGrid> itemGridList = new List<BagItemGrid>();
    public int coinCount = 1000;
    public Text coinText;
    public GameObject bagItem;

    private void Awake()
    {
        _intanceBag = this;
       // transform.position = closeBagPos;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetID(Random.Range(1001, 1004));
        }
    }

    /// <summary>
    /// 拾取到id的物品，并添加到物品栏里面
    /// 处理拾取物品的功能
    /// </summary>
    /// <param name="id"></param>
    public void GetID(int id)
    {
        //查找在所有物品中是否有该物品
        //如果存在 count +1 
        //不存在，查找空的方格，然后把新创建的BagItem放到这个空的方格中

        BagItemGrid grid = null;
        foreach (BagItemGrid temp in itemGridList)
        {
            if (temp.id == id)
            {
                grid = temp;
                break;
            }
        }
        if(grid != null)
        {
            grid.PlusCount();
        }
        else
        {
            foreach (BagItemGrid temp in itemGridList)
            {
                if(temp.id == 0)
                {
                    grid = temp;
                    break;
                }               
            }
            if (grid != null)
            {
                GameObject itemGo = Instantiate(bagItem,grid.transform);
                itemGo.transform.localPosition = Vector3.zero;
                grid.SetByID(id);
            }
        }
    }

    /// <summary>
    /// 用于显示背包
    /// </summary>
    public void ShowBag()
    {
        transform.position = showBagPos;
    }

    /// <summary>
    /// 用于隐藏背包
    /// </summary>
    public void CloseBag()
    {
        transform.position = closeBagPos;
    }
}
