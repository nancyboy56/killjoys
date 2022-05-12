using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookItem : MonoBehaviour, IInteractable
{
    public bool currentHighlight = false;
    [SerializeField]
    private Material defaultMaterial;
    [SerializeField]
    private Material highlightMaterial;
    [SerializeField]
    private Color clickDownColour;
    private Renderer r;
    private GameObject dialouge;
    private string dialougeNode;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //calls to hig
    public void Highlight(bool highlight)
    {
        currentHighlight = highlight;
        if (currentHighlight)
        {
            r.material = highlightMaterial;
        }
        else
        {
            r.material = defaultMaterial;
        }
    }

    public void OnClick()
    {
        
    }

    public void OnInteract()
    {
        // will display dialouge
        Debug.Log(name + " has been clicked!");
    }

    public void OnHover()
    {
        Highlight(true);
    }

    public void LeaveHover()
    {
        Highlight(false);
    }
}
