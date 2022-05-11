using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject winScreen;
    [SerializeField]
    GameObject loseScreen;
  

    // Start is called before the first frame update
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
