using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPaternIce : MonoBehaviour
{
    [SerializeField] GameObject[] _maps;
    [SerializeField] GameObject[] _skills;
    [SerializeField] GameObject _boss;
    [SerializeField] GameObject _player;
    Rigidbody2D _rig;
    Transform _playerPos;
    Transform _bossPos;


    int _nextPatern = 0;

    private void Start()
    {
        _playerPos = GameObject.Find("Player").GetComponent<Transform>();
        _bossPos = GameObject.Find("Boss").GetComponent<Transform>() ;
    }


    // Update is called once per frame
    void Update()
    {
        Skills();   
    }

    void Skills()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            IceCylinder();
            IceSpear();
            IceGuard();
        }
        
    }

    void IceCylinder()
    {

        _skills[0].gameObject.transform.position = _playerPos.position;
        GameObject temp =  Instantiate(_skills[0]);
        temp.GetComponent<Animator>().Play("DangerBox");
        temp.GetComponent<Animator>().Play("IceCylinder");
        Destroy(temp, 5f);
    }

    void IceSpear()
    {
        for(int i = -20; i< 30; i=i+5)
        {
            _skills[1].gameObject.transform.position = new Vector3(_bossPos.position.x + i, _bossPos.position.y-5, 0);
            GameObject temp = Instantiate(_skills[1]);
            temp.GetComponent<Animator>().Play("IceBossSpear");
            temp.GetComponent<Animator>().Play("IceSpear");
            Destroy(temp, 3f);
        }
        
    }

    void IceGuard()
    {
        _skills[2].gameObject.transform.position = new Vector3(_bossPos.position.x, _bossPos.position.y, 0);  
        GameObject temp = Instantiate(_skills[2]);
        temp.GetComponent<Animator>().Play("IceGuard");

    }
}
