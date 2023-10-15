using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderShootingReverse : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        Invoke("DestroyShoot", 1f);
        speed = 100;
    }
    private void Update()
    {
        transform.Translate(transform.right*-1 * speed * Time.deltaTime);
    }
    void DestroyShoot()
    {
        Destroy(gameObject);
    }
}
