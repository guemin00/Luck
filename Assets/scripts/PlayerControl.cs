using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] GameObject _player;

    int _playerHp = 50;
    int _playerAd = 5;


    protected int Hp = 0;
    public int GetAD { get { return GameObject.Find("RollStats").GetComponent<RollAndStats>().AD; } }
    public int GetHp { get { return GameObject.Find("ROllStats").GetComponent<RollAndStats>().HP; } }



    public int _dmg;




    // Start is called before the first frame update
    void Start()
    {


    }

   



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy"))
        {
           
            Dmg();
            Debug.Log(GameObject.Find("RollStats").GetComponent<RollAndStats>().HP);

        }
    }
   



    void Dmg()
    {
       
        GameObject.Find("RollStats").GetComponent<RollAndStats>().HP -= _dmg;
        if(Hp < 0)
        {
            Destroy(gameObject);
        }

    }


    void Knowback()
    {
        Vector2 Pknock = _player.GetComponent<Transform>().position;
        Vector2 Dknock = new Vector2(0, 0);
    }

}



