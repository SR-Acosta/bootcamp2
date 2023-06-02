using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class gameManager : MonoBehaviour
{
   public int recollectedTreasures;
      public int totalTreasures;
      public TMP_Text totalScore;
      private void Start()
      {
         recollectedTreasures = 0;
         totalTreasures = 0;
      }
   
      private void Update()
      {
         totalScore.text = totalTreasures.ToString();
         PlayerPrefs.SetInt("finalScore", totalTreasures);
      }
      public void MakeRicher(int money)
      {
         totalTreasures += money;
      }
}
