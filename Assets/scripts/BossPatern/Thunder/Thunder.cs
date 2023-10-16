using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "Player")
        {
            RollAndStats.instance.HP -= 5;
            Debug.Log(RollAndStats.instance.HP);
        }
    }
}
