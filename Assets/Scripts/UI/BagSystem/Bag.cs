using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

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
    public DragItemUI dragItem;
    public Camera uiCamera;
    public ItemDecUI itemDecUI;

    private bool isDrag = false; //用于判断是否处于拖拽
    private bool showingBag = false; //用于判断背包是否在显示
    private bool showingDec = false; //用于判断详情面板是否显示

    private void Awake()
    {
        _intanceBag = this;
        transform.localPosition = closeBagPos;
        BagItemGrid.OnLeftBeginDrag += BagItemGrid_OnLeftBeginDrag;
        BagItemGrid.OnLeftEndDrag += BagItemGrid_OnLeftEndDrag;
        BagItemGrid.OnEnter += BagItemGrid_OnEnter;
        BagItemGrid.OnExit += BagItemGrid_OnExit;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetID(Random.Range(1001, 1004));
        }

        Vector2 position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Bag").transform as RectTransform, Input.mousePosition, uiCamera, out position);
        if (isDrag)
        {
            
            dragItem.SetLocalPositon(position);
        }
        if (showingDec)
        {
            
            itemDecUI.SetLocalPosition(position);
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
    private void ShowBag()
    {
        showingBag = true;
        transform.localPosition = showBagPos;
    }

    /// <summary>
    /// 用于隐藏背包
    /// </summary>
    private void CloseBag()
    {
        showingBag = false;
        transform.localPosition = closeBagPos;
    }

    /// <summary>
    /// 用于检测背包状态并执行的对应的显示或关闭
    /// </summary>
    public void BagState()  
    {
        if (showingBag)
        {
            CloseBag();
        }
        else ShowBag();
    }

    /// <summary>
    /// 拖拽物品开始时的处理
    /// </summary>
    /// <param name="gridTransform">被拖拽物所在的格子</param>
    private void BagItemGrid_OnLeftBeginDrag(Transform gridTransform)
    {
        if (gridTransform.childCount == 1)
        {
            return;
        }          
        else
        {
            dragItem.Show();
            BagItemGrid bagItemGrid = gridTransform.gameObject.GetComponent<BagItemGrid>();  //获取gridT染上form身上的gridItemGrid
            
            dragItem.setImage(bagItemGrid.id);
            //Destroy(gridTransform.GetChild(1).gameObject);
            gridTransform.GetChild(1).gameObject.GetComponent<Image>().enabled = false;
            isDrag = true;
        }
    }

    /// <summary>
    /// 拖拽结束后的处理
    /// </summary>
    /// <param name="oldTransform">被拖拽物品原所在的格子</param>
    /// <param name="enterTransform">被拖拽物品现所在的格子</param>
    private void BagItemGrid_OnLeftEndDrag(Transform oldTransform,Transform enterTransform)
    {
        if (isDrag == true)
        {
            isDrag = false;

            dragItem.Hide();
            if (enterTransform == null)  //将物品扔出背包
            {
                Destroy(oldTransform.GetChild(1).gameObject);
                BagItemGrid bagItemGrid = oldTransform.gameObject.GetComponent<BagItemGrid>();
                bagItemGrid.Clear();
            }
            else if (enterTransform.tag == Tags.grid)
            {
                BagItemGrid bagItemGrid = oldTransform.gameObject.GetComponent<BagItemGrid>();
                BagItemGrid enterGrid = enterTransform.gameObject.GetComponent<BagItemGrid>();
                if (enterTransform.childCount == 1) //将物品拖到一个新的地方
                {
                    GameObject itemGo = Instantiate(bagItem, enterTransform);
                    itemGo.transform.localPosition = Vector3.zero;
                    enterGrid.SetByID(bagItemGrid.id, bagItemGrid.count);
                    Destroy(oldTransform.GetChild(1).gameObject);
                    bagItemGrid.Clear();
                }
                else //物品位置交换
                {
                    int oldID = bagItemGrid.id;
                    int oldCount = bagItemGrid.count;
                    oldTransform.GetChild(1).gameObject.GetComponent<Image>().enabled = true;
                    bagItemGrid.SetByID(enterGrid.id, enterGrid.count);

                    enterGrid.SetByID(oldID, oldCount);

                }
            }
            else //拖到了背包的其他地方，位置复原
            {
                oldTransform.GetChild(1).gameObject.GetComponent<Image>().enabled = true;
            }
        }
        
    }

    private void BagItemGrid_OnEnter(Transform gridTransform)
    {
        BagItemGrid bagItemGrid = gridTransform.gameObject.GetComponent<BagItemGrid>();
        ObjectInfo info = bagItemGrid.info;
        if (info == null)
        {
            return;
        }
        itemDecUI.ShowDec();
        string text = GetDecText(info);
        itemDecUI.UpdateText(text);
        showingDec = true;
    }

    private void BagItemGrid_OnExit()
    {
        itemDecUI.CloseDec();
        showingDec = false;
    }

    private string GetDecText(ObjectInfo decInfo)
    {
        if (decInfo == null)
        {
            return "";
        }
        StringBuilder str = new StringBuilder();
        str.AppendFormat("<color=red>{0}</color>\n\n", decInfo.name);
        switch (decInfo.type)
        {
            case objectType.Drug:
                str.AppendFormat("回血量：{0}\n回蓝量：{1}\n\n", decInfo.recover_HP, decInfo.recover_MP);
                break;
            case objectType.Equip:
                break;
            case objectType.Mat:
                break;
        }

        str.AppendFormat("<size=16><color=yellow>购买价格：{0}\n出售价格：{1}\n\n</color></size>", decInfo.price_Buy, decInfo.price_Sell);
        return str.ToString();
    }
}
