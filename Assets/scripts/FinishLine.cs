using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    [SerializeField] Canvas _clear;
    bool finish = false;
    

    // Update is called once per frame
    void Update()
    {
        if(finish == true)
        {
            
            _clear.GetComponent<Canvas>().enabled = true;
        }
        else if (finish == false)
        {
            _clear.GetComponent<Canvas>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {

            finish = true;
        }
    }

}
