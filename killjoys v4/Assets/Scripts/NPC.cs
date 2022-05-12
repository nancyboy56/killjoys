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
        dialogueRunner.StartDialogue(startNode);
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogueRunner = FindObjectOfType<DialogueRunner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
