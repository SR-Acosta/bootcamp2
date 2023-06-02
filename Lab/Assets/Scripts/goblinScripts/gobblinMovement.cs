using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class gobblinMovement : MonoBehaviour
{
    public Animator _animator;
    private AIPath _path;
    public Transform goblinGX;
    public Transform goblinLifeBarGX;
    private void Start()
    {
        _path = GetComponent<AIPath>();
    }
    private void Update()
    {
        SideTurning();
        MoveY();
    }
    private void SideTurning()
    {
        Vector2 distance =_path.desiredVelocity;
        if (distance.x > 0.2f)
        {
            goblinGX.transform.localScale = new Vector3(1f, 1f, 1f);
            goblinLifeBarGX.transform.localScale = new Vector3(1f, 1f, 1f);
            _animator.SetFloat("moveX", distance.x);
        }
        if (distance.x < -0.2f)
        {
            goblinGX.transform.localScale = new Vector3(-1f, 1f, 1f);
            goblinLifeBarGX.transform.localScale = new Vector3(-1f, 1f, 1f);
            _animator.SetFloat("moveX", distance.x);
        }
    }
    private void MoveY()
    {
        Vector2 distance =_path.desiredVelocity;
        if (distance.y > 0.2f)
        {
            _animator.SetFloat("moveY", distance.y);
        }
        if (distance.y < -0.2f)
        {
            _animator.SetFloat("moveY", distance.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAttack")
        {
            _animator.SetBool("isHit",true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "PlayerAttack")
        {
            _animator.SetBool("isHit",false);
        }
    }
}
