using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControlThunder : MonoBehaviour
{
    [SerializeField] GameObject[] _maps;
    [SerializeField] GameObject[] _skills;
    [SerializeField] GameObject[] _dangerBox;
    [SerializeField] GameObject _boss;
    [SerializeField] GameObject _player;

    Transform _playerPos;
    Transform _bossPos;
    int _nextPatern;


    private void Start()
    {
        _playerPos = GameObject.Find("Player").GetComponent<Transform>();
        _bossPos = GameObject.Find("BossThunder").GetComponent<Transform>();
        _nextPatern = 2;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B) && _nextPatern == 0)
        {
            InvokeRepeating("Thunder", 0, 1f);
        }
        if(Input.GetKeyDown(KeyCode.B) && _nextPatern == 1) 
        {
            ThunderMove();
        }
        if (Input.GetKeyDown(KeyCode.B) && _nextPatern == 2)
        {
            ThunderShoot();
        }
    }


    void Thunder()
    {
        _dangerBox[0].transform.position = new Vector3(_bossPos.position.x + Random.Range(-10, 10), _bossPos.position.y, 0);
        _skills[0].transform.position = _dangerBox[0].transform.position;
        GameObject danger = Instantiate(_dangerBox[0]);
        danger.GetComponent<Animator>().Play("DangerBox");
        Destroy(danger, 0.3f);
        StartCoroutine(light());

        IEnumerator light()
        {
            yield return new WaitForSeconds(0.3f);
            GameObject thunder = Instantiate(_skills[0]);
            Destroy(thunder, 0.5f);
        }
    }


    void ThunderMove()
    {
        _dangerBox[1].transform.position = _bossPos.position;
        _skills[1].transform.position = new Vector3(190, _bossPos.position.y, _bossPos.position.z);
        GameObject danger = Instantiate(_dangerBox[1]);
        danger.GetComponent<Animator>().Play("DangerBox");
        Destroy(danger, 0.5f);
        StartCoroutine(light());
        
        IEnumerator light()
        {
            yield return new WaitForSeconds(0.5f);
            GameObject thunder = Instantiate(_skills[1]);
            thunder.GetComponent<Animator>().Play("ThunderMove");
            Destroy(thunder, 5f);
        }
    }



    void ThunderShoot()
    {
        _dangerBox[2].transform.position = new Vector3(_bossPos.position.x, _playerPos.position.y, 0);
        _skills[2].transform.position = new Vector3(_dangerBox[2].transform.position.x + 20, _dangerBox[2].transform.position.y);
        _skills[3].transform.position = new Vector3(_dangerBox[2].transform.position.x - 20, _dangerBox[2].transform.position.y);
        GameObject danger = Instantiate(_dangerBox[2]);
        danger.GetComponent<Animator>().Play("DangerBox");
        Destroy(danger, 0.3f);
        StartCoroutine(light());
           
        IEnumerator light()
        {
            yield return new WaitForSeconds(0.2f);
            GameObject thunder = Instantiate(_skills[2]);
            //thunder.transform.position = new Vector3( danger.transform.position.x + 20, danger.transform.position.y);
            StartCoroutine(light2());
            Debug.Log("½ÇÇà");
        }
        
        IEnumerator light2()
        {
            yield return new WaitForSeconds(1f);
            GameObject thunder2 = Instantiate(_skills[3]);
        }
    }
}
