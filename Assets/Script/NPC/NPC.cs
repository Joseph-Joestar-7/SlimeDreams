using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour, I_Interactable
{
    //[SerializeField] private NPCDialogue dialogueData;

    [SerializeField] private NPCDialogue[] dialogueSequence;
    private int currentDialogueSet = 0;
    private NPCDialogue CurrentDialogue => dialogueSequence[currentDialogueSet];

    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText, nameText;
    [SerializeField] private Image portraitImage;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    public bool canInteract()
    {
        return !isDialogueActive;
    }
    public void Interact()
    {
        if (CurrentDialogue == null)
        {
            return;
        }

        if(isDialogueActive)
        {
            NextLine();
        }
        else
        {
            StartDialogue();
        }
    }

    void StartDialogue()
    {
        isDialogueActive = true;
        dialogueIndex = 0;

        nameText.SetText(CurrentDialogue.npcName);
        portraitImage.sprite = CurrentDialogue.npcPotrait;

        dialoguePanel.SetActive(true);

        StartCoroutine(TypeLine());
        
    }

    void NextLine()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.SetText(CurrentDialogue.dialogueLines[dialogueIndex]);
            isTyping = false;
        }
        else if (++dialogueIndex < CurrentDialogue.dialogueLines.Length)
        {
            StartCoroutine(TypeLine()); 
        }
        else
        {
            EndDialogue();
        }
    }

    IEnumerator TypeLine()
    {
        isTyping = true;
        dialogueText.SetText("");

        foreach(char letter in CurrentDialogue.dialogueLines[dialogueIndex])
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(CurrentDialogue.typingSpeed);
        }

        isTyping=false;

        if(CurrentDialogue.autoProgressLines.Length > dialogueIndex && CurrentDialogue.autoProgressLines[dialogueIndex] )
        {
            yield return new WaitForSeconds(CurrentDialogue.autoPorgressDelay);
            NextLine();
        }
    }

    public void EndDialogue()
    {
        StopAllCoroutines();
        isDialogueActive = false;
        dialogueText.SetText("");
        dialoguePanel.SetActive(false);

        if (currentDialogueSet < dialogueSequence.Length - 1)
            currentDialogueSet++;
    }


}
    
