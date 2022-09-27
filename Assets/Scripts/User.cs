using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEngine;

public class User : MonoBehaviour
{

    public static User userInstance;

    public string userName { get; set; }
    public int Points { get; set; }

    public int maxPoints { get; set; }

    public string MaxName { get; set; }

    // Start is called before the first frame update
    void Awake()
    {
        if (userInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        userInstance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayerData();
    }

    public void MaxPlayer(string _name, int _points)
    {
        if (_points > maxPoints)
        {
            MaxName = _name;
            maxPoints = _points;
            SavePlayerData();
        }
        else
        {
            userName = _name;
            Points = _points;
            SavePlayerData();
        }

    }

    [System.Serializable]
    class SaveData
    {
        public string name;
        public int points;
        public string currentPlayer;
        public int currentPoint;
    }

    public void SavePlayerData()
    {
        SaveData data = new SaveData();
        data.name = MaxName;
        data.points = maxPoints;
        data.currentPlayer = userName;
        data.currentPoint = Points;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/playerData.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/playerData.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            MaxName = data.name;
            maxPoints = data.points;
            userName = data.currentPlayer;
            Points = data.currentPoint;
        }
    }


}
