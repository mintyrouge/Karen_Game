using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Notification : MonoBehaviour
{
    public GameObject entry;
    public GameObject fail;
    public GameObject win;

    public void EnterStore() {
        entry.SetActive(false);
    }

    public void ShowNotification(GameObject notif) {
        notif.SetActive(true);
    }

    public void LeaveStore() {
        SceneManager.LoadScene(0);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
