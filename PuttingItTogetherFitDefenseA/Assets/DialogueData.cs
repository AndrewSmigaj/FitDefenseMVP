using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class DialogueEvent : UnityEvent<bool> { }


public class DialogueData : MonoBehaviour
{

    public TMPro.TextMeshProUGUI dialogueTextBox;
    public Canvas dialogueCanvas;

    public GameObject nextDialogueZone = null;

    public bool isLast = false;

    public Transform AILocation = null;

    public string dialogue = "";

    public bool hasAdditionalActions;

    public DialogueEvent dialogueProcessed = new DialogueEvent();

    public float dialogueDuration = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
