using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpear : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            RollAndStats.instance.HP -= 10;
            Debug.Log(RollAndStats.instance.HP);
        }
    }
}
