using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    float speed = 3f;
    [SerializeField] float rightLimit = 6f;
   
    void Update()
    {
        GameObject weaponOrigin = GameObject.FindGameObjectWithTag("WeaponOrigin");
        //this.transform.position = weaponOrigin.transform.position;

        transform.Translate(new Vector2(speed, 0) * Time.deltaTime);

        if (transform.position.x > rightLimit)
        {

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ghost")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}