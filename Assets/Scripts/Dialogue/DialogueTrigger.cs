using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public UnityEvent onEndDialogue;

    public void TriggerDialogue() {
        DialogueManager.instance.onEndDialogueEvent += OnEndDialogue;
        DialogueManager.instance.StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Player.playerControlsEnabled = false;
        TriggerDialogue();        
    }

    void OnEndDialogue()
    {
        DialogueManager.instance.onEndDialogueEvent -= OnEndDialogue;

        onEndDialogue.Invoke();
    }
}
