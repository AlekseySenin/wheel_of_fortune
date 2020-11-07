using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WheelController : MonoBehaviour
{
    [SerializeField] private RandomIntListGeneratorSettings generatorSettings;
    [SerializeField] private List<int> segmentValues;
    [SerializeField] private WheelObject wheelWindow;


    public static int SpinResoultIndex { get; private set; }

    public static List<int> wheelValues { get; private set; } = new List<int>();

    private static Action OnShowWheel;
    private static Action OnStartSpin;
    public static Action<int> OnStinFinished;
    public static Action<int> OnRewardReceived;


    private void Awake()
    {
        OnShowWheel += Setup;
        OnStartSpin += Spin;
    }



    public static void ShowWheel()
    {
        OnShowWheel?.Invoke();
    }

    private void Setup()
    {
        wheelValues = RandomIntListGenerator.Generate(generatorSettings);
    }

    public static void StartSpin()
    {
        OnStartSpin?.Invoke();
    }

    private void Spin()
    {
        SpinResoultIndex = Random.Range(0, wheelValues.Count);
        OnStinFinished?.Invoke(SpinResoultIndex);
    }

    public static int ReceiveWin()
    {
        OnRewardReceived?.Invoke(wheelValues[SpinResoultIndex]);
        return (wheelValues[SpinResoultIndex]);
    }
}
