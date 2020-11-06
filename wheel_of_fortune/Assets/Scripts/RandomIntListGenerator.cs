using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class RandomIntListGeneratorSettings
{
    public int count, scale, step, minValue, maxValue;

}

[System.Serializable]
public static class RandomIntListGenerator
{
    static public List<int> Generate(RandomIntListGeneratorSettings nSegments)
    {
        var resultList = new List<int>();
        for (var i = 0; i < nSegments.count; i++)
        {
            var satisfiesCondition = false;
            while (!satisfiesCondition)
            {
                var elem = Random.Range(nSegments.minValue, nSegments.maxValue+1);
                satisfiesCondition = (
                  ((elem % nSegments.scale) == 0) &&
                  !resultList.Contains(elem) &&
                  //resultList.All(existingElem => Math.Abs(elem - existingElem) >= 1000)
                  ((i <= 0) || (Math.Abs(elem - resultList[i - 1]) >= 1000))
                );
                if (satisfiesCondition) resultList.Add(elem);
            }
        }
        return resultList;
    }
}
