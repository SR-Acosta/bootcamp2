using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class flaskPowerUp : MonoBehaviour
{
    private playerController _playerController;
    public float healing;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerController>().TakeHeal(healing);
            Destroy(gameObject);
        }
    }
}
