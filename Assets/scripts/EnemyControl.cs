using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{


    PlayerControl _playerControl;
   
    
    
    int enemyHp = 100;
    int enemyAd = 5;



    //PlayerControl _playerControl;
    
    int getDmg = 0;
    
    protected float HP = 0;
    protected int AD = 0;
    public int _eAD { get { return AD; } set { AD = value; } }

    void Start()
    {

        HP = enemyHp;
        AD = enemyAd;
        _playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
        
  
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Attack"))
        {
            Dmg();
            Debug.Log(HP);

         
        }
    }

   

    void Dmg()
    {
        getDmg = _playerControl.GetAD;
        HP -= getDmg;
        

        
    }
    

    void Die()
    {
        if(HP <= 0)
        {
            Destroy(gameObject);
            MonsterSpawner._instance.enemyCount--;
        }
    }

    



}

