using System;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class MenuUI : MonoBehaviour
{


    public void StartButton() 
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton() 
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); 
#endif
    }

    public void InputButton(string s) 
    {
        SaveClass.Instance.userName = s;
        Debug.Log(SaveClass.Instance.userName);
    }
}
