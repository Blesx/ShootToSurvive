using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    [SerializeField] protected float spawnProbability;
    protected bool isUsed;

    protected Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isUsed)
        {
            GrantEffect(player);
            isUsed = true;
            Destroy(gameObject);
        }
    }

    public float GetSpawnProbability()
    {
        return spawnProbability;
    }

    public abstract void GrantEffect(Player player);
}
