using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class HighlightObjects : MonoBehaviour
{
    private PlayerInput controllerInput;
    [SerializeField] public Camera objectCamera;
    private RaycastHit lastHit;
    private Interactable lastHitHighlight;
    // Start is called before the first frame update
    void Start()
    {
        controllerInput = GetComponent<PlayerInput>();

        controllerInput.actions["Click"].performed += content =>Click();
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = 1 << 6;
        Ray ray = objectCamera.ScreenPointToRay(controllerInput.actions["MousePosition"].ReadValue<Vector2>());
        
        //the debug ray doesnt seem to work
        Debug.DrawRay(ray.origin, ray.direction, Color.magenta);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100, layerMask) )
        {
            if (!(lastHit.Equals(hit)))
            {
                UnhighlightLastObject();
                Debug.Log("New object: " + hit.transform.name);
                Interactable highlight;

                // this is assume i put the colliders are the children and the 2d sprite as the game object
                //i might change the order
                if(hit.transform.parent.gameObject.TryGetComponent<Interactable>(out highlight))
                {
                    highlight.HighlightObject(true);
                    lastHitHighlight = highlight;
                }

                
            }
            else
            {
                Debug.Log("Same Object: " + hit.transform.name);
            }
            lastHit = hit;
            Debug.Log("Hit:" + hit.transform.name);
            //  Debug.Log("hit");
        }
        else
        {
            UnhighlightLastObject();
            //if(last)
        }


    }

    public void Click()
    {
        if(lastHitHighlight!=null && lastHitHighlight.currentHighlight)
        {
            lastHitHighlight.OnClick();
        }
    }

    private void UnhighlightLastObject()
    {
        if (lastHitHighlight != null)
        {
            lastHitHighlight.HighlightObject(false);
            lastHitHighlight = null;
            Debug.Log("Unhilight: " + lastHit.transform.name);
        }
    }

    /* void OnDrawGizddmos()
     {
         // Draw a yellow sphere at the transform's position
         Gizmos.color = Color.yellow;


         Ray ray = camera.ScreenPointToRay(ControllerInput.actions["MousePosition"].ReadValue<Vector2>());
         RaycastHit hit;


         if (Physics.Raycast(ray, out hit, 100))
         {
             Gizmos.color = Color.magenta;
             //  Debug.Log("hit");
         }
         Gizmos.DrawRay(ray);
     }*/


}
