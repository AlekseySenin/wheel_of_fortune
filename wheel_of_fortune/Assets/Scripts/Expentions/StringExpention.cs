using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringExpention
{
    public static string ToVertical(this string str)
    {
        string resoult = "";

        foreach (var item in str)
        {
            resoult += item + "\n";
        }

        return resoult;
    }
}
