using UnityEngine;

public class GameSession : MonoBehaviour
{
    int totalScore = 0;

    private void Awake()
    {
        SetUpSingleton();
    }

    private void SetUpSingleton()
    {
        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetTotalScore()
    {
        return totalScore;
    }

    public void AddToScore(int score)
    {
        totalScore += score;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
