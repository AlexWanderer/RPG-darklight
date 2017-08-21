using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour {

    public static SkillUI _instance;
    public GameObject skillGridPrefab;
    public GameObject dragIcon;

    private string path;

    private bool showingDragIcon = false;

    private void Awake()
    {
        _instance = this;
        
    }

    private void Update()
    {
        Vector2 position;
        RectTransformUtility.ScreenPointToLocalPointInRectangle
            (GameObject.Find("SkillUI").transform as RectTransform, Input.mousePosition, null, out position);
        if (showingDragIcon)
        {
            dragIcon.transform.localPosition = position;
        }

    }

    private void Start()
    {
        GetSkills();
        UpdateShow();
        SkillIconDrag.BeginDrag += SkillIconDrag_BeginDrag;
        SkillIconDrag.EndDrag += SkillIconDrag_EndDrag;
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

    /// <summary>
    /// 获取魔法师技能
    /// </summary>
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

    /// <summary>
    /// 获取剑士技能
    /// </summary>
    private void Swordman()
    {

    }

    private void SkillIconDrag_BeginDrag(int id)
    {
        SkillInfo info = SkillsInfo._instanceSkill.GetSkillInfo(id);
        path = "Icon/" + info.iconName;
        dragIcon.SetActive(true);
        Image dragIcon_Imag = dragIcon.GetComponent<Image>();
        dragIcon_Imag.sprite = Resources.Load(path,typeof(Sprite)) as Sprite;
        dragIcon_Imag.rectTransform.sizeDelta = new Vector2(70, 70);
        showingDragIcon = true;
    }

    private void SkillIconDrag_EndDrag(Transform enterTransfrom,int id)
    {
        showingDragIcon = false;
        dragIcon.SetActive(false);
        if (enterTransfrom.tag == Tags.shotCutGrid)
        {
            enterTransfrom.GetComponent<ShotCutGrid>().id = id;
            enterTransfrom.GetChild(0).gameObject.SetActive(true);
            Image image = enterTransfrom.GetChild(0).GetComponent<Image>();
            image.sprite = Resources.Load(path, typeof(Sprite)) as Sprite;
        }
    }


    public void UpdateShow()
    {
        SkillGrid[] grids = transform.Find("Panel/Grid").GetComponentsInChildren<SkillGrid>();
        foreach (SkillGrid grid in grids)
        {
            Debug.Log(grid.skillID);
            grid.CheckLevel(Player_State._instancePlayerState.level);
        }
    }

}
