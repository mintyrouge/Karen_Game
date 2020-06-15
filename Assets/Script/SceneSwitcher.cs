using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
   
    public void GotoGarbucks()
    {
        SceneManager.LoadScene("GarbucksAltercation");
    }
}