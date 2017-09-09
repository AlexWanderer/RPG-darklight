using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour {

    public static ExpBar _instanceExp;

    public Image exp;

    private void Awake()
    {
        _instanceExp = this;
    }

    public void UpdateExp(float percent)
    {
        exp.fillAmount = percent;
    }

}
