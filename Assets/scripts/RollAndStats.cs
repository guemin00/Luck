using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollAndStats : MonoBehaviour
{
    [SerializeField] GameObject _player;


    public int _Dice;
    public List<int> _diceEye;
    int _point = 0;
    int _rollCount = 0;
    
    int _currentRounds = 0;


    int _Ad = 2;
    int _Hp = 50;
    float _As = 3;

    public int AD { get { return _Ad; } set { _Ad = value; } }
    public int HP { get { return _Hp; } set { _Hp = value; } }
    public float AS { get { return _As; } set { _As = value; } }

    int _AdPoint;
    int _HpPoint;
    int _AsPoint;

    void Start()
    {
        _diceEye = new List<int> { 1, 2, 3, 4, 5, 6 };

    }

    // Update is called once per frame
    void Update()
    {
        
        RollDice();
    }

    void RollDice()
    {
        if (GameObject.Find("Portals").GetComponent<Portal>()._rounds > _currentRounds)
        {
            Time.timeScale = 0;
        }
        if (Input.GetKeyDown(KeyCode.R) && _rollCount == 0)
        {
            _rollCount++;
            _Dice = _diceEye[Random.Range(0, _diceEye.Count)];
            _point = _Dice;
            Debug.Log(_point);

        }


    }

    // 끝나면 버튼 사라지는거 구현해야함
    public void GetPointAD()
    {
        if(_point > 0) 
        {
            _Ad += 2;
            _point--;
            Debug.Log(_Ad);
            

        }
        else if (_point <= 0)
        {
            _currentRounds++;
            _rollCount = 0;
            Time.timeScale = 1;
        }
    }

    public void GetPointHP()
    {
        if(_point > 0)
        {
            _Hp += 5;
            _point--;
            Debug.Log(_Hp); 
        }
        else if (_point <= 0)
        {
            _currentRounds++;
            _rollCount = 0;
            Time.timeScale = 1;
        }
    }

    public void GetPointAS()
    {
        if( _point > 0)
        {
            _As -= 0.2f;
            _point--;
            Debug.Log(_As);
        }
       else if (_point <= 0)
        {
            _currentRounds++;
            _rollCount = 0;
            Time.timeScale = 1;
        }
    }
}
