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
    // task : black Choose ����Ʈ�� white Choose ����Ʈ �����
    // task : ����Ʈ �߿��� �������� ���� �Ѱ����� �̺�Ʈ�� ���� ���߿� �ϳ� ���� ����
    // task : �̺�Ʈ�� �����ϸ� �ش� �۷� ���� �̺�Ʈ �߻�
    // tasK : �̺�Ʈ�� ���带 �Ѿ�� �߻� 6-> 5����� 



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
