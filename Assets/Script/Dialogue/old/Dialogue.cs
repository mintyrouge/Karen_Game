using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string name;
    
    // Allows you to increase the number of characters in the sentences you want to enter. 
    [TextArea(3, 10)]
    public string[] sentences;
}
