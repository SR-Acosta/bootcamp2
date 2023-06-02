using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
public class treasureOpen : MonoBehaviour
{
    private gameManager _GM;
    public int value = 1;
    public float openChest;
    private AIDestinationSetter _aiDestinationSetter;
    private Transform playerReTarget;
    private AIPath _aiPath;
    private Animator _animator;

    private AudioSource _audioSource;
    public AudioClip _open;
    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _GM = GameObject.Find("gameManager").GetComponent<gameManager>();
        _aiPath = GameObject.Find("Follower").GetComponent<AIPath>();
        _aiDestinationSetter = GameObject.Find("Follower").GetComponent<AIDestinationSetter>();
        playerReTarget = GameObject.Find("Player").GetComponent<Transform>();
        _animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Follower")
        {
            _audioSource.clip = _open;
            _audioSource.Play();
            _GM.recollectedTreasures += value;
            _animator.SetBool("isOpen",true);
            Destroy(gameObject, openChest);
            _aiDestinationSetter.target = playerReTarget.transform;
            _aiPath.endReachedDistance = 2f;
        }
    }
}
