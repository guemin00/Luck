using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereGround : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            RollAndStats.instance.HP -= 20;
            Debug.Log(RollAndStats.instance.HP);
        }
    }
}
