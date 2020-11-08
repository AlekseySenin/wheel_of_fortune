using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public interface iSetable<T>
{
    void SetInstance(T val);
}

