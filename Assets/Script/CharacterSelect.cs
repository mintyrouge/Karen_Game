using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Globals {
    public static Character chosenPlayer;
}

public class CharacterSelect : MonoBehaviour {

    public void SelectPlayer(Character player) {
        Globals.chosenPlayer = player;
        SceneManager.LoadScene(4);
    }

    void Start() { }
    void Update() { }
}
