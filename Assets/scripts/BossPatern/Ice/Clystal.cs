using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clystal : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerControl.Instance._dmg = 5;
            PlayerControl.Instance.Dmg();
            Debug.Log(PlayerControl.Instance.GetHp);
        }
    }

    
}
