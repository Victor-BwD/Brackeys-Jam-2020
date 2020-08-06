using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string name;
    public Transform enemy;
    public int cont;
    public float rate;
}
public class SpawnWave : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING};

    public Wave[] waves;
    private int nextWave = 0;

    public Transform[] spawnPoint;

    public float timeBetweenWaves = 5f;
    public float waveContdown;

    private float searchCountdown = 1f;

    

    private SpawnState state = SpawnState.COUNTING;

    // Start is called before the first frame update
    void Start()
    {
        if (spawnPoint.Length == 0)
        {
            Debug.LogError("No spawn point reference!");
        }
        waveContdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if(state == SpawnState.WAITING)
        {
            //check if enemy are still alive
            if(!EnemyIsAlive())
            {
                //begin a new round
                WaveCompleted();
                
                return;
            }
            else
            {
                return;
            }
        }

        if(waveContdown <= 0)
        {
           if(state != SpawnState.SPAWNING)
            {
                //start spawning wave
                StartCoroutine(_SpawnWave(waves[nextWave]));
            }    
        }
        else
        {
            waveContdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        Debug.Log("Wave Completed!");
        state = SpawnState.COUNTING;
        waveContdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("Completed all waves. looping...");
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyIsAlive()
    {
        searchCountdown -= Time.deltaTime;
        if(searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator _SpawnWave(Wave _wave)
    {
        
        state = SpawnState.SPAWNING;

        //spawn
        for (int i = 0; i < _wave.cont; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy(Transform _enemy)
    {
        //spawn enemy
        
   

        Transform _sp = spawnPoint[Random.Range(0, spawnPoint.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
        
    }


}
