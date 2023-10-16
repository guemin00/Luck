using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BossPaternIce : MonoBehaviour
{
    [SerializeField] GameObject[] _maps;
    [SerializeField] GameObject[] _skills;
    [SerializeField] GameObject[] _dangerBox;
    [SerializeField] GameObject _boss;
    [SerializeField] GameObject _player;

    Transform _playerPos;
    Transform _bossPos;
    float _skillTime = 0f;
    int _count = 0;
    int _nextPatern;

    float CylinderCool = 30;
    float ClystalCool = 20;
    float spearCool = 5;

    bool CylinderReady = false;
    bool ClystalReady = false;
    bool spearReady = false;

    private void Start()
    {
        _playerPos = GameObject.Find("Player").GetComponent<Transform>();
        _bossPos = GameObject.Find("Boss").GetComponent<Transform>();
        _nextPatern = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (CameraLimit.instance.nextMap == 2)
        {
            CylinderCool -= Time.deltaTime;
            spearCool -= Time.deltaTime;
            ClystalCool -= Time.deltaTime;
            if (CylinderCool <= 0)
            {
                CylinderReady = true;
                //CylinderCool = 15;
            }
            
            if (spearCool <= 0)
            {
                spearReady = true;
                //spearCool = 20;
            }
           
            if (ClystalCool <= 0)
            {
                ClystalReady = true;
                //ClystalCool = 10;
            }
            Skills();
        }
        
    }

    void Skills()
    {
        if(_nextPatern == 0 && CylinderReady == true)
        {
            IceCylinder();
            CylinderReady = false; CylinderCool = 30;
        }
        else if (_nextPatern == 1 && spearReady == true)
        {
            StartCoroutine(CoIceSpear());
            spearReady = false; spearCool = 20;
        }
        else if (_nextPatern == 2 && ClystalReady == true)
        {
            StartCoroutine(Coclystal());
            ClystalReady = false; ClystalCool = 5;
        }
        
    }

    void IceCylinder()
    {
        if(_nextPatern == 0)
        {
            _dangerBox[0].gameObject.transform.position = _playerPos.position;
            _dangerBox[1].gameObject.transform.position = _playerPos.position;
            _skills[0].gameObject.transform.position = _dangerBox[0].gameObject.transform.position;
            _skills[1].gameObject.transform.position = _dangerBox[1].gameObject.transform.position;
            GameObject box = Instantiate(_dangerBox[0]);
            GameObject box2 = Instantiate(_dangerBox[1]);   
            box.GetComponent<Animator>().Play("DangerBox");
            box2.GetComponent<Animator>().Play("DangerBox");
            Destroy(box, 1f);
            Destroy(box2, 1f);
            StartCoroutine(Cylinder());
            _nextPatern = Random.Range(0, 3);
        } 
        IEnumerator Cylinder()
        {
            yield return new WaitForSeconds(0.5f);
            Debug.Log("실행되었습니다." + _skillTime);
            GameObject Cylinder = Instantiate(_skills[0]);
            GameObject Cylinder2 = Instantiate(_skills[1]);
            Cylinder.GetComponent<Animator>().Play("IceCylinder");
            Cylinder2.GetComponent<Animator>().Play("IceCylinder");
            Cylinder.GetComponent<BoxCollider2D>().isTrigger = false;
            Cylinder2.GetComponent<BoxCollider2D>().isTrigger = false;
            Destroy(Cylinder, 5f);
            Destroy(Cylinder2, 5f);

        }
    }

    void IceSpear()
    {
        if(_nextPatern == 1)
        {
            Debug.Log("실행");
            _dangerBox[2].gameObject.transform.position = _playerPos.position;
            _skills[2].gameObject.transform.position = new Vector3(_dangerBox[2].gameObject.transform.position.x, _dangerBox[2].gameObject.transform.position.y + 30f, 0);
            GameObject temp2 = Instantiate(_dangerBox[2]);
            temp2.GetComponent<Animator>().Play("DangerBox");
            Destroy(temp2, 0.5f);
            StartCoroutine(Spear());
            _count++;
            if(_count > 5)
            {
                _count = 0;
                _nextPatern = Random.Range(0, 3);
            }
        }
    }
    IEnumerator Spear()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject temp = Instantiate(_skills[2]);
        temp.GetComponent<Animator>().Play("IceSpear");
        Destroy(temp, 3f);
        Debug.Log(_count);
    }
    IEnumerator CoIceSpear()
    {
        do
        {
            IceSpear();
            yield return new WaitForSeconds(1f);
        }
        while (_count < 5);


    }

    void IceClystal()
    {
        _dangerBox[3].gameObject.transform.position = _playerPos.position;
        _skills[3].gameObject.transform.position = _playerPos.position;
        GameObject temp2 = Instantiate(_dangerBox[3]);
        temp2.GetComponent<Animator>().Play("DangerBox");
        Destroy(temp2, 0.5f);
        StartCoroutine(Clystal());
        _count++;
        if(_count > 5)
        {
            _count = 0;
            _nextPatern= Random.Range(0, 3);
        }

        IEnumerator Clystal()
        {
            yield return new WaitForSeconds(0.3f);
            GameObject temp = Instantiate(_skills[3]);
            temp.GetComponent<Animator>().Play("IceClystal");
            Destroy(temp, 2f);
        }
        
    }
    IEnumerator Coclystal()
    {
        do
        {
            IceClystal();
            yield return new WaitForSeconds(0.5f);
        }
        while (_count < 5);

    }
}
