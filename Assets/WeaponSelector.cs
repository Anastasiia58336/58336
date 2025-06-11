using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour

{

    public GameObject weaponSelectionPanel; 

    public Button orbButton;                 

    public Button shootButton;             

    public GameObject orbWeapon;             

    public GameObject shootingWeapon;        

    void Start()

    {

        weaponSelectionPanel.SetActive(true);

        orbWeapon.SetActive(false);

        shootingWeapon.SetActive(false);

      

        orbButton.onClick.AddListener(SelectOrb);

        shootButton.onClick.AddListener(SelectShooting);

    }

    void SelectOrb()

    {

        PlayerPrefs.SetInt("SelectedWeapon", 0);


        orbWeapon.SetActive(true);

        shootingWeapon.SetActive(false);

 

        weaponSelectionPanel.SetActive(false);

    }

    void SelectShooting()

    {

       

        PlayerPrefs.SetInt("SelectedWeapon", 1);

       

        orbWeapon.SetActive(false);

        shootingWeapon.SetActive(true);

      

        weaponSelectionPanel.SetActive(false);

    }

}