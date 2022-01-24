using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 2f;

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession)
        {
            FindObjectOfType<GameSession>().ResetGame();
        }
       
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }
}
