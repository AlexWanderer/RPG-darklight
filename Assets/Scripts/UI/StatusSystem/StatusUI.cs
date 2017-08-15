using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUI : MonoBehaviour {

    public static StatusUI _instanceStatus;
   
    public Player_State playerState;

    private Text attackTx;
    private Text defTx;
    private Text speedTx;
    private Text pointRemainTx;
    private Text summaryTx;
    private Button attackPlusBt;
    private Button defPlusBt;
    private Button speedPlusBt;

    

    private void Awake()
    {
        _instanceStatus = this;

        attackTx = transform.Find("Attack").gameObject.GetComponent<Text>();
        defTx = transform.Find("Def").gameObject.GetComponent<Text>();
        speedTx = transform.Find("Speed").gameObject.GetComponent<Text>();
        pointRemainTx = transform.Find("PointRemain").gameObject.GetComponent<Text>();
        summaryTx = transform.Find("Summary").gameObject.GetComponent<Text>();
        attackPlusBt = transform.Find("AttackPlusButton").gameObject.GetComponent<Button>();
        defPlusBt = transform.Find("DefPlusButton").gameObject.GetComponent<Button>();
        speedPlusBt = transform.Find("SpeedPlusButton").gameObject.GetComponent<Button>();

    }

    

    /// <summary>
    /// 用于更新status面板所显示的数据
    /// </summary>
    public void UpdateStatus()
    {
        attackTx.text = playerState.attack + "+" + playerState.attack_plus;
        defTx.text = playerState.def + "+" + playerState.def_plus;
        speedTx.text = playerState.speed + "+" + playerState.speed_plus;

        pointRemainTx.text = playerState.point_remain.ToString();
        ShowAddButton();
        summaryTx.text = "伤害：" + (playerState.attack + playerState.attack_plus) + "  防御：" + (playerState.def + playerState.def_plus) + "  速度：" + (playerState.speed + playerState.speed_plus);
    }

    /// <summary>
    /// 用于处理加点的按钮的显示与隐藏
    /// </summary>
    private void ShowAddButton()
    {
        if (playerState.point_remain <= 0)
        {
            attackPlusBt.gameObject.SetActive(false);
            defPlusBt.gameObject.SetActive(false);
            speedPlusBt.gameObject.SetActive(false);
        }
        else
        {
            attackPlusBt.gameObject.SetActive(true);
            defPlusBt.gameObject.SetActive(true);
            speedPlusBt.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// 伤害加点
    /// </summary>
    public void AtttckPlusBtClick()
    {
        bool check = playerState.GetPoint();
        if (check)
        {
            playerState.attack_plus++;
            UpdateStatus();
        }
    }

    /// <summary>
    /// 防御加点
    /// </summary>
    public void DefPlusBtClick()
    {
        bool check = playerState.GetPoint();
        if (check)
        {
            playerState.def_plus++;
            UpdateStatus();
        }
    }

    /// <summary>
    /// 速度加点
    /// </summary>
    public void SpeedPlusBtClick()
    {
        bool check = playerState.GetPoint();
        if (check)
        {
            playerState.speed_plus++;
            UpdateStatus();
        }
    }
}
