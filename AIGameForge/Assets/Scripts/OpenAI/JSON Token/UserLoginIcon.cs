using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UserLoginIcon : MonoBehaviour
{
    public GameObject userNotLogged;
    public GameObject userLogged;
    
    public GameObject login;
    public GameObject exit;
    public GameObject alreadyLogged;

    public Button alreadyLoggedBTN;

    public List<GameObject> gameObjectsToDisable;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetString("private_api_key") == null || PlayerPrefs.GetString("private_api_key") == "")
        {
            userNotLogged.SetActive(true);
            login.transform.localPosition = new Vector3(0, -300, 0);
            exit.SetActive(false);
            login.SetActive(true);
            alreadyLogged.SetActive(false);
        }
        else
        {
            alreadyLoggedBTN.onClick.AddListener(GoToNextScene);
            userLogged.transform.localPosition = new Vector3(0, 0, 0);
            userLogged.transform.localScale = new Vector3(5f, 5f, 0);
            userNotLogged.SetActive(false);
            exit.SetActive(true);
            exit.GetComponentInChildren<Button>().onClick.AddListener(DeletePlayerPrefs);
            login.SetActive(false);
            alreadyLogged.SetActive(true);
            alreadyLogged.transform.localPosition = new Vector3(-180, -300, 0);
            foreach (var gameObject in gameObjectsToDisable)
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void GoToNextScene()
    {
        SceneManager.LoadScene(6);
    }

    private void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteKey("private_api_key");
        PlayerPrefs.DeleteKey("organization");
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
    }
}