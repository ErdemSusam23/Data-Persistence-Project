using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Brick BrickPrefab;
    public int LineCount = 6;
    public Rigidbody Ball;

    public Text ScoreText;
    public Text NameText;
    public Text BestScoreText;
    public GameObject GameOverText;
    
    private bool m_Started = false;
    private int m_Points;
    
    private bool m_GameOver = false;

    
    // Start is called before the first frame update
    void Start()
    {
        const float step = 0.6f;
        int perLine = Mathf.FloorToInt(4.0f / step);
        
        int[] pointCountArray = new [] {1,1,2,2,5,5};
        for (int i = 0; i < LineCount; ++i)
        {
            for (int x = 0; x < perLine; ++x)
            {
                Vector3 position = new Vector3(-1.5f + step * x, 2.5f + i * 0.3f, 0);
                var brick = Instantiate(BrickPrefab, position, Quaternion.identity);
                brick.PointValue = pointCountArray[i];
                brick.onDestroyed.AddListener(AddPoint);
            }
        }
        
    }

    private void Update()
    {
        if (!m_Started)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_Started = true;
                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                Ball.transform.SetParent(null);
                Ball.AddForce(forceDir * 2.0f, ForceMode.VelocityChange);
            }
        }
        else if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"Score : {m_Points}";
    }

    public void GameOver()
    {
        SetHighestScore();
        SaveScore();
        m_GameOver = true;
        GameOverText.SetActive(true);
    }

    public void SetUserName() 
    {
        NameText.text = $"Name : {Manager.Instance.userName}";
    }

    public void SetHighestScore() 
    {
        if (m_Points > Manager.Instance.bestScore)
        {
            Manager.Instance.bestScore = m_Points;
            BestScoreText.text = $" Highest Score : {Manager.Instance.bestScore}";
        }
        else
        {
            BestScoreText.text = $" Highest Score : {Manager.Instance.bestScore}";
        }
        
    }
    private void Awake()
    {
        SetUserName();
        LoadScore();
        SetHighestScore();
        
        
    }

    [System.Serializable]
    class SaveData
    {
        public int highestScore;
    }
    public void SaveScore() 
    {
        SaveData saveData = new SaveData();
        saveData.highestScore = Manager.Instance.bestScore;

        string json =  JsonUtility.ToJson(saveData);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadScore() 
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            Manager.Instance.bestScore = saveData.highestScore;
        }
    }
}
