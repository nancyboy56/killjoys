using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPC : MonoBehaviour, IInteractable
{
    private DialogueRunner dialogueRunner;
    [SerializeField]
    private string startNode;

    public void LeaveHover()
    {
        
    }

    public void OnHover()
    {
       
    }

    public void OnInteract()
    {
        StartConversation();
    }

    private void StartConversation()
    {
        dialogueRunner.StartDialogue(startNode);
       // Time.timeScale = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        dialogueRunner.onDialogueComplete.AddListener(EndConversation);
       
    }

    

    public void EndConversation()
    {
       // Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
