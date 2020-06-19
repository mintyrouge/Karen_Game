using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int sceneIdx;

    // Start is called before the first frame update
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: sceneIdx);
    }

    private void OnTriggerEnter2D()
    {
        LoadScene();
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
