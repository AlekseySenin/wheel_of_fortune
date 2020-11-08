using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;

    private void Start()
    {
        Display();
        GameController.OnScoreChanged += Display;
    }

    private void OnDestroy()
    {
        GameController.OnScoreChanged -= Display;
    }

    void Display()
    {
        textMesh.text = GameController.Score.ToShirtString();
    }
}
