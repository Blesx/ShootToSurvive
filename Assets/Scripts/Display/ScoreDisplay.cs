using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI coinsText;

    // private Player player;
    private StatObserver statObserver;

    // Start is called before the first frame update
    void Start()
    {
        // player = GameObject.Find("Player").GetComponent<Player>();
        statObserver = GameObject.Find("Stat Observer").GetComponent<StatObserver>();

    }

    void Update()
    {
        scoreText.text = "Your score: " + statObserver.GetScore();
        coinsText.text = "Coins collected: " + statObserver.GetCoins();
    }

}
