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

    public static PlayerControl Instance;


    protected int Hp = 0;
    public int GetAD { get { return GameObject.Find("RollStats").GetComponent<RollAndStats>().AD; } }
    public int GetHp { get { return GameObject.Find("ROllStats").GetComponent<RollAndStats>().HP; } }

    public int _dmg;

    private void Awake()
    {
        Instance = this;
    }

    public void Dmg()
    {
        GameObject.Find("RollStats").GetComponent<RollAndStats>().HP -= _dmg;
        if(Hp < 0)
        {
            Destroy(gameObject);
        }

    }

    


}



