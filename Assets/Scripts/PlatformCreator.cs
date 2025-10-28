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
    public Player player;


    // Update is called once per frame
    void Update()
    {
        if(AppManager.s_Instance._InitialisationHasCompleted)
        {
            player.anim.gameObject.GetComponent<Animator>().enabled = true;
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
