﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Choice {
    [TextArea(2, 5)]
    public string text;
    public Conversation conversation;
}

[CreateAssetMenu(fileName = "New Reply", menuName = "Reply")]
public class Reply : ScriptableObject {
    [TextArea(2, 5)]
    public string text;
    public Choice[] choices;
}
