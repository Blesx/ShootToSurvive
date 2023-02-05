using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] protected float spawnProbability;
    protected bool isDead;
    [SerializeField] protected int attackPower;
    [SerializeField] protected float scoreValue;

    protected Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();

    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDead && !player.HasShield())
        {
            isDead = true;
            Destroy(gameObject);
            player.GetHit(attackPower);
        }
    }

    public float GetSpawnProbability()
    {
        return spawnProbability;
    }

    public float GetScoreValue()
    {
        return scoreValue;
    }
}
