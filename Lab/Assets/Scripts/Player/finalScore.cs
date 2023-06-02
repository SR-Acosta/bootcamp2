using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class finalScore : MonoBehaviour
{
    public TMP_Text score;
    private int scoreValue;

    private void Start()
    {
        PlayerPrefs.GetInt("finalScore");
    }

    private void Update()
    {
        scoreValue = PlayerPrefs.GetInt("finalScore");
        score.text = scoreValue.ToString();
    }
}
