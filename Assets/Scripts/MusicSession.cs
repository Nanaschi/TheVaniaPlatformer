using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MusicSession : MonoBehaviour
{
    
    private void Awake()
    {
        var numGameSessions = FindObjectsOfType<MusicSession>().Length;
        if (numGameSessions > 1)
        {
            Destroy(gameObject);
        } else
        {
            DontDestroyOnLoad(gameObject);
        }
    }



}
