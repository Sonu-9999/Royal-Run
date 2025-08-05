using TMPro;
using UnityEngine;

public class gamemanager : MonoBehaviour
{
    [SerializeField] playercontroller controller;
    [SerializeField] TMP_Text timeText;
    [SerializeField] GameObject gameovertext;
    [SerializeField] float startTime = 10f;
    float timeleft;
    bool gameOver = false;
    // public bool GameOver{get { return gameOver; }}
    // public bool GameOver { get; private set; };
    public bool GameOver => gameOver; // shorhand for read only property
    void Start()
    {
        timeleft = startTime;
    }
    void Update()
    {
        if (gameOver == true) return;
        PlayerGameOver();
    }

    private void PlayerGameOver()
    {
        timeleft -= Time.deltaTime;
        timeText.text = timeleft.ToString("F1");
        if (timeleft <= 0)
        {
            gameOver = true;
            controller.enabled = false;
            gameovertext.SetActive(true);
            Time.timeScale = 0.1f;
        }
    }
}
