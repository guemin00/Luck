using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPaternThorn : MonoBehaviour
{
    [SerializeField] GameObject[] _maps;
    [SerializeField] GameObject[] _skills;
    [SerializeField] GameObject[] _dangerBox;
    [SerializeField] GameObject _boss;
    [SerializeField] GameObject _player;

    Transform _playerPos;
    Transform _bossPos;
    int _nextPatern;
    int _count = 0;
    float i = 0;
    bool finish = false;


    private void Start()
    {
        _playerPos = GameObject.Find("Player").GetComponent<Transform>();
        _bossPos = GameObject.Find("BossThorn").GetComponent<Transform>();
        _nextPatern = 2;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && _nextPatern == 0)
        {
            StartCoroutine(CoTeeth());
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && _nextPatern == 1)
        {
            Sphere();
            Sphere();
        }
        if(Input.GetKeyDown(KeyCode.LeftControl) && _nextPatern == 2)
        {
            spearGround();
        }

    }



    void Teeth()
    {
        _dangerBox[0].gameObject.transform.position = _playerPos.position;
        _skills[0].gameObject.transform.position = _dangerBox[0].gameObject.transform.position;
        GameObject temp2 = Instantiate(_dangerBox[0]);
        temp2.GetComponent<Animator>().Play("DangerBox");
        Destroy(temp2, 0.3f);
        StartCoroutine(TeethEat());
        _count++;
        if (_count > 3)
        {
            _count = 0;
            //_nextPatern = Random.Range(0, 3);
        }

        IEnumerator TeethEat()
        {
            yield return new WaitForSeconds(0.3f);
            GameObject temp = Instantiate(_skills[0]);
            temp.GetComponent<Animator>().Play("Teeth");
            Destroy(temp, 0.5f);
            _nextPatern = Random.Range(0, 3);
        }
    }
    IEnumerator CoTeeth()
    {
        do
        {
            Teeth();
            yield return new WaitForSeconds(0.5f);
        }
        while (_count < 3);
    }

    void Sphere()
    {
        _dangerBox[1].gameObject.transform.position = new Vector3(_bossPos.position.x + Random.Range(-5f, 5f), _bossPos.position.y + Random.Range(-2f, 2f));
        _skills[1].gameObject.transform.position = _dangerBox[1].gameObject.transform.position;
        GameObject temp2 = Instantiate(_dangerBox[1]);
        temp2.GetComponent<Animator>().Play("DangerCirle");
        Destroy(temp2, 0.5f);
        StartCoroutine(Spear());

        IEnumerator Spear()
        {
            yield return new WaitForSeconds(1f);
            GameObject temp = Instantiate(_skills[1]);
            Destroy(temp, 8f);
            _nextPatern = Random.Range(0, 3);
        }
    }

    void spearGround()
    {
        _dangerBox[2].gameObject.transform.position = new Vector3(_bossPos.position.x, _bossPos.position.y - 6f);
        GameObject temp2 = Instantiate(_dangerBox[2]);
        temp2.GetComponent<Animator>().Play("DangerBox");
        Destroy(temp2, 0.5f);
        StartCoroutine(Ground());

        IEnumerator Ground()
        {
            yield return new WaitForSeconds(1f);
            InvokeRepeating("InvokeSpear", 0f, 0.2f); 
        }
    }

    void InvokeSpear()
    {
        _skills[2].gameObject.transform.position = new Vector3(_bossPos.position.x + i, _bossPos.position.y);
        GameObject temp = Instantiate(_skills[2]);
        temp.GetComponent<Animator>().Play("SphereGround");
        i++;
        if(i> 40)
        {
            CancelInvoke();
            finish = true;
        }
        if(finish == true)
        {
            GameObject[] Spears = GameObject.FindGameObjectsWithTag("Spear");
            Debug.Log(Spears.Length);
            for (int x = 0; x < Spears.Length; x++)
            {
                Spears[x].GetComponent<Animator>().Play("FinaleSpear");
            }
            StartCoroutine(DestroySpear());

            IEnumerator DestroySpear()
            {
                yield return new WaitForSeconds(5f);
                for (int x = 0; x < Spears.Length; x++)
                {
                    Destroy(Spears[x]);
                    i = 0;
                    finish = false;
                    _nextPatern = Random.Range(0, 3);
                }
            }

        }

        
    }
    
    
}
