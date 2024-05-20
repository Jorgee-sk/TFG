using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private Button _resumeButton;
    [SerializeField] private Button _goToMenu;
    [SerializeField] private Button _restartGame;
    [SerializeField] private GameObject _muteAllSounds;
    [SerializeField] private GameObject _enableAllSounds;
    [SerializeField] private List<GameObject> otherGameObjects;

    public void Pause()
    {
        foreach (GameObject uiGameObject in otherGameObjects)
        {
            uiGameObject.SetActive(false);
        }

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        _resumeButton.onClick.AddListener(Resume);
        _goToMenu.onClick.AddListener(GoToMenu);
        _restartGame.onClick.AddListener(RestartGame);

        if (AudioListener.volume == 1)
        {
            _muteAllSounds.GetComponent<Button>().onClick.AddListener(MuteAllSounds);
            _muteAllSounds.SetActive(true);
            _enableAllSounds.SetActive(false);
        }
        else
        {
            _enableAllSounds.GetComponent<Button>().onClick.AddListener(EnableAllSounds);
            _muteAllSounds.SetActive(false);
            _enableAllSounds.SetActive(true);
        }
        
        
    }
    
    private void Resume()
    {
        
        foreach (GameObject uiGameObject in otherGameObjects)
        {
            uiGameObject.SetActive(true);
        }

        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    private void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }
    
    private void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    private void MuteAllSounds()
    {
        AudioListener.volume = 0;
        _enableAllSounds.GetComponent<Button>().onClick.AddListener(EnableAllSounds);
        _muteAllSounds.SetActive(false);
        _enableAllSounds.SetActive(true);
    }
    
    private void EnableAllSounds()
    {
        AudioListener.volume = 1;
        _muteAllSounds.GetComponent<Button>().onClick.AddListener(MuteAllSounds);
        _muteAllSounds.SetActive(true);
        _enableAllSounds.SetActive(false);
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
