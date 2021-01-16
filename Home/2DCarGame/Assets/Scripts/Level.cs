using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSec = 2f;

    IEnumerator WaitAndLoadGameOver()
    {
        yield return new WaitForSeconds(delayInSec);
        SceneManager.LoadScene("GameOver");
    }

    IEnumerator WaitAndLoadWinner()
    {
        yield return new WaitForSeconds(delayInSec);
        SceneManager.LoadScene("Winner");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Main");
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadGameOVer()
    {
        StartCoroutine(WaitAndLoadGameOver());
    }

    public void LoadWinner()
    {
        StartCoroutine(WaitAndLoadWinner());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
