using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    // Works like a list but is more restricted (uses FIFO data structure)
    private Queue<string> sentences;


    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

}
