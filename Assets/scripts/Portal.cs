using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] GameObject[] _portal;
    [SerializeField] Transform[] _spawn;
    [SerializeField] GameObject _player;

    public int _rounds;
    bool _clear = true;
    Vector2 _dis;

    private void Start()
    {
        _rounds = 0;

    }

    private void Update()
    {
        Teleport();
    }

    void Teleport()
    {
        if (Vector2.Distance(_player.transform.position, _portal[_rounds].transform.position) < 2f && Input.GetKeyDown(KeyCode.V))
        {
            if(_clear == true)
            {
                _player.transform.position = _spawn[_rounds].transform.position;
                _rounds++;
                _clear = false;
            }
            
        }
    }



   




}
