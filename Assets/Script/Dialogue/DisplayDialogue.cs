using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDialogue : MonoBehaviour
{
    public Conversation conversation;

    public GameObject leftSpeaker;
    public GameObject rightSpeaker;

    private SpeakerUI leftSpeakerUI;
    private SpeakerUI rightSpeakerUI;

    private int activeLineIndex = 0;

    void Start()
    {
        leftSpeakerUI = leftSpeaker.GetComponent<SpeakerUI>();
        leftSpeakerUI.Speaker = conversation.leftSpeaker;

        rightSpeakerUI = rightSpeaker.GetComponent<SpeakerUI>();
        rightSpeakerUI.Speaker = conversation.rightSpeaker;
    }

    void Update()
    {
        if (Input.GetKeyDown("space")) {
            AdvanceConversation();
        }
    }

    void AdvanceConversation() {
        if (activeLineIndex < conversation.lines.Length) {
            DisplayLine();
            activeLineIndex += 1;

        } else {
            leftSpeakerUI.Hide();
            rightSpeakerUI.Hide();
            activeLineIndex = 0;
        }
    }

    void DisplayLine() {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (leftSpeakerUI.SpeakerIs(character)) {
            SetDialogue(leftSpeakerUI, rightSpeakerUI, line.dialogue);

        } else {
            SetDialogue(rightSpeakerUI, leftSpeakerUI, line.dialogue);
        }
    }

    void SetDialogue(
        SpeakerUI activeSpeaker,
        SpeakerUI inactiveSpeaker,
        string text
    ) {

        activeSpeaker.Dialogue = text;

        StopAllCoroutines();
        StartCoroutine(TypeSentence(activeSpeaker, text));

        activeSpeaker.Show();
        inactiveSpeaker.Hide();
    }

    IEnumerator TypeSentence(SpeakerUI speaker, string sentence) {
        speaker.dialogue.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            speaker.dialogue.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }
}