using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InteractObjects : MonoBehaviour
{
    private PlayerInput controllerInput;
    [SerializeField] public Camera objectCamera;
    private RaycastHit lastHit;
    private IInteractable lastHovered;
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
                IInteractable item;

                // this is assume i put the colliders are the children and the 2d sprite as the game object
                //i might change the order
                if(hit.transform.parent.gameObject.TryGetComponent<IInteractable>(out item))
                {
                    item.OnHover();
                    lastHovered = item;
                }

                
            }
            else
            {
               
            }
            lastHit = hit;
            
        }
        else
        {
            UnhighlightLastObject();
           
        }


    }

    public void Click()
    {
        if(lastHovered!=null)
        {
            lastHovered.OnInteract();
        }
    }

    private void UnhighlightLastObject()
    {
        if (lastHovered != null)
        {
            lastHovered.LeaveHover();
            lastHovered = null;
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
