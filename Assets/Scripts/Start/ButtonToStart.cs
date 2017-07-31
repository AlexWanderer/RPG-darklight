using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToStart : MonoBehaviour {

    public void ToNewGame() {
        PlayerPrefs.SetInt("DataFromSave",0);
    }

    public void ToLoadGame() {
        PlayerPrefs.SetInt("DataFromSave", 1);  //DataFromSave表示数据来自保存
    }
}
