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
        LevelManager.instance.LevelWin += WinGame;
        LevelManager.instance.StartLevel();
        Player.instance.OnPlayerfail += LoseGame;
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
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
        winScreen.SetActive(true);
    }

    void LoseGame()
    {
        loseScreen.SetActive(true);
    }

    private void OnDisable()
    {
        LevelManager.instance.LevelWin -= WinGame;
        Player.instance.OnPlayerfail -= LoseGame;
    }
}
