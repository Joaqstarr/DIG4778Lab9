using UnityEditor.Overlays;
using UnityEngine;

public class SaveAndLoadInput : MonoBehaviour
{

    private SavingHandler _savingHandler = new SavingHandler();
    private float _inputCooldown = 1f;
    private float _inputTimer = 0f;

    private void Update()
    {
        if(_inputTimer > 0f)
        {
            _inputTimer -= Time.deltaTime;
            return;
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Save();
            _inputTimer = _inputCooldown;
            return;
        }

        if (Input.GetKey(KeyCode.L))
        {
            Load();
            _inputTimer = _inputCooldown;
            return;
        }
    }


    public void Save()
    {
        SaveData saveData = new SaveData();
        // Find all MonoBehaviours in the scene and call SaveState on those that implement ISaveable
        var allMono = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        foreach (var mb in allMono)
        {
            if (mb is ISaveable saveable)
            {
                saveable.SaveState(saveData);
            }
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            _savingHandler.SaveDataBinary(saveData);
        }
        else
        {
            _savingHandler.SaveDataJson(saveData);
        }
        Debug.Log("Save complete.");
    }

    public void Load()
    {
        SaveData data;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            data = _savingHandler.LoadFromBinary();
        }
        else
        {
            data = _savingHandler.LoadFromJson();
        }
        ApplyLoad(data);
        Debug.Log("Load complete.");

    }
    private void ApplyLoad(SaveData saveData)
    {
        var allMono = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);
        foreach (var mb in allMono)
        {
            if (mb is ISaveable saveable)
            {
                saveable.LoadState(saveData);
            }
        }
    }
}
