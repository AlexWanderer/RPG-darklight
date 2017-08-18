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
    public Text coinText;
    public GameObject bagItem;
    public DragItemUI dragItem;
    public Camera uiCamera;
    public ItemDecUI itemDecUI;
    public Player_State playerState; //玩家状态
    

    private bool isDrag = false; //用于判断是否处于拖拽
    private bool showingBag = false; //用于判断背包是否在显示
    private bool showingDec = false; //用于判断详情面板是否显示
    private bool getSuccess = false; //用于判断是否成功放入背包
    private bool dressSuccess = false;
    private BagItemGrid dressGrid = null;

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
            GetID(Random.Range(2001,2023));
           
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

        
        //按下右键穿戴装备 or 使用药水
        if (Input.GetMouseButtonDown(1)&& dressGrid != null)
        {
            if (dressGrid.id != 0)
            {
                switch (dressGrid.info.type)
                {
                    case objectType.Drug:
                        break;
                    case objectType.Equip:  //穿戴装备
                        
                        dressSuccess = Equipment._instanceEquip.DressEquipment(dressGrid.info);
                        if (dressSuccess)
                        {
                            if (dressGrid.count > 1)  //判断装备数量  大于1则数量减一更新显示
                            {
                                dressGrid.count--;
                                dressGrid.itemCount.text = dressGrid.count.ToString()
    ;
                            }
                            else
                            {  //如果装备数量为1  则删除图标并清空格子
                                Destroy(dressGrid.transform.GetChild(1).gameObject);
                                dressGrid.Clear();
                            }
                        }
                        break;
                }

            }
           
        }
    }

    /// <summary>
    /// 拾取到id的物品，并添加到物品栏里面
    /// 处理拾取物品的功能
    /// </summary>
    /// <param name="id"></param>
    public bool GetID(int id, int count = 1)
    {
        //查找在所有物品中是否有该物品
        //如果存在 count +1 
        //不存在，查找空的方格，然后把新创建的BagItem放到这个空的方格中
        getSuccess = false;
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
            grid.PlusCount(count);
            getSuccess = true;
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
                grid.SetByID(id,count);
                getSuccess = true;
            }
        }
        return getSuccess;
    }

    /// <summary>
    /// 用于显示背包
    /// </summary>
    private void ShowBag()
    {
        showingBag = true;
        UpdateGold();
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

    /// <summary>
    /// 鼠标进入显示物品详情
    /// </summary>
    /// <param name="gridTransform"></param>
    private void BagItemGrid_OnEnter(Transform gridTransform)
    {
        BagItemGrid bagItemGrid = gridTransform.gameObject.GetComponent<BagItemGrid>();
        ObjectInfo info = bagItemGrid.info;
        if (info == null)
        {
            return;
        }
        dressGrid = bagItemGrid;
        itemDecUI.ShowDec();
        string text = GetDecText(info);
        itemDecUI.UpdateText(text);
        showingDec = true;

    }

    /// <summary>
    /// 鼠标移开隐藏物品详情
    /// </summary>
    private void BagItemGrid_OnExit()
    {
        dressGrid = null;
        itemDecUI.CloseDec();
        showingDec = false;
    }

    /// <summary>
    /// 获取物品详情的文本
    /// </summary>
    /// <param name="decInfo"></param>
    /// <returns></returns>
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
                string strEquip = decInfo.equipmentType.ToString();
                string strApp = decInfo.appType.ToString();
                str.AppendFormat("装备类型：{0}\n职业：{1}\n攻击力：{2}\n防御力：{3}\n速度：{4}\n\n", strEquip, strApp, decInfo.attackValue, decInfo.defValue, decInfo.speedValue);
                break;
            case objectType.Mat:
                break;
        }

        str.AppendFormat("<size=16><color=yellow>购买价格：{0}\n出售价格：{1}\n\n</color></size>", decInfo.price_Buy, decInfo.price_Sell);
        return str.ToString();
    }

    /// <summary>
    /// 更新金币数量
    /// </summary>
    public void UpdateGold()
    {
        coinText.text = playerState.gold.ToString();
    }

    
}
