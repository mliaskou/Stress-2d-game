using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float force = 0.5f;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] Transform powerUpOrigin;
    public int power;
    public GameObject powerUp;
    GameObject instantiatedPower;
    private bool powerBool;
    private int powerMin = 0;
    private int lifeMin = 0;
    private UIController _uiController;
    public int numberOfLives;
    bool jump;
    bool isOnTheGround;
    public float distanceTravelled;
    public Animator anim;
    public StoreManager storeManager;
    public bool hasWon = false;

    string gameOverTag = "GameOver";
    string powerUpTag = "PowerUp";
    string lifeTag = "Life";
    string enemyTag = "Enemy";
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        powerBool = true;
        anim.gameObject.GetComponent<Animator>().enabled = false;
        _uiController = UIController.s_Instance;
    }


    private void Update()
    {
        _uiController.SetDistanceTravelled(distanceTravelled += Time.deltaTime);
        CheckPowerAndLives();
        CheckForInput();
        PlayerHasWon();
        //StoreManager.instance.setPlayerLives(numberOfLives); //ATODO
        //StoreManager.instance.setPlayerPower(power);//ATODO
    }


    private void FixedUpdate()
    {
        CheckThePlayerIsOnTheGround();
        CheckForGrounded();
    }

    void CheckForGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, new Vector2(0, 4));
        if (hit.collider != null)
        {
            if (hit.distance < 0.1f)
            {
                isOnTheGround = true;
            }
            else
            {
                isOnTheGround = false;
            }
            //Debug.Log(hit.transform.name);
            //Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.green);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(powerUpTag))
        {
            powerBool = true;
            SetNumberOfWeapons(power++);
            Destroy(other.gameObject);
        }

        if (other.CompareTag(lifeTag))
        {
            SetNumberOfLives(numberOfLives++);
            Destroy(other.gameObject);
        }

        if (other.CompareTag(gameOverTag))
        {
            gameObject.SetActive(false);
            _uiController.ShowGameOverScreen();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(enemyTag))
        {
            SetNumberOfWeapons(power - 1);
            SetNumberOfLives(numberOfLives - 1);
        }
    }

    void CheckForInput()
    {
        if (isOnTheGround == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump = true;
            }
        }
    }

    void CheckThePlayerIsOnTheGround()
    {
        if (jump == true)
        {
            jump = false;
            rb.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
    }

    void CheckPowerAndLives()
    {
        if (powerBool == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                instantiatedPower = Instantiate(powerUp, powerUpOrigin.transform.position, Quaternion.identity);
                _uiController.SetNumberOfWeapons(power--);
            }
        }
    }


    private void SetNumberOfLives(int lives)
    {
        if (numberOfLives <= lifeMin)
        {
            numberOfLives = lifeMin;
            _uiController.ShowGameOverScreen();
        }
        numberOfLives = lives;
        _uiController.UpdateNumberOfLivesUI(numberOfLives);
    }

    private void SetNumberOfWeapons(int weapons)
    {
        if (power <= powerMin)
        {
            powerBool = false;
            power = powerMin;
        }
        power = weapons;
        _uiController.SetNumberOfWeapons(power);
    }
    public void PlayerHasWon()
    {
        if (numberOfLives > 0 && distanceTravelled >= 20)
        {
            hasWon = true;
            _uiController.ShowWinScreen();
        }
    }
}
