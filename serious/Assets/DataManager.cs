using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    SaveData saveData = new SaveData();
    string filePath;
    string fileName = "save.json";
    

    private void Awake()
    {
        filePath = Application.persistentDataPath + "/" + fileName;

        if (!File.Exists(filePath))
        {
            Save(saveData);
        }
        saveData = Load();
    }

    public void Save(SaveData data)
    {
        string json = JsonUtility.ToJson(data);
        StreamWriter sw = new StreamWriter(filePath,false);
        sw.Write(json);
        sw.Flush();
        sw.Close();
    }

    public SaveData Load()
    {
        StreamReader sr = new StreamReader(filePath);
        string json = sr.ReadToEnd();
        sr.Close();
        return JsonUtility.FromJson<SaveData>(json);
    }

    public void SaveReset()
    {
        SaveData sd = new SaveData();        
        GameObject.Find("SoundSet").GetComponent<SoundSet>().SoundReset();
        GameObject.Find("ScoreSave").GetComponent<ScoreSave>().ScoreReset();
        Save(sd);
    }
}
