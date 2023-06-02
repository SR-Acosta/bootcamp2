using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class overText : MonoBehaviour
{
    public GameObject UIelement;
    void Start()
    {
        UIelement.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIelement.SetActive(false);
            
        }
    }
}
