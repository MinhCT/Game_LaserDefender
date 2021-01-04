using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    [SerializeField] float delayInSeconds = 1.5f;

    public void LoadStartMenu()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession)
        {
            gameSession.ResetGame();
        }
        SceneManager.LoadScene(0);
    }

    public void LoadGameScene()
    {
        GameSession gameSession = FindObjectOfType<GameSession>();
        if (gameSession)
        {
            gameSession.ResetGame();
        }
        SceneManager.LoadScene("Game");
    }

    public void LoadGameOver()
    {
        StartCoroutine(DelayLoadScene());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private IEnumerator DelayLoadScene()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene("Game Over");
    }
}
