using System;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuthOpenAI : MonoBehaviour
{
    string _path;
    string _jsonString;
    public Button button;
    public TMP_InputField apiKeyInputField;
    public TMP_InputField organizationKeyInputField;
    private string _keyOpenAi;
    private string _organisationKey;

    void Start()
    {
        button.onClick.AddListener(WriteJsonOutput);
        CheckOpenAIDirectory();
    }

    private void CheckOpenAIDirectory()
    {
        string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        string dir = $"{userPath}/.openai";
        // If directory does not exist, create it
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }
    }
    /**
     * Method that will be execute on the onclick associated to input of token
     */
    public void WriteJsonOutput()
    {
        string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        _path = $"{userPath}/.openai/auth.json";

        if (organizationKeyInputField.text.Equals(String.Empty))
        {
            PlayerPrefs.SetString("private_api_key",apiKeyInputField.text);
            ApiKey keyOpenAi = new ApiKey();
            keyOpenAi.private_api_key = apiKeyInputField.text;
            _jsonString = JsonUtility.ToJson(keyOpenAi);
            File.WriteAllText(_path, _jsonString);
        }
        else
        {
            PlayerPrefs.SetString("private_api_key",apiKeyInputField.text);
            PlayerPrefs.SetString("organization", organizationKeyInputField.text);
            Auth keyOpenAi = new Auth();
            keyOpenAi.private_api_key = apiKeyInputField.text;
            keyOpenAi.organization = organizationKeyInputField.text;
            _jsonString = JsonUtility.ToJson(keyOpenAi);
            File.WriteAllText(_path, _jsonString);
        }

        SceneManager.LoadScene(4);
    }

    void Update()
    {
        if (apiKeyInputField.text.Equals(String.Empty) && (PlayerPrefs.GetString("private_api_key") == null ||
                                                           PlayerPrefs.GetString("private_api_key") == ""))
        {
            button.enabled = false;
        }
        else if (!apiKeyInputField.text.Equals(String.Empty) ||
                 PlayerPrefs.GetString("private_api_key") != null)
        {
            button.enabled = true;
        }
    }
}

[Serializable]
public class ApiKey
{
    public string private_api_key;
}


[Serializable]
public class Auth
{
    public string private_api_key;
    public string organization;
}