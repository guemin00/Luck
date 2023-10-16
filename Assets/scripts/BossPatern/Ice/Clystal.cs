using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clystal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.collider.tag == "Player")
            {
                RollAndStats.instance.HP -= 3;
                Debug.Log(RollAndStats.instance.HP);
            }
        }
    }

    
}
