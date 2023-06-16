using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveClass : MonoBehaviour
{
   public static SaveClass Instance;

    public string userName;

    public int highScore = 0;
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
}
