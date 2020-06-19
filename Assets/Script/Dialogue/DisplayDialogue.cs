using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

[System.Serializable]
public class ReplyEvent : UnityEvent<Reply> { }

public class DisplayDialogue : MonoBehaviour
{
    public Conversation conversation;
    public ReplyEvent replyEvent;

    public GameObject leftSpeaker;
    public GameObject rightSpeaker;

    public GameObject failPanel;
    public GameObject winPanel;

    private SpeakerUI leftSpeakerUI;
    private SpeakerUI rightSpeakerUI;

    private int activeLineIndex;
    private bool conversationStarted = false;

    public void ChangeConversation(Conversation nextConversation) {
        conversationStarted = false;
        conversation = nextConversation;
        AdvanceLine();
    }

    private void Start()
    {
        leftSpeakerUI = leftSpeaker.GetComponent<SpeakerUI>();
        leftSpeakerUI.Speaker = conversation.leftSpeaker;

        rightSpeakerUI = rightSpeaker.GetComponent<SpeakerUI>();
        rightSpeakerUI.Speaker = conversation.rightSpeaker;
    }

    private void Update()
    {
        if (Input.GetKeyDown("space")) {
            AdvanceLine();

        } else if (Input.GetKeyDown(KeyCode.Escape)) {
            EndConversation();
        }
    }

    private void EndConversation() {

        if (conversation.failure == true) {
            Debug.Log("You faile.d");
            failPanel.SetActive(true);
            winPanel.SetActive(false);
        } 

        if (conversation.winner == true) {
            Debug.Log("u got tjias");
            failPanel.SetActive(false);
            winPanel.SetActive(true);
        }

        conversation = null;
        conversationStarted = false;
        leftSpeakerUI.Hide();
        rightSpeakerUI.Hide();
    }

    private void Initialize() {
        conversationStarted = true;
        activeLineIndex = 0;
        leftSpeakerUI.Speaker = conversation.leftSpeaker;
        rightSpeakerUI.Speaker = conversation.rightSpeaker;
    }

    private void AdvanceLine() {
        if (conversation == null) {
            return;
        }

        if (!conversationStarted) {
            Initialize();
        }

        if (activeLineIndex < conversation.lines.Length) {
            DisplayLine();

        } else {
            AdvanceConversation();
        }
    }

    private void AdvanceConversation() {
        if (conversation.reply != null) {
            replyEvent.Invoke(conversation.reply);

        } else {
            EndConversation();
        }
    }

    void DisplayLine() {
        Line line = conversation.lines[activeLineIndex];
        Character character = line.character;

        if (leftSpeakerUI.SpeakerIs(character)) {
            SetDialogue(leftSpeakerUI, rightSpeakerUI, line.dialogue);
            SetEmotion(leftSpeakerUI);

        } else {
            SetDialogue(rightSpeakerUI, leftSpeakerUI, line.dialogue);
            SetEmotion(rightSpeakerUI);

        }

        activeLineIndex += 1;
    }

    void SetEmotion(SpeakerUI emotion) {
        Line line = conversation.lines[activeLineIndex];
        emotion.image.sprite = line.character.image;

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