using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
    private bool currentHighlight = false;
    [SerializeField]
    private Material defaultMaterial;
    [SerializeField]
    private Material highlightMaterial;
    [SerializeField]
    private Color clickDownColour;
    private Renderer r;
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
    public void HighlightObject(bool highlight)
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
        Debug.Log(name + " has been clicked!");
    }
}
