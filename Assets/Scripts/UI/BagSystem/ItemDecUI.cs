using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDecUI : MonoBehaviour {

    private Text itemDec;
    private Text decText;

    private void Awake()
    {
        itemDec = this.GetComponent<Text>();
        decText = transform.GetChild(1).gameObject.GetComponent<Text>();
    }

    public void UpdateText(string dec)
    {
        itemDec.text = dec;
        decText.text = dec;
    }

    public void ShowDec()
    {
        gameObject.SetActive(true);
    }

    public void CloseDec()
    {
        gameObject.SetActive(false);
    }

    public void SetLocalPosition(Vector2 position)
    {
        transform.localPosition = position;
    }
}
