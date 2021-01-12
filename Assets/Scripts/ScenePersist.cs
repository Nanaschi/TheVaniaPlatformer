using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenePersist : MonoBehaviour
{
    int startingScene;
    private void Awake()
    {
       
        var scenePersist = FindObjectsOfType<ScenePersist>().Length;
        if (scenePersist > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
        startingScene = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        if (currentScene != startingScene)
        {
            Destroy(gameObject);
        }
    }

   

}
