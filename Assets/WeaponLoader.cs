using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLoader : MonoBehaviour

{

    public GameObject orbWeapon;

    public GameObject shootingWeapon;

    void Start()

    {

        int selectedWeapon = PlayerPrefs.GetInt("SelectedWeapon", -1);

        if (selectedWeapon == 0)

        {

            orbWeapon.SetActive(true);

            shootingWeapon.SetActive(false);

        }

        else if (selectedWeapon == 1)

        {

            orbWeapon.SetActive(false);

            shootingWeapon.SetActive(true);

        }

        else

        {

           

            orbWeapon.SetActive(false);

            shootingWeapon.SetActive(false);

        }

    }

}