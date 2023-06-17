using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public void StartButton() 
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        EditorApplication.ExitPlaymode();
    }
}
