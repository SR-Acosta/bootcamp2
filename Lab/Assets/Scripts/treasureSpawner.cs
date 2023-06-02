using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class treasureSpawner : MonoBehaviour
{
    private gameManager _gameManager;
    private int setTreasure;
    public int regulatorTreasure;
    public GameObject[] treasure;
    public GameObject[] spawnPoints;
    private void Start()
    {
        _gameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
    }
    private void Update()
    {
        spawningTreasure();
    }
    private void spawningTreasure()
    {
        int spawnPos = Random.Range(0, 7);
        setTreasure = Random.Range(0,3);
        if (_gameManager.recollectedTreasures == 0 && regulatorTreasure < 3)
        {
            Instantiate(treasure[setTreasure], spawnPoints[spawnPos].transform.position, 
                spawnPoints[spawnPos].transform.rotation);
            regulatorTreasure += 1;
        }
    }
}
