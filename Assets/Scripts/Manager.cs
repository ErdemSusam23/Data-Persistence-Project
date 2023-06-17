using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager Instance;

    public TMP_InputField inputField;

    public string userName;

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
        userName = inputField.text;
        Debug.Log(userName);
    }
}
