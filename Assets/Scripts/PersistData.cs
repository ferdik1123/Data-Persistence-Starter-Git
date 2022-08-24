using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class PersistData : MonoBehaviour
{
    public static PersistData Instance;

    [SerializeField] ButtonManager buttonManager;
    public string textInputField;
    public string bestScoreText;
    public int bestPoints;
     
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadName();           
        }
        else
        {
            Destroy(gameObject);
        }                  
    }

    [Serializable]
    class SaveData
    {
        public string textInputField;
        public string bestScoreText;
        public int bestPoints;
    }

    public void ResetScore()
    {
        textInputField = "";
        bestScoreText = "Best score:";
        bestPoints = 0;
        SaveName();
        
    }

    public void SaveName()
    {
        SaveData data = new SaveData();
        data.textInputField = textInputField;
        data.bestScoreText = bestScoreText;
        data.bestPoints = bestPoints;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    

    public void LoadName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            textInputField = data.textInputField;
            bestScoreText = data.bestScoreText;
            bestPoints = data.bestPoints;
        }
    }
}
