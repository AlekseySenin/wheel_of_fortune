﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WheelElement : MonoBehaviour, iSetable<int>
{
    [SerializeField] private TextMeshProUGUI ValueText;
    [SerializeField] private UnityEngine.UI.Image image;
    [SerializeField] private List<Color> colors;

    public void SetInstance(int val)
    {
        if (colors.Count > 0)
        {
            image.color = colors[Random.Range(0, colors.Count)];
        }
        ValueText.text = val.ToString().ToVertical();

    }
}
