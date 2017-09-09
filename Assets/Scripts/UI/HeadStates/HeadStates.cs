using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeadStates : MonoBehaviour {

    public Text name_Tx;
    public Text nameUnder_Tx;
    public Image hp_Imag;
    public Image mp_Imag;
    public Text hp_Tx;
    public Text mp_Tx;

    private Player_State playerState;

    private void Start()
    {
        playerState = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<Player_State>();
        UpdateHeadStates();
    }

    public void UpdateHeadStates()
    {
        name_Tx.text = "Lv." + playerState.level + " " + playerState.playerName;
        nameUnder_Tx.text = name_Tx.text;
        hp_Imag.fillAmount = playerState.hpRemain / playerState.HP;
        mp_Imag.fillAmount = playerState.mpRemain / playerState.MP;
        hp_Tx.text = playerState.hpRemain + "/" + playerState.HP;
        mp_Tx.text = playerState.mpRemain + "/" + playerState.MP;
    }

}
