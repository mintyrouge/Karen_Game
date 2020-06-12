using UnityEngine;
using UnityEngine.UI;

public class SpeakerUI : MonoBehaviour
{
    public Image image;
    public Text name;
    public Text dialogue;

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
