using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GateSlime : MonoBehaviour, I_Interactable
{
    [SerializeField] private NPCDialogue dialogueData;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText, nameText;
    [SerializeField] private Image portraitImage;

    private int dialogueIndex;
    private bool isTyping, isDialogueActive;

    public void Interact()
    {
        Debug.Log("Hi");
    }

}
    
