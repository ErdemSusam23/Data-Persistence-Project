using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] public TMP_InputField inputField;

    public string testText;

    

    public void StartButton() 
    {
        SceneManager.LoadScene(1);
    }

    public void ExitButton()
    {
        EditorApplication.ExitPlaymode();
    }

    public void InputButton() 
    {
        Debug.Log("Input Field Log:");
        Debug.Log(inputField.text);
        testText = inputField.text;
        Debug.Log("Test Text Log:");
        Debug.Log(testText);
        
        Manager.Instance.SaveUsername();
    }
}
