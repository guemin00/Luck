using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseEvent : GenericSingleTon<ChooseEvent>
{
    [SerializeField] GameObject[] _blackChoose;
    [SerializeField] GameObject[] _whiteChoose;
    Button _blackButton;
    Button _whiteButton;
    DiceRoll _diceRoll;
    Portal _portal;
    
    int _round = 0;
    // task : black Choose 리스트와 white Choose 리스트 만들기
    // task : 리스트 중에서 랜덤으로 각각 한가지씩 이벤트가 나와 둘중에 하나 선택 가능
    // task : 이벤트를 선택하면 해당 글로 써진 이벤트 발생
    // tasK : 이벤트는 라운드를 넘어갈때 발생 6-> 5라운드로 



    private void Start()
    {
        _portal = GetComponent<Portal>();
        _blackButton = GameObject.FindGameObjectWithTag("black").GetComponent<Button>();
        _whiteButton = GameObject.FindGameObjectWithTag("white").GetComponent<Button>();
        //_round = _portal._rounds;
         
        
    }


    public void R1BlackChoose()
    {
        //if(_round == 1)
        //{
        
      
        _blackButton.GetComponent<Animator>().SetBool("_choosed", false);
            
            for (int i = 7; i <= 9; i++)
            {
                _diceRoll._diceEye.Add(i);
            }
            for (int i = 4; i <= 6; i++)
            {
                _diceRoll._diceEye.Remove(i);
            }
            _blackButton.GetComponent<Animator>().SetBool("_choosed", true);
        //}
        
    }

    public void R1WhiteChoose()
    {
        //if(_round == 1)
        //{
        //_whiteChoose[0].active = true;
        _whiteButton.GetComponent<Animator>().SetBool("_choosed", false);
            
            for (int i = 7; i <= 10; i++)
            {
                _diceRoll._diceEye.Add(i);
            }
            //_whiteChoose[0].active = false;
            _whiteButton.GetComponent<Animator>().SetBool("_choosed", true);
        //}
        
    }

    public void R2BlackChoose()
    {
        if(_round == 2)
        {
        
            
        }
    }
    public void R2WhiteChoose()
    {

    }
}
