using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class followerSawEnemy : MonoBehaviour
{
    private AIPath _aiPath;
    private void Start()
    {
        _aiPath = GetComponentInParent<AIPath>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemies")
        {
            _aiPath.canMove = false;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemies")
        {
            _aiPath.canMove = true;
        }
    }
}
