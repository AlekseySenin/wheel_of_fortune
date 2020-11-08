using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IntExpantion 
{
    private static string[] powers = { "", "k", "m", "b", "t" };

    public static string ToShirtString(this int val)
    {
        string inString =  val.ToString();
        string outString = "";
        int index = (inString.Length) / 3;
        while (inString.Length > 6)
        {
            inString = inString.Substring(0, inString.Length - 3);
        }
        if (inString.Length <= 3) outString = inString;
        else if (inString.Length == 4) outString = inString.Substring(0, 1) + "," + inString.Substring(1, 2) + powers[index];
        else if (inString.Length == 5) outString = inString.Substring(0, 2) + powers[index];
        else if (inString.Length == 6) outString = inString.Substring(0, 3) + powers[index - 1];
        return outString;
    }
}
