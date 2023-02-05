using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;

    private Rigidbody2D entityRb;
    private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        entityRb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        entityRb.AddForce((player.transform.position - transform.position).normalized * speed);
    }
}
