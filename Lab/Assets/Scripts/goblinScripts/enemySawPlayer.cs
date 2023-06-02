using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class enemySawPlayer : MonoBehaviour
{
    private AIDestinationSetter targetManager;
    private Transform playerDetected;
    private Transform reloadFollower;
    private Animator anim;
    void Start()
    {
        anim = GetComponentInParent<Animator>();
        targetManager = GetComponentInParent<AIDestinationSetter>();
        targetManager.target = GameObject.FindWithTag("Follower").transform;
        playerDetected = GameObject.FindWithTag("Player").transform;
        reloadFollower =  GameObject.FindWithTag("Follower").transform;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            targetManager.target = playerDetected;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            targetManager.target = reloadFollower;
        }
    }
}
