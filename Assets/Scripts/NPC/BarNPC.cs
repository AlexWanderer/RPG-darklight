using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarNPC : MonoBehaviour {

    public GameObject quest;
    public GameObject accpet;
    public GameObject cancle;
    public GameObject oK;
    public Text barMissionDec;

    private bool isAccept = false;
    public int killCount = 0;
    private Player_State playerState;

    void Start () {
        playerState = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_State>();
	}
	
	void Update () {
		
	}

    /// <summary>
    /// 当鼠标停留在BarNPC上时，检测是否发生点击
    /// </summary>
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isAccept)
            {
                quest.SetActive(true);
                barMissionDec.text = "已杀死" + killCount + "//5只小狼\n奖励：\n1000金币";
                oK.SetActive(true);
                accpet.SetActive(false);
                cancle.SetActive(false);
            }
            else
            {
                

                quest.SetActive(true);
                barMissionDec.text = "目标：\n杀死5只小狼\n奖励：\n1000金币";               
                oK.SetActive(false);
                accpet.SetActive(true);
                cancle.SetActive(true);
            }

        }
    }

    /// <summary>
    /// 当按下Accpet按键
    /// </summary>
    public void ClickAccpetButton()
    {
        isAccept = true;
        quest.SetActive(false);

    }

    /// <summary>
    /// 当按下Cancle按键
    /// </summary>
    public void ClickCancleButton()
    {
            quest.SetActive(false);      
    }

    /// <summary>
    /// 当按下OK按钮
    /// </summary>
    public void ClickOKButton()
    {
        if (killCount == 5)
        {
            playerState.AddGold(1000);
            isAccept = false;
            quest.SetActive(false);
        }
        if (killCount != 5)
        {
            quest.SetActive(false);
        }
    }
}
