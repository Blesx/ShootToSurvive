using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed;
    private Rigidbody2D projRb;
    [SerializeField] float projLife;

    private StatObserver statObserver;

    // Start is called before the first frame update
    void Awake()
    {
        projRb = GetComponent<Rigidbody2D>();
        statObserver = GameObject.Find("Stat Observer").GetComponent<StatObserver>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            statObserver.AddScore(collision.gameObject.GetComponent<Enemy>().GetScoreValue());
        }
    }

    private void OnEnable()
    {
        StartCoroutine(StartProjectileLife());
    }

    IEnumerator StartProjectileLife()
    {
        projRb.velocity = transform.up * speed;
        yield return new WaitForSeconds(projLife);
        gameObject.SetActive(false);
    }
}
