using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour {

    public static SkillUI _instance;
    public GameObject skillGridPrefab;

    private void Awake()
    {
        _instance = this;
        
    }

    private void Start()
    {
        GetSkills();
    }

    public void GetSkills()
    {
        switch (Player_State._instancePlayerState.profession)
        {
            case Player_State.Profession.Magician:
                MagicianSkills();
                break;
            case Player_State.Profession.Swordman:
                break;
        }
    }

    private void MagicianSkills()
    {
        for (int i = 5001; i <= 5006; i++)
        {
            GameObject skillGridGO = Instantiate(skillGridPrefab, transform.Find("Panel/Grid"));
            skillGridGO.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            SkillGrid skillGrid = skillGridGO.GetComponent<SkillGrid>();
            skillGrid.SetSkill(i);
        }
    }

    private void Swordman()
    {

    }
}
