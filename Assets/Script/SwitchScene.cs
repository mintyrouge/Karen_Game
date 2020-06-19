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

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }

    private void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(5);
    }

    // Update is called once per frame
    public void QuitGame()
    {
        Application.Quit();
    }
}
