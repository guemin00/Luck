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

    private void Start()
    {
        _rounds = 0;
        CameraLimit.instance.nextMap = 0;
    }

    private void Update()
    {
        Teleport();
        TeleIce();
        TeleSpear();
        TeleThunder();
        TeleTree();
    }  

    void Teleport()
    {
        if (Vector2.Distance(_player.transform.position, _portal[0].transform.position) < 2f && Input.GetKeyDown(KeyCode.V))
        {
                _player.transform.position = _spawn[0].transform.position;
                _rounds++;
                CameraLimit.instance.nextMap= 1;
        }
    }

    void TeleIce()
    {
        if (Vector2.Distance(_player.transform.position, _portal[1].transform.position) < 2f && Input.GetKeyDown(KeyCode.V))
        {
            _player.transform.position = _spawn[1].transform.position;
            _rounds++;
            CameraLimit.instance.nextMap = 2;
        }
    }

    void TeleSpear()
    {
        if (Vector2.Distance(_player.transform.position, _portal[2].transform.position) < 2f && Input.GetKeyDown(KeyCode.V))
        {
            _player.transform.position = _spawn[2].transform.position;
            _rounds++;
            CameraLimit.instance.nextMap = 3;
        }
    }

    void TeleTree()
    {
        if (Vector2.Distance(_player.transform.position, _portal[3].transform.position) < 2f && Input.GetKeyDown(KeyCode.V))
        {
            _player.transform.position = _spawn[3].transform.position;
            _rounds++;
            CameraLimit.instance.nextMap = 4;
        }
    }

    void TeleThunder()
    {
        if (Vector2.Distance(_player.transform.position, _portal[4].transform.position) < 2f && Input.GetKeyDown(KeyCode.V))
        {
            _player.transform.position = _spawn[4].transform.position;
            _rounds++;
            CameraLimit.instance.nextMap = 5;
        }
    }



   




}
