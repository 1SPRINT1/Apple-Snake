using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    private int CountApples;
    void Start()
    {
        CountApples = PlayerPrefs.GetInt("Apples");
    }

    
    void Update()
    {
        CountApples = PlayerPrefs.GetInt("Apples");
    }
}
