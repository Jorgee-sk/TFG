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

    [SerializeField] public CustomImages customImages;

    // Start is called before the first frame update
    void OnEnable()
    {
        setPlayerButton.onClick.AddListener(() => ChangePlayerPrefabImage());
        setEnemyButton.onClick.AddListener(() => ChangeEnemyPrefabImage());
        setBackgroundButton.onClick.AddListener(() => ChangeBackgroundPrefabImage());
        setBulletButton.onClick.AddListener(() => ChangeBulletPrefabImage());
    }

    void ChangePlayerPrefabImage()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            customImages.playerImageToSet = listImages.GetCurrentImageName();
        }
    }

    void ChangeEnemyPrefabImage()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            customImages.enemyImageToSet = listImages.GetCurrentImageName();
        }
    }

    void ChangeBackgroundPrefabImage()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            customImages.bgImageToSet = listImages.GetCurrentImageName();
        }
            
    }

    void ChangeBulletPrefabImage()
    {
        if (listImages.GetCurrentImageName() != String.Empty || listImages.GetCurrentImageName() != null)
        {
            customImages.bulletImageToSet = listImages.GetCurrentImageName();
        }
    }
}