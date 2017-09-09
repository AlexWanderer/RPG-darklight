using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfBaby : MonoBehaviour {

    public float walkSpeed = 1;
    public int Hp = 100;
    public AudioClip missSound;
    public bl_HUDText HUDText;
    public int m_size = 11;
    public float m_speed = 20f;
    public float m_yAcceleration = -1f;
    public float m_yAccelerationScaleFactor = 2.2f;
    public bl_Guidance m_movement = bl_Guidance.Up;

    private Animation anima;
    private WolfBabyState state = WolfBabyState.Idle;
    private CharacterController cc;
    private int flag = 0;
    private float miss_Rate = 0.2f;
    private Color normalColor;
    private GameObject wolfBabyMat;

    private void Awake()
    {
        cc = gameObject.GetComponent<CharacterController>();
        anima = gameObject.GetComponent<Animation>();
        InvokeRepeating("RangeFlag", 2, 2);
        wolfBabyMat = transform.FindChild("Wolf_Baby").gameObject;
    }

    private void Start()
    {
        normalColor = wolfBabyMat.GetComponent<Renderer>().material.color;
    }

    void Update () {
        if (state == WolfBabyState.Death)
        {
            anima.Play(Animations.wbaby_Death);
        } else if (state == WolfBabyState.Attack)
        {
            //自动攻击
        }else
        {
            //巡逻
            Patrol();
        }

        //测试受伤害
        if(Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage(1);
        }
	}

    /// <summary>
    /// 巡逻
    /// </summary>
    private void Patrol()
    {
        if(flag == 0)
        {
            state = WolfBabyState.Idle;
        }else if (flag == 1)
        {
            state = WolfBabyState.Walk;
        }

        if(state == WolfBabyState.Walk)
        {
            cc.SimpleMove(transform.forward * walkSpeed);
            anima.Play(Animations.wbaby_Walk);
        }else if (state == WolfBabyState.Idle)
        {
            anima.Play(Animations.wbaby_Idel);
        }
    }

    /// <summary>
    /// 随机巡逻还是站立
    /// </summary>
    private void RangeFlag()
    {
        flag = Random.Range(0, 2);
        if(flag == 1)
        {
            transform.Rotate(transform.up * Random.Range(0, 360));
        }
        
    }

    public void TakeDamage(int attack)
    {
        float value = Random.Range(0f, 1f);
        if (value < miss_Rate)
        {
            //显示Miss效果
            if (value < miss_Rate)
            {
                AudioSource.PlayClipAtPoint(missSound, transform.position);
                HUDText.NewText("Miss", base.transform, Color.white, m_size, m_speed, m_yAcceleration, m_yAccelerationScaleFactor, m_movement);
            }
        }
        else
        {
            //命中受到伤害
            //减血
            Hp -= attack;
            //线程变红
            StartCoroutine(ShowBodyRed());

            HUDText.NewText("- " + attack.ToString(), base.transform, Color.red, 11, 20f, -1f, 1f, bl_Guidance.Down);
            //判断是否死亡
            if (Hp <= 0)
            {
                state = WolfBabyState.Death;
                Destroy(this.gameObject, 2);
            }
        }
    }

    /// <summary>
    /// 受到攻击身体变红
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowBodyRed()
    {
        wolfBabyMat.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(1f);
        wolfBabyMat.GetComponent<Renderer>().material.color = normalColor;
    }
}
