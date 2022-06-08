using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SceneUIManager : MonoBehaviour
{
    public static SceneUIManager Instance;
    public string playerName;
    public int highScore;
    public string hScorerName;
    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        highScore = 0;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string name;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.name = hScorerName;
        data.highScore = highScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.highScore;
            hScorerName = data.name;
        }
    }

}
