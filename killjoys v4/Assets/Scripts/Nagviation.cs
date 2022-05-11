using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nagviation : MonoBehaviour
{

    private Transform lastRoom;
    private RoomVisibility lastVisbility;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
      /*  int layerMask = 1 << 7;


        //the debug ray doesnt seem to work
        Vector3 down = new Vector3(0, -1, 0);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, down, out hit, 10, layerMask))
        {
            print("hit ground");
            if (!hit.Equals(lastRoom))
            {
                print("enter room: " + hit.transform.parent.name);
                if (lastVisbility != null)
                {
                    print("leave room: " + lastRoom.transform.parent.name);
                    lastVisbility.LeaveRoom();
                    lastVisbility = null;

                }
                RoomVisibility visibility;
                if (hit.transform.parent.gameObject.TryGetComponent<RoomVisibility>(out visibility))
                {
                    visibility.EnterRoom();
                    lastRoom = hit;
                    lastVisbility = visibility;
                }
            }

        }
        else
        {
            print("no");
        }*/
    }

    private void OnTriggerEnter(Collider c)
    {
        print("On Collision Enter");
        if (c.tag.Equals("RoomTrigger"))
        {
            RoomVisibility visibility;
            if (c.transform.parent.gameObject.TryGetComponent<RoomVisibility>(out visibility))
            {
                visibility.EnterRoom();
                lastVisbility = visibility;
                lastRoom = c.transform.parent;
            }
        }
        
    }

    private void OnTriggerExit(Collider c)
    {
        print("On Collision Exit");
        print("On Collision Exit");

        if (c.tag.Equals("RoomTrigger"))
        {
            int layerMask = 1 << 7;


            //the debug ray doesnt seem to work
            Vector3 down = new Vector3(0, -1, 0);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, down, out hit, 10, layerMask))
            {

                if (hit.transform.parent == null ||  !(hit.transform.parent.Equals( lastRoom)))
                {
                    print("Leave Room");
                    lastVisbility.LeaveRoom();
                }
            }
            else
            {
                print("No Ground Layer");
            }
        }
    }
}
