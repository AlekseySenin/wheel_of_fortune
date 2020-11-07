using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class SetableObject<T> : MonoBehaviour
{
    protected static Action<T> OnSetup;
    public static void Setup(T val)
    {
        OnSetup?.Invoke(val);
    }

    protected abstract void SetInstance(T val);
   

    protected virtual void Start()
    {
        OnSetup += SetInstance;
    }

}
