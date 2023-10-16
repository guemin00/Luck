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

    public static BossControlThunder instance;
    Transform _playerPos;
    Transform _bossPos;
    int _nextPatern;
    bool _skillfinish = false;
    float CoolTime;
    float _Hp;
    public float HP { get { return _Hp; } set { _Hp = value; } }

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _playerPos = GameObject.Find("Player").GetComponent<Transform>();
        _bossPos = GameObject.Find("BossThunder").GetComponent<Transform>();
        _nextPatern = 0;
        _skillfinish = true;
        HP = 100;
    }

    private void Update()
    {
        if (CameraLimit.instance.nextMap == 5)
        {
            StartCoroutine(DoSkill());
            CoolTime -= Time.deltaTime;
            if(CoolTime <= 0)
            {
                CoolTime = 20;
            }
        }
        
    }

    IEnumerator DoSkill()
    {
        yield return new WaitForSeconds(2f);
        if (_nextPatern == 0 && _skillfinish == true)
        {
            InvokeRepeating("Thunder", 0, 3f);
        }
        else if (_nextPatern == 1 && _skillfinish == true && CoolTime < 7)
        {
            ThunderMove();
        }
        else if (_nextPatern == 2 && _skillfinish == true && CoolTime < 15)
        {
            ThunderShoot();
        }
    }


    void Thunder()
    {
        _skillfinish = false;
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
            StartCoroutine(SkillCheck());
        }

        IEnumerator SkillCheck()
        {
            yield return new WaitForSeconds(4f);
            _nextPatern = Random.Range(1, 3);
            _skillfinish = true;
        }
    }


    void ThunderMove()
    {
        _skillfinish = false;
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
            StartCoroutine(SkillCheck());
        }

        IEnumerator SkillCheck()
        {
            yield return new WaitForSeconds(10f);
                _nextPatern = Random.Range(1, 3);
                _skillfinish = true;

        }
    }



    void ThunderShoot()
    {
        _skillfinish = false;
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
            StartCoroutine(SkillCheck());
        }

        IEnumerator SkillCheck()
        {
            yield return new WaitForSeconds(4f);
                _nextPatern = Random.Range(1, 3);
                _skillfinish = true;
        }
    }
}
