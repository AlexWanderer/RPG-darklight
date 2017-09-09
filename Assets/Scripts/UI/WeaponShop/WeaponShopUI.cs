using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopUI : MonoBehaviour {
    public static WeaponShopUI _instance;
    public GameObject weaponPrefab;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        GetWeaponsInfo();
    }

    private void GetWeaponsInfo()
    {
        for (int i = 2001; i <= 2022; i++)
        {
            GameObject weapon = Instantiate(weaponPrefab, transform.Find("Panel/Grid").transform);
            weapon.transform.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            WeaponItem weaponItem = weapon.GetComponent<WeaponItem>();
            weaponItem.SetWeaponInfo(i);
        }
    }
}
