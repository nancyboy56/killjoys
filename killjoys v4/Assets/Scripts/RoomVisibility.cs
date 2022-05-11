using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomVisibility : MonoBehaviour
{
    private GameObject topLeft;
    private GameObject topRight;
    private GameObject bottomLeft;
    private GameObject bottomRight;
    private GameObject ground;
    private GameObject roomTrigger;
    private List<GameObject> childern = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            childern.Add(child.gameObject);
            if (child.tag.Equals("Ground"))
            {
                ground = child.gameObject;
            }
            else if (child.tag.Equals("TopLeft"))
            {
                topLeft = child.gameObject;
            }
            else if (child.tag.Equals("TopRight"))
            {
                topRight = child.gameObject;
            }
            else if (child.tag.Equals("BottomRight"))
            {
                bottomRight = child.gameObject;
            }
            else if (child.tag.Equals("BottomLeft"))
            {
                bottomLeft = child.gameObject;
            }
            else if (child.tag.Equals("RoomTrigger"))
            {
                roomTrigger = child.gameObject;
            }
            child.gameObject.SetActive(false);
        }

        bottomRight.SetActive(true);
        bottomLeft.SetActive(true);
        roomTrigger.SetActive(true);
    }

    public void LeaveRoom()
    {
        foreach( GameObject child in childern)
        {
            child.SetActive(false);
        }

        bottomRight.SetActive(true);
        bottomLeft.SetActive(true);
        roomTrigger.SetActive(true);
    }

    public void EnterRoom()
    {
        foreach (GameObject child in childern)
        {
            child.SetActive(true);
        }

        bottomRight.SetActive(false);
        bottomLeft.SetActive(false);
        roomTrigger.SetActive(true);
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
