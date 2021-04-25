using System.Collections;
using System.Collections.Generic;


using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 player = GameManager.Instance.GetPlayers()["Party_Poison"].transform.position;
        Vector3 camera = new Vector3(player.x, player.y- 3, -5);
        transform.position = camera;
        
    }

    
}
