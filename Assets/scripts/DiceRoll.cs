using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{

    PlayerControl playerControl;
    //EnemyControl enemyControl;

   


    public int _Dice;
    public List<int> _diceEye;
    int _rollCount = 0;
    int _diceDamage = 0;
    int _saveDice = 0;

    /*
    public int _enemyDice;
    public List<int> _enemyDiceEye;
   public int _enemyDiceDamage= 0;
    int _saveDiceEnemy = 0;
    int _enemyRoll = 0;
    */



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

    /*
    public void EnemyRollDice()
    {
        // 생각해보니 초기화 할 필요 x
        if(Input.GetKeyDown(KeyCode.R))
        {
            _enemyDice = _enemyDiceEye[Random.Range(0, _enemyDiceEye.Count)];
            _enemyDiceDamage = _enemyDice;
            _saveDiceEnemy = _enemyDice;
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            foreach(var enemy in enemys)
            {
                if(enemy.GetComponent<EnemyControl>() != null)
                    enemy.GetComponent<EnemyControl>()._eAD += _enemyDiceDamage;

            }
            _enemyRoll++;
            Debug.Log(_enemyDice);
            if(_enemyRoll > 1)
            {
                foreach (var enemy in enemys)
                {
                    if (enemy.GetComponent<EnemyControl>() != null)
                        enemy.GetComponent<EnemyControl>()._eAD -= _saveDiceEnemy;

                }
                //enemyControl._eAD -= _saveDiceEnemy;
                _enemyDice = 0;
                _enemyDiceDamage = 0;
                _saveDiceEnemy = 0;
                _enemyRoll = 0;
            }
        }
    }
    */

}
