using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WheelController : MonoBehaviour, iSetable<RandomIntListGeneratorSettings>
{
    [SerializeField] private RandomIntListGeneratorSettings generatorSettings;
    [SerializeField] private List<int> segmentValues;
    [SerializeField] private WheelObject wheelObject;

    public void SetInstance(RandomIntListGeneratorSettings val)
    {
        generatorSettings = val;
    }

    public static int SpinResoultIndex { get; private set; }

    public List<int> wheelValues { get; private set; } = new List<int>();

    public  Action  <List<int>> OnWheelSet;
    public  Action OnStartSpin;
    public  Action<int> OnStinFinished;
    public bool canSpin { get; private set; } = true;


    private void Awake()
    {
        OnStartSpin += Spin;
        OnStinFinished += wheelObject.SpinStarted;
        ShowWheel();
    }


    public  void ShowWheel()
    {
        Setup();
    }

    private void Setup()
    {
        wheelValues = RandomIntListGenerator.Generate(generatorSettings);
        wheelObject.SetInstance(this);
    }

    private void Spin()
    {
        if (canSpin)
        {
            canSpin = false;
            SpinResoultIndex = Random.Range(0, wheelValues.Count);
            OnStinFinished?.Invoke(SpinResoultIndex);
        }
    }

    public void ReceiveWin()
    {
        canSpin = true;
        GameController.Score += wheelValues[SpinResoultIndex]; 
        SoundManager.PlaySound(SoundType.coinWin);
    }
}
