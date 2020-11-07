using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WheelObject : SetableObject<List <int>>
{
    [SerializeField] List<WheelElement> elements;
    [SerializeField] GameObject Wheel;
    [SerializeField] int fullRevolutions;
    [SerializeField] float startRotationSpeed, finishRotationSpeed, speedDropAngle;

    private float segmentAngle, totalRotationAngle, lastSpinAngle;
    private float currentRotationSpeed => totalRotationAngle > speedDropAngle ?
        startRotationSpeed :
        Mathf.Lerp(startRotationSpeed, finishRotationSpeed, totalRotationAngle / speedDropAngle);

    protected override void SetInstance(List<int> val)
    {
        for (int i = 0; i < elements.Count; i++)
        {
            elements[i].Setup(val[i]);
        }
        segmentAngle = 360 / elements.Count;
    }

    public void StartSpining(int winSegmentIndex)
    {
        float newSpinAngle = (segmentAngle * winSegmentIndex)+ Random.Range (segmentAngle*0.1f, segmentAngle*0.9f);
        totalRotationAngle = fullRevolutions + newSpinAngle - lastSpinAngle;
        lastSpinAngle = newSpinAngle;
    }

    IEnumerator RotateWheel()
    {
        yield return null;
        if (totalRotationAngle - currentRotationSpeed * Time.deltaTime>0)
        {
            Wheel.transform.Rotate(new Vector3(0,0, currentRotationSpeed * Time.deltaTime));
        }
        else
        {
            Wheel.transform.Rotate(new Vector3(0, 0, totalRotationAngle));
           
            WheelController.ReceiveWin();
        }
    }


}
