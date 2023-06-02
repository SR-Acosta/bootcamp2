using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class gameOverMenu : MonoBehaviour
{
    public string sceneName;
    public void changeScene()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(sceneName);
    }
}
