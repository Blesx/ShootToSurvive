using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    [SerializeField] float speed;
    private float xDirection;
    private float yDirection;

    private Rigidbody2D entityRb;
    private Vector2 lastVelocity;

    // Start is called before the first frame update
    void Start()
    {
        entityRb = GetComponent<Rigidbody2D>();
        xDirection = Random.Range(-1.0f, 1.0f);
        yDirection = Random.Range(-1.0f, 1.0f);
        entityRb.velocity = new Vector2(xDirection, yDirection) * speed;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lastVelocity = entityRb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            entityRb.velocity = Vector2.Reflect(lastVelocity, collision.GetContact(0).normal);
        }
    }
}
