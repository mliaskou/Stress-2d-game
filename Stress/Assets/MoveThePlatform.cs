using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveThePlatform : MonoBehaviour
{
    public int speed = 4;
    public float horizontalInput;
    public float xRange = 10f;
    private void Start()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }
    void Update()
    {
        if (transform.position.x <= -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }

        if (transform.position.x >= xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
    }
}
