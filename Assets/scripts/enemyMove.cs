using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
   
    [SerializeField] Transform[] _points;
    [SerializeField] Transform _player;
    [SerializeField] float _speed;
    [SerializeField] Rigidbody2D _rig;
    Transform _enemy;

    int _nowtime = 0;

    void Start()
    {
        enemyMove move = GetComponent<enemyMove>();
        _rig = GetComponent<Rigidbody2D>();
        _enemy = transform;
        
    }

    void Update()
    {
        
        if(Vector3.Distance(_player.position, _enemy.position) < 3f)
        {
            playerFar();
        }
        
        else
        {
            patrol();
        }
       
    }

    void patrol()
    {
        Vector3 nextPosition = _points[_nowtime].position;
        Vector3 moveVector = nextPosition - _enemy.position;
        Vector3 dirVector = moveVector.normalized;
        Vector3 lastVector = dirVector * _speed;
        _enemy.position = _enemy.position + lastVector*Time.deltaTime;
        if(Vector3.Distance(_enemy.position, nextPosition) < 0.2f)
        {
            _nowtime++;
            if( _nowtime >= _points.Length )
            {
                _nowtime = 0;
              
            }
        }
    }

    void playerFar()
    {
        Vector3 moveVector = (_player.position - _enemy.position);
        Vector3 dirVector = moveVector.normalized;
        Vector3 lastVector = dirVector * _speed*1.2f;
        _enemy.position = _enemy.position + lastVector * Time.deltaTime;
    }




}
