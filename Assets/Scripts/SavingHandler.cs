using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    public SerializableDictionary<string, SerializableVector3> _objectPositions = new SerializableDictionary<string, SerializableVector3>();
    public int _score;
}

public class SavingHandler
{
    public string _jsonFileName = "saveData.json";
    public string _binaryFileName = "saveData.bin";
    public SaveData LoadSaveData()
    {
        LoadFromBinary();
        return LoadFromJson();
    }

    public SaveData LoadFromBinary()
    {
        SaveData saveData = new SaveData();
        string path = Path.Combine(Application.persistentDataPath, _binaryFileName);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();


            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                SaveData data = formatter.Deserialize(stream) as SaveData;
                return data;
            }
        }
        else
        {
            Debug.LogWarning("Save file not found in " + path);
            return saveData;
        }
    }

    public SaveData LoadFromJson()
    {
        SaveData saveData = new SaveData();
        var dataPath = Path.Combine(Application.persistentDataPath, _jsonFileName);

        if (!File.Exists(dataPath))
        {
            Debug.LogErrorFormat("No file exists at {0}", dataPath);
            return saveData;
        }

        var text = File.ReadAllText(dataPath);

        JsonUtility.FromJsonOverwrite(text, saveData);
        return saveData;
    }

    public void SaveData(SaveData saveData)
    {
        SaveDataJson(saveData);

        SaveDataBinary(saveData);

    }

    public void SaveDataJson(SaveData saveData)
    {
        var dataPath = Path.Combine(Application.persistentDataPath, _jsonFileName);
        var json = JsonUtility.ToJson(saveData, true);
        File.WriteAllText(dataPath, json);
        
    }

    public void SaveDataBinary(SaveData saveData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Path.Combine(Application.persistentDataPath, _binaryFileName);

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            formatter.Serialize(stream, saveData);
        }
    }
}

public interface ISaveable
{
    public void SaveState(SaveData saveData);
    public void LoadState(SaveData saveData);
}
