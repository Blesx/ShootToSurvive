using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    private Player player;
    private StatObserver statObserver;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        statObserver = GameObject.Find("Stat Observer").GetComponent<StatObserver>();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScoreText();
        DisplayLivesText();
    }
    public void DisplayLivesText()
    {
        livesText.text = "Lives: " + player.GetLives();

        if (player.GetLives() <= 0)
        {
            livesText.text = "Lives: " + 0;
        }
    }

    public void DisplayScoreText()
    {
        scoreText.text = "Score: " + Mathf.Round(statObserver.GetScore());
    }
}
