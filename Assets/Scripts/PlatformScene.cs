using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScene : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float leftLimit = -10f;
    public PlatformCreator platformCreator;

    void Update()
    {
        if(AppManager.s_Instance._InitialisationHasCompleted)
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
            if (transform.position.x < leftLimit)
            {

                Destroy(gameObject);
            }

        }
    }
}
