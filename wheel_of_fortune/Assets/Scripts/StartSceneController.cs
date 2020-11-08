using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartSceneController : MonoBehaviour
{
    [SerializeField] private Button starButton;
    [SerializeField] private int sceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        starButton.onClick.AddListener(StartScene);
    }

    private void StartScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
