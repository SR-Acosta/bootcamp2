using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class treasureActivation : MonoBehaviour
{
    public GameObject t1, t2, t3;
    private gameManager _gameManager;
    private void Start()
    {
        t1.SetActive(false);
        t2.SetActive(false);
        t3.SetActive(false);
        _gameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
    }
    private void Update()
    {
        countTreasures();
    }
    private void countTreasures()
    {
        if (_gameManager.recollectedTreasures > 0)
        {
            t1.SetActive(true);
        }
        if (_gameManager.recollectedTreasures > 1)
        {
            t2.SetActive(true);
        }if (_gameManager.recollectedTreasures > 2)
        {
            t3.SetActive(true);
        }
        else if (_gameManager.recollectedTreasures < 1)
        {
            t1.SetActive(false);
            t2.SetActive(false);
            t3.SetActive(false);
        }
    }
}
