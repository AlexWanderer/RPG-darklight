using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotCutGrid : MonoBehaviour {

    public KeyCode key;
    public int id;
    private Text key_Tx;

    private void Awake()
    {
        key_Tx = transform.FindChild("Key").gameObject.GetComponent<Text>();
    }

    private void Update()
    {
        //当按下快捷键时执行
        if (Input.GetKeyDown(key))
        {

        }
    }

    /// <summary>
    /// 用于更改快捷方式
    /// </summary>
    /// <param name="changeKey"></param>
    public void ChangeKey(KeyCode changeKey)
    {
        key = changeKey;
        key_Tx.text = key.ToString();
    }
}
