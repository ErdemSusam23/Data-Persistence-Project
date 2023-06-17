using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public string userName;

    MenuUIHandler menuUIHandler;

    public int bestScore;

    private void Awake()
    {
        if (Instance != null) 
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SaveUsername() 
    {
        userName = menuUIHandler.inputField.text;
        Debug.Log("Username Log:");
        Debug.Log(userName);
    }
}
