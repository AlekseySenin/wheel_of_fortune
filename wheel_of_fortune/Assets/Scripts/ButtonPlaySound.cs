using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPlaySound : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(()=>SoundManager.PlaySound(SoundType.buttonClick));
    }

}
