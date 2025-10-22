using UnityEngine;

[RequireComponent(typeof(UniqueId))]
public class TransformSaver : MonoBehaviour, ISaveable
{
    private UniqueId _uniqueId;

    private void Awake()
    {
        _uniqueId = GetComponent<UniqueId>();
    }
    public void LoadState(SaveData saveData)
    {
        if (saveData._objectPositions.TryGetValue(_uniqueId.uniqueId, out SerializableVector3 savedPosition))
        {
            transform.position = savedPosition;
        }
    }

    public void SaveState(SaveData saveData)
    {
        saveData._objectPositions[_uniqueId.uniqueId] = transform.position;
    }
}
