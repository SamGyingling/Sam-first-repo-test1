using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    //This code enables you to access the MainManager object from any other script.  
    public static MainManager Instance;
    public Color TeamColor;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;   
    }

    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path)){
            string json = File.ReadAllText(path);
            SaveData date = JsonUtility.FromJson<SaveData>(json);
            TeamColor = date.TeamColor;
        }
    }

}


