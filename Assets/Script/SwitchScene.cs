﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int sceneIdx;

    // Start is called before the first frame update
    public void LoadScene()
    {
        Debug.Log("Scene: " + sceneIdx);
        SceneManager.LoadScene(sceneBuildIndex: sceneIdx);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Debug.Log("Quit Game bitch");
        Application.Quit();
    }
}