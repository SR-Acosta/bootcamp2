using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class waveManager : MonoBehaviour
{
    [Header("Arrays")]
    [Tooltip("The place you put the spawn points.")]
    public GameObject[] spawnPoints;
    [Tooltip("The place you put the enemies prefabs.")]
    public GameObject[] enemies;
    
    [Header("Important Data")]
    [Tooltip("Number of enemies in the scene. Int used for mob spawning.")]
    public int enemiesSpawned;
    [Tooltip("Time between the spawning of enemies.")]
    public float tiempoEnemigos;
    private float tiempoSiguienteEnemigo;
    private int enemyType;
    private gameManager _GM;

    [Header("Level difficulty")] 
    [Tooltip("Public variable to set the number of enemies you want in each level.")]
    public int dificultyLV1;
    [Tooltip("Public variable to set the number of enemies you want in each level.")]
    public int dificultyLV2;
    [Tooltip("Public variable to set the number of enemies you want in each level.")]
    public int dificultyLV3;
    private int difficultyLevel;
    
    private void Start()
    {
        _GM = GameObject.Find("gameManager").GetComponent<gameManager>();
    }
    private void Update()
    {
        difficulty();
        tiempoSiguienteEnemigo += Time.deltaTime;
        if (tiempoSiguienteEnemigo >= tiempoEnemigos)
        {
            tiempoSiguienteEnemigo = 0;
            CrearEnemigo();
        }
    }
    private void CrearEnemigo()
    {
        int spawnPos = Random.Range(0, 7);
        if (_GM.recollectedTreasures == 1)
        {
            enemyType = 0;
        }
        else if (_GM.recollectedTreasures == 2)
        {
            enemyType = Random.Range(0,2);
        }
        else if (_GM.recollectedTreasures == 3)
        {
            enemyType = Random.Range(0,3);
        }
        if (enemiesSpawned < difficultyLevel && _GM.recollectedTreasures >= 1)
        {
            Instantiate(enemies[enemyType], spawnPoints[spawnPos].transform.position, 
                spawnPoints[spawnPos].transform.rotation);
            enemiesSpawned += 1;
        }
    }
    private void difficulty()
    {
        if (_GM.recollectedTreasures == 1)
        {
            difficultyLevel = dificultyLV1;
        }
        else if (_GM.recollectedTreasures == 2)
        {
            difficultyLevel = dificultyLV2;
        }
        else if (_GM.recollectedTreasures == 3)
        {
            difficultyLevel = dificultyLV3;
        }
    }
}
