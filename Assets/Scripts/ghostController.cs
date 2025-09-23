using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostController : MonoBehaviour
{

    [SerializeField] float speed =1;
    // Update is called once per frame
   
    void Update()
    {
        this.transform.Translate(new Vector2(-speed, 0) * Time.deltaTime);
    }
}
