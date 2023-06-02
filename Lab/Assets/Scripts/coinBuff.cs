using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBuff : MonoBehaviour
{
   private gameManager _gameManager;
   public int plusCoins;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag == "Player")
      {
         GameObject.Find("gameManager").GetComponent<gameManager>().MakeRicher(plusCoins);
         Destroy(gameObject);
      }
   }
}
