using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;

    private Rigidbody2D playerRb;
    [SerializeField] GameObject projectile;
    private Gun gun;

    [SerializeField] GameObject shieldIndicator;
    private bool haveShield;

    [SerializeField] int numberOfLives;

    private int numberOfCoins = 0;
    private bool isDead = false;

    private GameManager gameManager;
    private StatObserver statObserver;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        gun = transform.Find("Focal Point").gameObject.transform.Find("Gun").gameObject.GetComponent<Gun>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        statObserver = GameObject.Find("Stat Observer").GetComponent<StatObserver>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isDead)
        {
            gun.Fire();
        }
    }

    void FixedUpdate()
    {
        if (!isDead)
        {
            float verticalInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");

            playerRb.AddForce(Vector2.up * verticalInput * speed, ForceMode2D.Impulse);
            playerRb.AddForce(Vector2.right * horizontalInput * speed, ForceMode2D.Impulse);

            playerRb.AddTorque(-horizontalInput * rotateSpeed);
        }
    }

    public void GainShield()
    {
        haveShield = true;
        shieldIndicator.SetActive(true);
        StartCoroutine(UseShield());
    }

    IEnumerator UseShield()
    {
        yield return new WaitForSeconds(5);

        haveShield = false;
        shieldIndicator.SetActive(false);
    }

    public void AddLife(int lives)
    {
        numberOfLives += lives;
        Debug.Log("Number of lives: " + numberOfLives);
    }

    public void AddCoin()
    {
        numberOfCoins += 1;
        Debug.Log("Number of coins: " + numberOfCoins);
    }

    public void GetHit(int lives)
    {
        numberOfLives -= lives;
        Debug.Log("Number of lives: " + numberOfLives);

        if (numberOfLives <= 0)
        {
            statObserver.SetCoins(numberOfCoins);
            gameManager.EndGame();
            isDead = true;
        }
    }

    public bool HasShield()
    {
        return haveShield;
    }

    public int GetLives()
    {
        return numberOfLives;
    }

    public int GetCoins()
    {
        return numberOfCoins;
    }
}
