﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用于控制开始游戏与继续游戏按钮的逻辑处理
/// </summary>
public class ButtonToStart : MonoBehaviour {

    public void ToNewGame() {
        PlayerPrefs.SetInt("DataFromSave",0);
    }

    public void ToLoadGame() {
        PlayerPrefs.SetInt("DataFromSave", 1);  //DataFromSave表示数据来自保存
    }
}
