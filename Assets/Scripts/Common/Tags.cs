using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 用于存储gameobject的标签，可直接调用
/// </summary>
public class Tags : MonoBehaviour {

    public const string ground = "Ground";  //Terrain 地面标签 
    public const string player = "Player";  //玩家标签
    public const string grid = "Grid";  //背包格子
    public const string equipGrid = "EquipGrid"; //装备格子
    public const string shotCutGrid = "ShotCutGrid"; //快捷栏
    public const string minimapCamera = "MiniMapCamera"; //小地图摄像机
}
