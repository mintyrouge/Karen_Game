using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharacterPersist : MonoBehaviour
{
    public TMP_Text playerText;
    public Image playerImage;

    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log(Globals.chosenPlayer.name);
        playerText.text = "You picked " + Globals.chosenPlayer.name;
        playerImage.sprite = Globals.chosenPlayer.image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
