using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSwordDamage : MonoBehaviour
{
    private goblinLife _goblinLife;
    public float _playerSwordDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemies")
        {
            other.gameObject.GetComponent<goblinLife>().TakeDamage(_playerSwordDamage);
        }
    }
    
    public void MakeStronger(float damage)
    {
        _playerSwordDamage += damage;
    }
}
