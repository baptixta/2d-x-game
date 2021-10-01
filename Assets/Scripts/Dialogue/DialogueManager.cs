using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Animator animator;
    private Queue<string> sentences;
    public static DialogueManager instance;
    void Start()
    {
        instance = this;
        sentences = new Queue<string>();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(Dialogue dialogue) 
    {
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentece = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentece));    
    }

    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.025f);
        }
    }

    public delegate void OnEndDialogue();
    public event OnEndDialogue onEndDialogueEvent;

    public void EndDialogue() 
    {
        animator.SetBool("IsOpen", false);
        Player.playerControlsEnabled = true;

        if (onEndDialogueEvent != null)
        {
            onEndDialogueEvent.Invoke();
        }
    }
}
