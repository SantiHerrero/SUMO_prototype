using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemys = new GameObject[1];
    public GameObject[] powerUps = new GameObject[1];
    private const int _spawnRange = 9;
    private const int _spawnRateEnemy = 10;
    private const int _spawnDelayEnemy = 1;
    private const int _spawnDelayPowerUp = 1;
    private const int _spawnRatePowerUp = 10;
    private int _enemyWave;

    // Start is called before the first frame update

    void Start()
    {
        _enemyWave = 1;
        InvokeRepeating("spawnPowerUp",_spawnDelayPowerUp,_spawnRatePowerUp);
        InvokeRepeating("spawnEnemyWave",_spawnDelayEnemy,_spawnRateEnemy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private Vector3 getRandomPos()
    {
        return new Vector3(Random.Range(-_spawnRange, _spawnRange), 0, 
            Random.Range(-_spawnRange, _spawnRange));
    }

    private void spawnPowerUp()
    {
        Instantiate(powerUps[0], getRandomPos(), powerUps[0].transform.rotation);   
    }
    
    private void spawnEnemyWave()
    {
        for (int i = 0; i < _enemyWave; i++)
            Instantiate(enemys[0], getRandomPos(), enemys[0].transform.rotation);
        _enemyWave++;
    }
}
