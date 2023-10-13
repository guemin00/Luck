using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControlTree : MonoBehaviour
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
        _bossPos = GameObject.Find("TreeBoss").GetComponent<Transform>();
        _nextPatern = 2;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.T) && _nextPatern == 0)
        {
            Leaf();
        }
        else if(Input.GetKeyDown(KeyCode.T) && _nextPatern == 1)
        {
            TreeHitBig();
        }

        else if(Input.GetKeyDown(KeyCode.T) && _nextPatern == 2)
        {
            TreeBarrier();
        }
    }

    void Leaf()
    {
        _dangerBox[0].gameObject.transform.position = new Vector3(_bossPos.position.x+Random.Range(-10, 10), _bossPos.position.y-3, 0);
        _skills[0].transform.position = _dangerBox[0].transform.position;
        GameObject temp2 = Instantiate(_dangerBox[0]);
        temp2.GetComponent<Animator>().Play("DangerBox");
        Destroy(temp2, 0.3f);
        StartCoroutine(MakeTree());

        IEnumerator MakeTree()
        {
            yield return new WaitForSeconds(3f);
            GameObject temp = Instantiate(_skills[0]);
            temp.GetComponentInChildren<ParticleSystem>().Play();
            _nextPatern = Random.Range(0, 2);
        }
    }


    void TreeHitBig()
    {
        _dangerBox[1].transform.position = new Vector3(_bossPos.position.x +10, _bossPos.position.y, 0);
        _dangerBox[2].transform.position = new Vector3(_bossPos.position.x -10, _bossPos.position.y, _bossPos.position.z);
        _skills[1].transform.position = _dangerBox[1].transform.position;
        _skills[2].transform.position = _dangerBox[2].transform.position;
        GameObject Danger1 = Instantiate(_dangerBox[1]);
        Danger1.GetComponent<Animator>().Play("DangerBox");
        Destroy(Danger1, 0.5f);
        StartCoroutine(Tree1());

        IEnumerator Tree1()
        {
            yield return new WaitForSeconds(1f);
            GameObject tree = Instantiate(_skills[1]);
            tree.GetComponent<Animator>().Play("TreeHit");
            Destroy(tree, 2f);
            StartCoroutine(Danger2());
        }

        IEnumerator Danger2()
        {
            yield return new WaitForSeconds(3f);
            GameObject Dangerbox = Instantiate(_dangerBox[2]);
            Dangerbox.GetComponent<Animator>().Play("DangerBox");
            Destroy(Dangerbox, 0.5f);
            StartCoroutine(Tree2());
        }

        IEnumerator Tree2()
        {
            yield return new WaitForSeconds(1f);
            GameObject tree = Instantiate(_skills[2]);
            tree.GetComponent<Animator>().Play("TreeHitReverse");
            Destroy(tree, 2f);
            StartCoroutine(All());
        }

        IEnumerator All()
        {
            yield return new WaitForSeconds(3f);
            GameObject tree = Instantiate(_skills[1]);
            GameObject tree2 = Instantiate(_skills[2]);
            tree.GetComponent<Animator>().Play("TreeHit");
            tree2.GetComponent<Animator>().Play("TreeHitReverse");
            Destroy(tree, 2f);
            Destroy(tree2, 2f);
            _nextPatern = Random.Range(0, 2);

        }
    }


    void TreeBarrier()
    {
        _dangerBox[3].transform.position = _bossPos.position;
        _skills[3].transform.position = _dangerBox[3].transform.position;
        GameObject Danger = Instantiate(_dangerBox[3]);
        Danger.GetComponent<Animator>().Play("DangerCircle");
        Destroy(Danger, 1f);
        StartCoroutine(Barrier());

        IEnumerator Barrier()
        {
            yield return new WaitForSeconds(1f);
            GameObject barr = Instantiate(_skills[3]);
            barr.GetComponent<Animator>().Play("TreeShield");
            Destroy(barr, 15f);
            _nextPatern = Random.Range(0, 2);
        }

    }


}
