using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject _objectPrefab;
    [SerializeField]
    private int _poolSize = 10;
    private List<GameObject> _pool = new List<GameObject>();


    private void Start()
    {
        for(int i = 0; i < _poolSize; i++)
        {
            GameObject obj = Instantiate(_objectPrefab);
            obj.SetActive(false);
            _pool.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        foreach(GameObject obj in _pool)
        {
            if(!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        GameObject newObj = Instantiate(_objectPrefab);
        newObj.SetActive(true);
        _pool.Add(newObj);
        return newObj;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
