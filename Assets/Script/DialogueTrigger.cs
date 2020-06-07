using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue() {

        // This will find the GameObject called DialogueManager, and execute a function that exists within the DialogueManager script.
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
