using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{

    private Rigidbody2D rb;
    private float speed;

    private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        speed = GameManager.Instance.speed;
    }

    void Update()
    {

        // this could be diffeent now since im watching a tutorial from 2019
        // if it acts werid search again
        movement.x= Input.GetAxisRaw("Horizontal");
        movement.y= Input.GetAxisRaw("Vertical");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.Instance.state.Equals(GameStates.Exploring))
        {
            rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
        }
        else
        {
            rb.velocity= Vector2.zero;
        }
        

       


    }


}
