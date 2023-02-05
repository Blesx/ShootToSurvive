using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatObserver : MonoBehaviour
{
    private float score = 0;
    private int coins = 0;
    
    public void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void AddScore(float scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void SetCoins(int coins)
    {
        this.coins = coins;
    }

    public float GetScore()
    {
        return score;
    }

    public int GetCoins()
    {
        return coins;
    }

}
