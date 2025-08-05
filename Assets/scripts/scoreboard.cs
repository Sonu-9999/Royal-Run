using TMPro;
using UnityEngine;

public class scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoretext;
    [SerializeField]gamemanager manager;
    int score = 0;
    public void AddScore(int points)
    {
        if (manager.GameOver) return; // Check if the game is over before adding score
        score += points;
        scoretext.text = score.ToString();

    }
}
