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
    private int power;
    private GameObject powerUp;
    GameObject instantiatedPower;
    private bool powerBool;
    private int powerMin = 0;
    private int lifeMin = 0;
    private UIController _uiController;
    private int numberOfLives;
    bool jump;
    bool isOnTheGround;
    private float distanceTravelled;
    public Animator anim;
    private bool hasWon = false;

    string gameOverTag = "GameOver";
    string powerUpTag = "PowerUp";
    string lifeTag = "Life";
    string enemyTag = "Enemy";

    public IEnumerator InitializePlayer(UIController uiController)
    {
        rb = GetComponent<Rigidbody2D>();
        powerBool = true;
        anim.gameObject.GetComponent<Animator>().enabled = false;
        _uiController = uiController;
        yield return null;
    }

    private void Update()
    {
        if (AppManager.s_Instance._InitialisationHasCompleted)
        {
            _uiController.SetDistanceTravelled(distanceTravelled += Time.deltaTime);
            CheckPowerAndLives();
            CheckForInput();
            PlayerHasWon();
            //StoreManager.instance.setPlayerLives(numberOfLives); //ATODO
            //StoreManager.instance.setPlayerPower(power);//ATODO
        }
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
            power++;
            SetNumberOfWeapons(power);
            Destroy(other.gameObject);
        }

        if (other.CompareTag(lifeTag))
        {
            numberOfLives++;
            SetNumberOfLives(numberOfLives);
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
            numberOfLives--;
            SetNumberOfLives(numberOfLives);
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
        if (lives <= lifeMin)
        {
            numberOfLives = lifeMin;
            _uiController.ShowGameOverScreen();
        }
        numberOfLives = lives;
        _uiController.UpdateNumberOfLivesUI(numberOfLives);
    }

    private void SetNumberOfWeapons(int numberOfWeapons)
    {
        if (numberOfWeapons <= powerMin)
        {
            powerBool = false;
            power = powerMin;
        }
        power = numberOfWeapons;
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
