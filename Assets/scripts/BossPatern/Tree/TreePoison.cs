using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreePoison : MonoBehaviour
{

    private void OnParticleCollision(GameObject other)
    {
        if(other.tag== "Player")
        {
            RollAndStats.instance.HP -= 2;
            Debug.Log(RollAndStats.instance.HP);
        }
    }
}
