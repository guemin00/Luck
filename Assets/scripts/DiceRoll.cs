using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{

    PlayerControl playerControl;

    public int _Dice;
    public List<int> _diceEye;
    int _rollCount = 0;
    int _diceDamage = 0;
    int _saveDice = 0;

    private void Start()
    {
        playerControl = GetComponent<PlayerControl>();
        //enemyControl = GetComponent<EnemyControl>();
        _diceEye = new List<int> { 1, 2, 3, 4, 5, 6 };
        //_enemyDiceEye = new List<int> {1,2,3,4,5,6 };
        

    }



    // Update is called once per frame
    void Update()
    {
        RollDice();
       // EnemyRollDice();
    }


   public void RollDice()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _Dice = _diceEye[Random.Range(0, _diceEye.Count)]; 
            _diceDamage = _Dice;
            _saveDice = _Dice;
            //playerControl.GetAD += _diceDamage;
            _rollCount++;
            Debug.Log(_Dice);
            Debug.Log(playerControl.GetAD);
            if(_rollCount > 1) 
            {
              //  playerControl.GetAD -= _saveDice;
                _diceDamage = 0;
                _Dice = 0;
                _rollCount = 0;
                _saveDice = 0;

            }
        }
    }
}
