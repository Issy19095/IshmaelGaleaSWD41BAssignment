using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSec = 2f;

    IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSec);
        SceneManager.LoadScene("GameOver");
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void LoadGameOVer()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
