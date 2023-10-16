using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDmg : MonoBehaviour
{
    public static BossDmg Instance;
    float _Hp;
    public float HP { get { return _Hp; } set { _Hp = value; } }
    float Dmg;  
    float _currentHp;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        HP = 200;
        _currentHp = HP;
    }

    private void Update()
    {
        Dmg = RollAndStats.instance.AD;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "AttackEffect(Clone)")
        {
            _currentHp -= Dmg;
            HP = _currentHp;
            Debug.Log(HP);
            if(HP <= 0)
            {
                gameObject.SetActive(false);
            }
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "AttackEffect(Clone)")
        {
            _currentHp -= Dmg;
            HP = _currentHp;
            Debug.Log(HP);
        }
    }
    */
}
