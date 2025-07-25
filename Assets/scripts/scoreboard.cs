using TMPro;
using UnityEngine;

public class scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoretext;
    int score = 0;
    public void AddScore(int points)
    {
        score += points;
        scoretext.text = score.ToString();

    }
}
