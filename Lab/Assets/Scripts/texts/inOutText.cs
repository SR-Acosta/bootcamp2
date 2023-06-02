using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class inOutText : MonoBehaviour
{
   public GameObject UIobject;

   private void Start()
   {
      UIobject.SetActive(false);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.gameObject.tag == "Player")
      {
         UIobject.SetActive(true);
      }
   }

   private void OnTriggerExit2D(Collider2D other)
   {
      UIobject.SetActive(false);
   }
}
