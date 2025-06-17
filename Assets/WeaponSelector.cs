using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelector : MonoBehaviour
{
    public GameObject weaponSelectionPanel;

    public Button orbButton;
    public Button shootButton;

    public GameObject orbWeapon;
    public GameObject shootingWeapon;

    public GameObject spaceHintText;

    void Start()
    {
        weaponSelectionPanel.SetActive(true);
        orbWeapon.SetActive(false);
        shootingWeapon.SetActive(false);

        if (spaceHintText != null)
            spaceHintText.SetActive(false); 

        Time.timeScale = 0f;

        orbButton.onClick.AddListener(SelectOrb);
        shootButton.onClick.AddListener(SelectShooting);
    }

    void SelectOrb()
    {
        PlayerPrefs.SetInt("SelectedWeapon", 0);

        orbWeapon.SetActive(true);
        shootingWeapon.SetActive(false);
        weaponSelectionPanel.SetActive(false);

        if (spaceHintText != null)
        {
            spaceHintText.SetActive(true);
            StartCoroutine(HideTextAfterDelay(2f));
        }

        Time.timeScale = 1f;
    }

    void SelectShooting()
    {
        PlayerPrefs.SetInt("SelectedWeapon", 1);

        orbWeapon.SetActive(false);
        shootingWeapon.SetActive(true);
        weaponSelectionPanel.SetActive(false);

        FindObjectOfType<MessageUI>()?.ShowMessage("Press <Space> to shoot!");

        Time.timeScale = 1f;
    }

    IEnumerator HideTextAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); 
        spaceHintText.SetActive(false);
    }
}