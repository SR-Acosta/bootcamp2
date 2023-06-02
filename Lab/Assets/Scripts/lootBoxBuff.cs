using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lootBoxBuff : MonoBehaviour
{
    private playerSwordDamage _damage;
    public float buffDamage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponentInChildren<playerSwordDamage>().MakeStronger(buffDamage);
            Destroy(gameObject);
        }
    }
}
