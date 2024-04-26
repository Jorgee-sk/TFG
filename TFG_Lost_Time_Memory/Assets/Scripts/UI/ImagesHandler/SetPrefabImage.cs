using System;
using UnityEngine;
using UnityEngine.UI;

public class SetPrefabImage : MonoBehaviour
{
    public ListImages listImages;
    public Button setPlayerButton;
    public Button setEnemyButton;
    public Button setBackgroundButton;
    public Button setBulletButton;
    public Button setWallButton;

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
    }

    void ChangePlayerPrefabImage()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("playerImage", listImages.GetCurrentImageName());
        }
    }

    void ChangeEnemyPrefabImage()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("enemyImage", listImages.GetCurrentImageName());
        }
    }

    void ChangeBackgroundPrefabImage()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("bgImage", listImages.GetCurrentImageName());
        }
    }

    void ChangeBulletPrefabImage()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("bulletImage", listImages.GetCurrentImageName());
        }
    }

    void ChangeTilePrefabImage()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            PlayerPrefs.SetString("tileImage", listImages.GetCurrentImageName());
        }
    }
}