using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{

    public List<Transform> _spawnPoints = new List<Transform>();
    public GameObject[] enemy;

 
    
    public float _spawnTime=1f;
    public float _spawnDelay;
    int _spawnAmountDice;
    int _diceEye;
    public int enemyCount = 0;


    public static MonsterSpawner _instance;

    private void Start()
    {
        _diceEye = Random.Range(6, 20);
        _spawnAmountDice = _diceEye;
        _instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if(_spawnDelay > _spawnTime && enemyCount < _spawnAmountDice)
        {
          SpawnEnemy();

        }
        _spawnDelay += Time.deltaTime;
        
    }


    public void SpawnEnemy()
    {
       
        _spawnDelay = 0;
    
        enemyCount++;
        
        Instantiate(enemy[0], _spawnPoints[Random.Range(0, _spawnPoints.Count)]);
        
       
    }

    


}
