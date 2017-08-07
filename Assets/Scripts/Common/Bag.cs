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

    private void Awake()
    {
        _intanceBag = this;
        transform.position = closeBagPos;
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
