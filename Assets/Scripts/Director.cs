using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public class Director : MonoBehaviour
{
    public static Director Instance;

    public int highScore = 0;
    public string highScorePlayerName = string.Empty;
    public string PlayerName = string.Empty;

    //public static string PlayerName = string.Empty;

    /*
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    */

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadData();
    }

    [System.Serializable]
    class BreakoutSaveData
    {
        public string PlayerName;

        public int HighScore;
        public string HighScorePlayerName;
    }

    public void SaveData()
    {
        BreakoutSaveData data = new BreakoutSaveData();

        data.PlayerName = PlayerName;
        data.HighScore = highScore;
        data.HighScorePlayerName = highScorePlayerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            BreakoutSaveData data = JsonUtility.FromJson<BreakoutSaveData>(json);

            PlayerName = data.PlayerName;
            highScore = data.HighScore;
            highScorePlayerName = data.HighScorePlayerName;

            //PlayerName = highScorePlayerName;
        }
    }
}
