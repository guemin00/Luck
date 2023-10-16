using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RollAndStats : MonoBehaviour
{
    [SerializeField] GameObject _player;

    public static RollAndStats instance;

    public int _Dice;
    public Image _DiceImage;
    public Image _DiceCool;
    public Sprite[] _diceEyes;
    public Image _TypeImg;
    public Sprite[] _type;
    public List<int> _diceEye;
    int _point = 0;
    bool _RollReady = true;
    int _chooseCount = 1;

    int _Ad = 5;
    int _Hp = 50;
    public Slider _Hpimg;
    float _As = 3;

    float coolTimeMax= 10f;


    public int AD { get { return _Ad; } set { _Ad = value; } }
    public int HP { get { return _Hp; } set { _Hp = value; } }
    public float AS { get { return _As; } set { _As = value; } }

    PointType _PointType;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _diceEye = new List<int> { 1, 2, 3, 4, 5, 6 };
    }

    // Update is called once per frame
    void Update()
    {
        RollDice();
        Check();
        AddStat();
    }

    void RollDice()
    {
        if (Input.GetKeyDown(KeyCode.R) && _RollReady == true)
        {
            _RollReady = false;
            _Dice = _diceEye[Random.Range(0, _diceEye.Count)];
            _DiceImage.sprite = _diceEyes[_Dice-1];
            _point = _Dice;
            Debug.Log(_point);
            StartCoroutine(CoolTime(10f));
        }

        IEnumerator CoolTime(float cool)
        {
            while (cool > 0.0f)
            {
                cool-=Time.deltaTime;
                _DiceImage.fillAmount = cool / coolTimeMax;
                yield return new WaitForFixedUpdate();
            }

            _RollReady = true;  
        }
    }

    void Check()
    {
        Sprite Attack = _type[0];
        Sprite Health = _type[1];
        Sprite AttackSpd = _type[2];
        if (Input.GetMouseButtonDown(1))
        {
            _chooseCount++;
            if (_chooseCount == 1)
            {
                _PointType = PointType.AD;
                _TypeImg.sprite = Attack;
                Debug.Log(_PointType);
            }
            else if (_chooseCount == 2)
            {
                _PointType = PointType.HP;
                _TypeImg.sprite = Health;
                Debug.Log(_PointType);
            }
            else if (_chooseCount >= 3)
            {
                _PointType = PointType.AS;
                _TypeImg.sprite = AttackSpd;
                Debug.Log(_PointType);
                _chooseCount = 0;
            }
        }
    }

    void AddStat()
    {
        switch (_PointType) 
        {
            case PointType.AD:
                {
                    GetPointAD(); break;    
                }
            case PointType.HP:
                {
                    GetPointHP(); break;
                }
            case PointType.AS:
                {
                    GetPointAS(); break;    
                }
        }


    }
    public void GetPointAD()
    {
        if (_PointType == PointType.AD && Input.GetKeyDown(KeyCode.Q))
        {
            if(_point > 0)
            {
                _Ad += 2;
                _point--;
                Debug.Log(_Ad);
            }
            else if(_point < 0) 
            {
                Debug.Log("오류입니다.");
            }
            
        }

    }

    public void GetPointHP()
    {
        if (_PointType == PointType.HP && Input.GetKeyDown(KeyCode.Q))
        {
            if(_point >0)
            {
                _Hp += 5;
                _point--;
                Debug.Log(_Hp);
            }
        }
        else if (_point < 0)
        {
            Debug.Log("오류입니다.");
        }
    }

    public void GetPointAS()
    {
        if (_PointType == PointType.AS && Input.GetKeyDown(KeyCode.Q))
        {
            if(_point> 0)
            {
                _As -= 0.2f;
                _point--;
                Debug.Log(_As);
            }
        } 
        else if (_point < 0)
        {
            Debug.Log("오류입니다.");
        }

    }

    public enum PointType
    { 
        AD,
        HP,
        AS
    }
}
