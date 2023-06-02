using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class treasureDeposit : MonoBehaviour
{
    private gameManager _gameManager;
    private treasureSpawner _treasureSpawn;
    public GameObject UIobject;
    public GameObject alert;
    public GameObject bravo;
    private void Start()
    {
        _gameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
        _treasureSpawn = GameObject.Find("gameManager").GetComponent<treasureSpawner>();
        UIobject.SetActive(false);
        alert.SetActive(false);
        bravo.SetActive(false);
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Follower" )
        {
            if (Input.GetKeyDown("l"))
            {
                if (_gameManager.recollectedTreasures == 3)
                {
                    bravo.SetActive(true);
                    _gameManager.recollectedTreasures -= 4;
                    _treasureSpawn.regulatorTreasure -= 3;
                    _gameManager.totalTreasures += 1000;
                }
                else if (_gameManager.recollectedTreasures < 3)
                {
                    alert.SetActive(true);                    
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIobject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIobject.SetActive(false);
            alert.SetActive(false);
            bravo.SetActive(false);
        }
    }
}
