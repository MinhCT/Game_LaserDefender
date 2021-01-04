using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    TMP_Text scoreText;
    GameSession gameSession;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        gameSession = FindObjectOfType<GameSession>();
        //scoreText.text = "0";
    }

    void Update()
    {
        scoreText.text = gameSession.GetTotalScore().ToString();
    }
}
