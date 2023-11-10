using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("Apple Score")]
    private int CountApples;
    public Text textApples;

    private void Start()
    {
        CountApples = PlayerPrefs.GetInt("Apples");
        textApples.text = CountApples.ToString();
    }

    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
