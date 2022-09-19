using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public Color TeamColor;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        LoadColor();
        DontDestroyOnLoad(gameObject);
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
        string Json   = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", Json);

    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string Json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(Json);
            TeamColor = data.TeamColor;
        }
    }
    public void SaveButtonPressed()
    {
        SaveColor();
    }

}
