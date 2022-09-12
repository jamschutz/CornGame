using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;


public class SaveManager : MonoBehaviour
{
    public SaveData saveData { get; private set; }
    public string saveDataFileName = "saveData.json";


    // singleton instance
    public static SaveManager instance;


    private string saveDataFilePath;
    void Awake()
    {
        // ensure singleton instance 
        if(SaveManager.instance != null && SaveManager.instance != this) {
            Destroy(this.gameObject);
        }
        else {
            SaveManager.instance = this;
        }

        saveDataFilePath = $"{Application.persistentDataPath}/{saveDataFileName}";
        LoadData();
    }


    void OnApplicationQuit()
    {
        SaveData();
    }


    void LoadData()
    {
        try {
            var json = File.ReadAllText(saveDataFilePath);
            saveData = JsonUtility.FromJson<SaveData>(json);    
        }
        catch {
            Debug.LogWarning("unable to load save file");
            CreateNewSaveData();
        }
        
    }


    void SaveData()
    {
        var json = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveDataFilePath, json);
    }


    void CreateNewSaveData()
    {
        saveData = new SaveData();
        saveData.gameStartDate = DateTime.Now;
        saveData.numTimesWatered = 0;
        saveData.cornStalkName = "";
    }
}



public class SaveData
{
    public string cornStalkName { get; set; }
    public int numTimesWatered { get; set; }
    public DateTime gameStartDate { get; set; }
    public DateTime lastWaterTime { get; set; }

}