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
        if(Input.GetKeyDown(KeyCode.B))
        {
            InvokeRepeating("Thunder", 0, 1f);
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
}
