using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance = null;

    public static SoundManager Instance {
        get {
            return instance;
        }
    }
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
        
       
    }
    private void Start()
    {
        SceneManager.sceneLoaded += OnLoadScene;
        SceneManager.sceneLoaded -= OnLoadScene;
    }

    private void OnLoadScene(Scene scene, LoadSceneMode arg1)
    {
        if (scene.name == "GameOver") {
            Destroy(this.gameObject);
        }
    }

    
}
