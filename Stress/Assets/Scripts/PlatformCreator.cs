using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlatformCreator : MonoBehaviour
{
    [SerializeField] GameObject [] platformPrefab;
    public Transform referencePoint;
    [SerializeField] GameObject lastCreatedPlatform;
    float lastPlatformWidth;
    [SerializeField] Text timeText;
    public float timeLeft =3f;
    public Player player;


    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime; // Set the timer
        timeLeft = Mathf.Clamp(timeLeft, 0, 3);
        timeText.text = (timeLeft).ToString("0");

        
        if(timeLeft<=0)
        {
            player.anim.gameObject.GetComponent<Animator>().enabled = true;
            player.anim.Play("PlayerMove");
            timeText.enabled = false;
            if (lastCreatedPlatform.transform.position.x < referencePoint.position.x)
            {
                float spaceBetweenPlatforms = Random.Range(1, 3);
                Vector2 targetCreationPoint = new Vector2(referencePoint.transform.position.x + spaceBetweenPlatforms + lastPlatformWidth, 0);
                int randomPlatform = Random.Range(0, platformPrefab.Length);
                lastCreatedPlatform = Instantiate(platformPrefab[randomPlatform], targetCreationPoint, Quaternion.identity);
                BoxCollider2D collider = lastCreatedPlatform.GetComponent<BoxCollider2D>();
                lastPlatformWidth = collider.bounds.size.x;
            }
            

            

        }

    }
}
