
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<KeyType, ValueType> : Dictionary<KeyType, ValueType>, ISerializationCallbackReceiver, ISerializable
{
    public List<KeyType> _serializedKeys = new List<KeyType>();
    public List<ValueType> _serializedValues = new List<ValueType>();

    public SerializableDictionary() : base() { }
    public void OnAfterDeserialize()
    {
        Clear();
        int count = Mathf.Min(_serializedKeys.Count, _serializedValues.Count);
        for (int i = 0; i < count; i++)
        {
            this[_serializedKeys[i]] = _serializedValues[i];
        }
    }

    public void OnBeforeSerialize()
    {
        _serializedKeys = new(Keys);
        _serializedValues = new(Values);
    }

    protected SerializableDictionary(SerializationInfo info, StreamingContext context)
    {
        // For each serialized item, add it back to the dictionary
        foreach (SerializationEntry entry in info)
        {
            if (entry.Name == "keys")
            {
                _serializedKeys = (List<KeyType>)entry.Value;
            }
            else if (entry.Name == "values")
            {
                _serializedValues = (List<ValueType>)entry.Value;
            }
        }
        // Then populate the dictionary from the deserialized lists
        OnAfterDeserialize();
    }

    public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
    {
        // Before serializing, update the internal lists
        OnBeforeSerialize();

        // Populate the info with the key and value lists
        info.AddValue("keys", _serializedKeys);
        info.AddValue("values", _serializedValues);
    }


}
