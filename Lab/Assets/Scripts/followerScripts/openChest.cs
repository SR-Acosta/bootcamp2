using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openChest : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Treasure")
        {
            _animator.SetBool("isOpen",true);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Treasure")
        {
            _animator.SetBool("isOpen",false);
        }
    }
}
