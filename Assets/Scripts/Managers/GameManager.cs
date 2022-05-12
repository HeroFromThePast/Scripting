using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject winScreen;
    [SerializeField]
    GameObject loseScreen;
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject volumeMenu;
    public AudioMixer audioMixer;
    
    public static bool GameIsPaused = false;

    // Start is called before the first frame update
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }
    void Start()
    {
        if(LevelManager.instance!=null)
        {
            LevelManager.instance.LevelWin += WinGame;
            LevelManager.instance.StartLevel();
        }
        if(Player.instance!=null)
        {
            Player.instance.OnPlayerfail += LoseGame;
        }
  
        if (winScreen != null)
        {
            winScreen.SetActive(false);
        }
        if(loseScreen!=null)
        {
            loseScreen.SetActive(false);
        }
       
    }
    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("volumen", volume);
    }
    public void VolumeMenuActive()
    {
        volumeMenu.SetActive(true);

    }
    public void VolumeMenuUnactive()
    {
        volumeMenu.SetActive(false);

    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void GetToMain()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
   

    public void ResetGame()
    {
        SceneManager.LoadScene("Level");
    }

    void WinGame()
    {
        if(winScreen!=null)
        {
            winScreen.SetActive(true);
        }
     
    }

    void LoseGame()
    {
        if(loseScreen!=null)
        {
            loseScreen.SetActive(true);
        }
        
    }

    private void OnDisable()
    {
        if(LevelManager.instance!=null)
        {
            LevelManager.instance.LevelWin -= WinGame;
        }
       
        if (Player.instance != null)
        {
            Player.instance.OnPlayerfail -= LoseGame;
        }
       
    }
}
