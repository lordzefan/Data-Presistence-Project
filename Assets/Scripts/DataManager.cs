using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    public string namePlayerBestScore = "Name ";
    public int pointScore = 0;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        // namePlayerBestScore = GameObject.Find("SaveScoreText").GetComponent<Text>();
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadNameScore();
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string namePlayerHighScore;
    }

    public void SaveNameScore()
    {
        SaveData data = new SaveData();
        data.highScore = pointScore;
        data.namePlayerHighScore = namePlayerBestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadNameScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        pointScore = data.highScore;
        namePlayerBestScore = data.namePlayerHighScore;
        }
    }
}
