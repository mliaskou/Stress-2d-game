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
    [SerializeField] Weapon weaponScript;
    [SerializeField] Text powerText;
    [SerializeField] Text lifeText;
    private bool powerBool;
    private int powerMin = 0;
    private int lifeMin = 0;
    public int life ;
    bool jump;
    bool isOnTheGround;
    public UIController uiController;
    public float distanceTravelled;
    public PlatformCreator platformCreator;
    public Animator anim;

    public StoreManager storeManager;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        powerBool = true;
        anim.gameObject.GetComponent<Animator>().enabled = false;
    }


    private void Update()
    {
        distanceTravelled += Time.deltaTime;
        CheckPowerAndLives();
        CheckForInput();
        PlayerHasWon();
        storeManager.setPlayerLives(life);
        storeManager.setPlayerPower(power);
    }
    

     private void FixedUpdate()
    {
        CheckThePlayerIsOnTheGround();
        CheckForGrounded();
        
    }
    void CheckForGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);
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
            Debug.Log(hit.transform.name);
            Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.green);


        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("PowerUp"))
        {
            power++;
            powerBool = true;
            powerText.text = power.ToString();
            Destroy(other.gameObject);

        }

        if(other.CompareTag("Life"))
        {

            life++;
            lifeText.text = life.ToString();
            Destroy(other.gameObject);

        }

        if(other.CompareTag("GameOver"))
        {

            uiController.ShowGameOverScreen();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Enemy"))
        {
            power--;
            powerText.text = power.ToString();
            life--;
            lifeText.text = life.ToString();
            //Destroy(collision.gameObject);
           


            if (life <= 0)
            {
                uiController.ShowGameOverScreen();
            }

        }
    }

    void CheckForInput()
    {
        if(isOnTheGround == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
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

                power--;
                //powerText.text = power.ToString();
                
            }
        }

        if (power <= powerMin)
        {
            powerBool = false;
            power = powerMin;
        }

        if (life < lifeMin)
        {
            life = lifeMin;
        }
        powerText.text = power.ToString();
        lifeText.text = life.ToString();

    }

    public void PlayerHasWon()
    {
        if(life > 0 && distanceTravelled >= 80)
        {
            uiController.ShowWinScreen();
        }
    }
}
