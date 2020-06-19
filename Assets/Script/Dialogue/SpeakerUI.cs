using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpeakerUI : MonoBehaviour
{
    public Image image;
    new public TextMeshProUGUI name;
    public TextMeshProUGUI dialogue;

    private Character speaker;

    // Tracks who the active speaker is.
    public Character Speaker {
        get { return speaker; }
        set {
            speaker = value;
            image.sprite = speaker.image;
            name.text = speaker.name;
        }
    }

    public string Dialogue {
        set { dialogue.text = value;  }
    }

    public bool HasSpeaker() {
        return speaker != null;
    }

    public bool SpeakerIs(Character character) {
        return speaker == character;
    }

    public void Show() {
        gameObject.SetActive(true);

    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
