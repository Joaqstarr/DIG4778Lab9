using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour, ISaveable
{
    private int _score = 0;

    public delegate void OnScoreUpdated(int newScore);

    public static event OnScoreUpdated ScoreUpdated;


    private void Start()
    {
        ScoreUpdated?.Invoke(_score);
    }
    private void OnEnable()
    {
        TargetDestruction.OnTargetDestroyed += UpdateScore;
    }

    private void OnDisable()
    {
        TargetDestruction.OnTargetDestroyed -= UpdateScore;
    }

    private void UpdateScore(int points)
    {
        _score += points;
        ScoreUpdated?.Invoke(_score);
    }

    public void SaveState(SaveData saveData)
    {
        saveData._score = _score;
    }

    public void LoadState(SaveData saveData)
    {
        _score = saveData._score;
        ScoreUpdated?.Invoke(_score);
    }
}
