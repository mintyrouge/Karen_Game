using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

[System.Serializable]
public class ConversationChangeEvent : UnityEvent<Conversation> { }

public class ChoiceController : MonoBehaviour {

    public Choice choice;
    public ConversationChangeEvent conversationChangeEvent;
    public TextMeshProUGUI TMP_text;

    public static ChoiceController AddChoiceOption(Button template, Choice choice, int idx) {
        int spacing = 25;
        Button button = Instantiate(template);


        // Basic methods that help style the newly instantiated button.
        button.transform.SetParent(template.transform.parent);
        button.transform.localScale = Vector3.one;
        button.transform.localPosition = new Vector3(0, idx * spacing, 0);
        button.name = "Choice " + (idx + 1);
        button.gameObject.SetActive(true);

        // Assigns the choice to the button.
        ChoiceController choiceController = button.GetComponent<ChoiceController>();
        choiceController.choice = choice;
        return choiceController;
    }

    // Start is called before the first frame update
    private void Start() {
        if (conversationChangeEvent == null) {
            conversationChangeEvent = new ConversationChangeEvent();
        }

        // Assigns the text within the button to the text belonging to choice.
        TMP_text.text = choice.text;
        
    }

    public void MakeChoice() {
        conversationChangeEvent.Invoke(choice.conversation);
    }

}
