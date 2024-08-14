using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    public string playerName;
    public int points = 0;
    public string enterName;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadPlayer();
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
    
    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int points;
    }

    public void SavePlayer()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.points = points;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayer()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {   
            string json = File.ReadAllText(path);
            Debug.Log("Loaded JSON: " + json);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            points = data.points;
        }
    }

    public void ReadStringInput(string str)
    {
        enterName = str;
        Debug.Log(enterName);
    }
}
