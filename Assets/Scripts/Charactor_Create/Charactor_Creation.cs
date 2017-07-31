using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 用于选择角色，如向前向后的处理，获取名字等
/// </summary>
public class Charactor_Creation : MonoBehaviour {

    public GameObject[] charactor_perfab;
    private GameObject[] charactor;
    private int prefab_len;
    private int index = 0;

    //获取所取的游戏名称
    public Text name_text;

	void Start () {
        prefab_len = charactor_perfab.Length;
        int i = 0;
        charactor = new GameObject[prefab_len];
        for(i = 0; i < prefab_len; i++)
        {
            charactor[i] = GameObject.Instantiate(charactor_perfab[i], transform.position, transform.rotation);
            charactor[i].SetActive(false);
        }
        charactor[0].SetActive(true);
	}
	

	void Update () {
		
	}

    /// <summary>
    /// 选择下一个人物
    /// </summary>
    public void Next()
    {
        
        charactor[index].SetActive(false);
        index++;
        index %= prefab_len;
        charactor[index].SetActive(true);
 
    }

    /// <summary>
    /// 选择上一个人物
    /// </summary>
    public void Prev()
    {
        if (index == 0)
        {
            charactor[index].SetActive(false);
            index = prefab_len - 1;
            charactor[index].SetActive(true);
        }
        else
        {
            charactor[index].SetActive(false);
            index--;
            charactor[index].SetActive(true);
        }
    }

    /// <summary>
    /// 按下OK键
    /// </summary>
    public void OnOKClick()
    {
        PlayerPrefs.SetInt("CharactorIndex", index);
        PlayerPrefs.SetString("PlayerName", name_text.text);
        

        //加载游戏场景
    }
}
