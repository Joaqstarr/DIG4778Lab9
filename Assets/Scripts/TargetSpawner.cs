using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField]
    private List<TargetFactory> _targetFactories;

    [SerializeField]
    private float _spawnInterval = 2f;

    private void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    IEnumerator SpawnTargets()
    {
        while(true)
        {
            TargetFactory targetFactory = _targetFactories[Random.Range(0, _targetFactories.Count)];

            targetFactory.ConstructTarget(transform.position);
            yield return new WaitForSeconds(Random.Range(_spawnInterval, _spawnInterval*2));
        }
    }
}
