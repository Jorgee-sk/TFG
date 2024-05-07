using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SetPrefabImage : MonoBehaviour
{
    public ListImages listImages;
    public Button setPlayerButton;
    public Button setEnemyButton;
    public Button setBackgroundButton;
    public Button setBulletButton;
    public Button setWallButton;
    public Button setLifePowerUpButton;
    public Button setShootPowerUpButton;
    public Button setSpeedPowerUpButton;
    public Button setScoreItemButton; //La moneda

    // Start is called before the first frame update
    void OnEnable()
    {
        if (setPlayerButton != null)
        {
            setPlayerButton.onClick.AddListener(() => ChangePlayerPrefabImage());
        }

        if (setEnemyButton != null)
        {
            setEnemyButton.onClick.AddListener(() => ChangeEnemyPrefabImage());
        }

        if (setBackgroundButton != null)
        {
            setBackgroundButton.onClick.AddListener(() => ChangeBackgroundPrefabImage());
        }

        if (setBulletButton != null)
        {
            setBulletButton.onClick.AddListener(() => ChangeBulletPrefabImage());
        }

        if (setWallButton != null)
        {
            setWallButton.onClick.AddListener(() => ChangeTilePrefabImage());
        }

        if (setLifePowerUpButton != null)
        {
            setLifePowerUpButton.onClick.AddListener(() => ChangeLifePowerUp());
        }

        if (setShootPowerUpButton != null)
        {
            setShootPowerUpButton.onClick.AddListener(() => ChangeShootPowerUp());
        }

        if (setSpeedPowerUpButton != null)
        {
            setSpeedPowerUpButton.onClick.AddListener(() => ChangeSpeedPowerUp());
        }

        if (setScoreItemButton != null)
        {
            setScoreItemButton.onClick.AddListener(() => ChangeScoreItem());
        }
    }

    void ChangePlayerPrefabImage()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("playerImage", listImages.GetCurrentImageName());
        }

        EventSystem.current.SetSelectedGameObject(null);
    }

    void ChangeEnemyPrefabImage()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("enemyImage", listImages.GetCurrentImageName());
        }

        EventSystem.current.SetSelectedGameObject(null);
    }

    void ChangeBackgroundPrefabImage()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("bgImage", listImages.GetCurrentImageName());
        }

        EventSystem.current.SetSelectedGameObject(null);
    }

    void ChangeBulletPrefabImage()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("bulletImage", listImages.GetCurrentImageName());
        }

        EventSystem.current.SetSelectedGameObject(null);
    }

    void ChangeTilePrefabImage()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("tileImage", listImages.GetCurrentImageName());
        }

        EventSystem.current.SetSelectedGameObject(null);
    }

    void ChangeLifePowerUp()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("lifePowerUpImage", listImages.GetCurrentImageName());
        }

        EventSystem.current.SetSelectedGameObject(null);
    }

    void ChangeShootPowerUp()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("shootPowerUpImage", listImages.GetCurrentImageName());
        }

        EventSystem.current.SetSelectedGameObject(null);
    }

    void ChangeSpeedPowerUp()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("speedPowerUpImage", listImages.GetCurrentImageName());
        }

        EventSystem.current.SetSelectedGameObject(null);
    }

    void ChangeScoreItem()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("scoreItemImage", listImages.GetCurrentImageName());
        }

        EventSystem.current.SetSelectedGameObject(null);
    }
}