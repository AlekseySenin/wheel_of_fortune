using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private static int _Score;
    public static Action OnScoreChanged;
    public static int Score
    {
        get
        {
            if (_Score == 0)
            {
                _Score = SaveSystem.LoadScore();
                Debug.Log("Loaded");
            }
            return _Score;

        }

        set
        {
          
            _Score = value;
            SaveSystem.SaveScore(value);
            OnScoreChanged?.Invoke();
        }
    }

    private void Start()
    {
        Score = SaveSystem.LoadScore();
    }
}
