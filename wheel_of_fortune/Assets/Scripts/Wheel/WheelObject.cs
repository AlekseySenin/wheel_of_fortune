using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WheelObject : MonoBehaviour, iSetable<WheelController>
{
    [SerializeField] List<WheelElement> elements;
    [SerializeField] UnityEngine.UI.Button spinButton;
    [SerializeField] GameObject Wheel;
    [SerializeField] int fullRevolutions;
    [SerializeField] float minRotationSpeed, maxRotationSpeed, speedDropAngle;

    private Action  OnSpinComplite;
    private double elementPassCounter;

    private float segmentAngle, totalRotationAngle, lastSpinAngle;
    private float currentRotationSpeed()
    {
        if (totalRotationAngle > speedDropAngle)
        {
         return   maxRotationSpeed;
        }

        float remainingSpeed = maxRotationSpeed - Mathf.Lerp(maxRotationSpeed, minRotationSpeed, totalRotationAngle / speedDropAngle);

        return remainingSpeed>= minRotationSpeed? remainingSpeed:minRotationSpeed ;
    }

    public void SetInstance(Action val)
    {
    }

    public void SetInstance(WheelController val)
    {
        spinButton.onClick.AddListener(() => val.OnStartSpin?.Invoke());
        OnSpinComplite += val.ReceiveWin;
        for (int i = 0; i < elements.Count; i++)
        {
            elements[i].SetInstance(val.wheelValues[i]);
        }
        segmentAngle = 360 / elements.Count;
    }
        
    public void SpinStarted(int winSegmentIndex)
    {
        float newSpinAngle = (segmentAngle * winSegmentIndex)+ Random.Range (segmentAngle*0.1f, segmentAngle*0.9f);
        totalRotationAngle = fullRevolutions * 360 + newSpinAngle - lastSpinAngle;
        lastSpinAngle = newSpinAngle;
        StartCoroutine(RotateWheel());
        spinButton.interactable = false;
        elementPassCounter = Math.Floor(Wheel.transform.rotation.eulerAngles.z / segmentAngle);
    }

    IEnumerator RotateWheel()
    {
        yield return null;
        if (totalRotationAngle >0)
        {
            if (elementPassCounter!= Math.Floor(Wheel.transform.rotation.eulerAngles.z / segmentAngle))
            {
                elementPassCounter = Math.Floor(Wheel.transform.rotation.eulerAngles.z / segmentAngle);
                SoundManager.PlaySound(SoundType.drummClick);
            }
            Wheel.transform.Rotate(new Vector3(0,0, currentRotationSpeed() * Time.deltaTime));            
            totalRotationAngle -= currentRotationSpeed() * Time.deltaTime;
            StartCoroutine(RotateWheel());

        }
        else
        {
            spinButton.interactable = true;

            Wheel.transform.Rotate(new Vector3(0, 0, -totalRotationAngle));
            OnSpinComplite?.Invoke();
        }
    }
}
