using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public struct Line {
    public Character character;

    [TextArea(2, 5)]
    public string dialogue;
}

[CreateAssetMenu(fileName = "New Conversation", menuName = "Conversation")]
public class Conversation : ScriptableObject { 
    public Character leftSpeaker;
    public Character rightSpeaker;
    public Reply reply;
    public bool failure;
    public bool winner;
    public Line[] lines;

}
