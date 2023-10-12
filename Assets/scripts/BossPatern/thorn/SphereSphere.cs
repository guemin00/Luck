using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSphere : MonoBehaviour
{
   
    Rigidbody2D rb;
    float randomX, randomY;

    private void Start()
    {
       
        rb = gameObject.GetComponent<Rigidbody2D>();


        float _speed = Random.Range(500f, 2000f);


        randomX = Random.Range(-1f, 1f);
        randomY = Random.Range(-1f, 1f);

        Vector2 dir = new Vector2 (randomX, randomY).normalized;

        rb.AddForce(dir*_speed);
        
    }
}
