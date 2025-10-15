using System;
using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    [SerializeField]
    private string _scorePrefix = "Score: ";

    private TMP_Text _scoreText;

    private void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
    }
    private void OnEnable()
    {
        ScoreManager.ScoreUpdated += UpdateScoreText;
    }
    private void OnDisable()
    {
        ScoreManager.ScoreUpdated -= UpdateScoreText;
    }

    private void UpdateScoreText(int newScore)
    {
        _scoreText.text = _scorePrefix + newScore;
    }
}
