using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;
using TMPro;
public class treasureDetector : MonoBehaviour
{
    public GameObject UIobject;
    private AIDestinationSetter targetManager;
    private AIPath _aiPath;
    private Transform treasureDetected;
    
    private Transform meta;
    private gameManager _gameManager;
    private Transform reloadPlayer;

    private void Start()
    {
        UIobject.SetActive(false);
        _gameManager = GameObject.Find("gameManager").GetComponent<gameManager>();
        meta = GameObject.FindWithTag("Finish").transform;

        _aiPath = GetComponentInParent<AIPath>();
        targetManager = GetComponentInParent<AIDestinationSetter>();
        targetManager.target = GameObject.FindWithTag("Player").transform;
        reloadPlayer = GameObject.FindWithTag("Player").transform;

    }
    private void Update()
    {
        allTreasures();
        ResetQuest();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Treasure")
        {
            targetManager.target = other.transform;
            _aiPath.endReachedDistance = 0.3f;
        }

        if (other.gameObject.tag == "Finish")
        {
            UIobject.SetActive(false);
        } 
    }

    private void ResetQuest()
    {
        if (_gameManager.recollectedTreasures == -1)
        {
            targetManager.target = reloadPlayer;
            _gameManager.recollectedTreasures += 1;
        }
    }
    private void allTreasures()
    {
        if (_gameManager.recollectedTreasures == 3)
        {
            targetManager.target = meta;
            UIobject.SetActive(true);
        }
    }
}
