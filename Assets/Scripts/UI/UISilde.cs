using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 用于UI从场外滑入场内
/// </summary>
public class UISilde : MonoBehaviour {

    public float speed = 0.8f;
    private Slider m_slider;

	void Start () {
        m_slider = this.GetComponent<Slider>();
	}
	
	
	void Update () {
        UISlideIn();
        
	}

    void UISlideIn() {
        m_slider.value = m_slider.value + speed * Time.deltaTime;
        m_slider.value = Mathf.Clamp(m_slider.value, 0, 1);
    }
}
