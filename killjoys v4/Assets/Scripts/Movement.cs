using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    // private InputController ControllerInput;
    private PlayerInput ControllerInput;
    [SerializeField]
    private float speed;
    private Rigidbody rb;

    [SerializeField]
    // so diagoonse arent faster
    private float moveLimiter = 0.8f;
    // Start is called before the first frame update
    void Start()
    {
        //ControllerInput = gameObject.GetOrAddComponent<InputController>();
        ControllerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 move = ControllerInput.actions["Movement"].ReadValue<Vector2>();


        if (move.x != 0 && move.y != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            move.x *= moveLimiter;
            move.y *= moveLimiter;
        }

        rb.velocity = new Vector3(move.y * speed, 0, - (move.x * speed) );
    }
}
