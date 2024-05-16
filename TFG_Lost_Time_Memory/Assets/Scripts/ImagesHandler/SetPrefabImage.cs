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
    public Button restoreDefaultBackgroundAndWallsButton;
    public Button restoreDefaultButton;
    public Button gameMenuBgButton;
    public Button gameButtonBtn;
    public Button inGameMenuBgButton;

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

        if (restoreDefaultBackgroundAndWallsButton != null)
        {
            restoreDefaultBackgroundAndWallsButton.onClick.AddListener(() => RestoreDefaultBgAndWallImages());
        }
        
        if (restoreDefaultButton != null)
        {
            restoreDefaultButton.onClick.AddListener(() => RestoreDefault());
        }

        if (gameMenuBgButton != null)
        {
            gameMenuBgButton.onClick.AddListener(() => ChangeGameMenuBackground());
        }

        if (gameButtonBtn != null)
        {
            gameButtonBtn.onClick.AddListener(() => ChangeGameButtons());
        }

        if (inGameMenuBgButton != null)
        {
            inGameMenuBgButton.onClick.AddListener(() => ChangeInGameMenuBackground());
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
    
    void ChangeGameMenuBackground()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("menuBackground", listImages.GetCurrentImageName());
        }

        EventSystem.current.SetSelectedGameObject(null);
    }
    
    void ChangeGameButtons()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("buttonBackground", listImages.GetCurrentImageName());
        }

        EventSystem.current.SetSelectedGameObject(null);
    }
    
    void ChangeInGameMenuBackground()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("gameMenuBackground", listImages.GetCurrentImageName());
        }

        EventSystem.current.SetSelectedGameObject(null);
    }

    void RestoreDefaultBgAndWallImages()
    {
        PlayerPrefs.SetString("tileImage", null);
        PlayerPrefs.SetString("bgImage", null);
        PlayerPrefs.SetString("menuBackground", null);
        PlayerPrefs.SetString("buttonBackground", null);
        PlayerPrefs.SetString("gameMenuBackground", null);
        EventSystem.current.SetSelectedGameObject(null);
    }

    void RestoreDefault()
    {
        PlayerPrefs.SetString("playerImage", null);
        PlayerPrefs.SetString("enemyImage", null);
        PlayerPrefs.SetString("bulletImage", null);
        PlayerPrefs.SetString("lifePowerUpImage", null);
        PlayerPrefs.SetString("shootPowerUpImage", null);
        PlayerPrefs.SetString("speedPowerUpImage", null);
        PlayerPrefs.SetString("scoreItemImage", null);
        RestoreDefaultBgAndWallImages();
    }
}