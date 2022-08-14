using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float speed = 2f;
    [SerializeField] float leftLimit = -10f;
    
    void Update()
    {
       
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;

            if (transform.position.x < leftLimit)
            {

                Destroy(gameObject);
            }

      
    }
}
