using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 管理所有的光标变化
/// </summary>
public class CursorManager : MonoBehaviour {

    public static CursorManager _instance;

    public Texture2D Cursor_Attack;
    public Texture2D Cursor_LockTarget;
    public Texture2D Cursor_Normal;
    public Texture2D Cursor_Npc_Talk;
    public Texture2D Cursor_Pick;

    private Vector2 hostpot = Vector2.zero;
    private CursorMode mode = CursorMode.Auto;

    private void Start()
    {
        _instance = this;
    }

    /// <summary>
    /// 光标设置为普通
    /// </summary>
    public void SetNormal()
    {
        Cursor.SetCursor(Cursor_Normal, hostpot, mode);
    }

    /// <summary>
    /// 光标设置为与NPC对话
    /// </summary>
    public void SetNpcTalk()
    {
        Cursor.SetCursor(Cursor_Npc_Talk, hostpot, mode);
    }
}
