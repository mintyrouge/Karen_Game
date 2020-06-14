using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReplyController : MonoBehaviour
{

    public Reply reply;
    public Text replyText;
    public Button choiceButton;

    private List<ChoiceController> choiceControllers = new List<ChoiceController>();

    public void Change(Reply _reply) {
        RemoveChoices();
        reply = _reply;
        gameObject.SetActive(true);
        Initialize();
    }

    public void Hide(Conversation conversation) {
        RemoveChoices();
        gameObject.SetActive(false);
    }

    public void RemoveChoices() {
        foreach (ChoiceController c in choiceControllers) {
            Destroy(c.gameObject);
        }

        choiceControllers.Clear();
    }

    public void Initialize() {

        replyText.text = reply.text;

        for (int i = 0; i < reply.choices.Length; i++) {
            ChoiceController c = ChoiceController.AddChoiceOption(choiceButton, reply.choices[i], i);
            choiceControllers.Add(c);
        }

        choiceButton.gameObject.SetActive(false);
    }

    void Start() { }

}
