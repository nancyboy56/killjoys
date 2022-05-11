using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RevisistedMovement : MonoBehaviour
{

    private PlayerInput ControllerInput;
    [SerializeField]
    private float speed;
    private Rigidbody rb;
    private Vector3 input;
    [SerializeField]
    //private Transform playerCube;
    // Start is called before the first frame update
    void Start()
    {
        ControllerInput = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody>();
        speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = ControllerInput.actions["Movement"].ReadValue<Vector2>();
        input = new Vector3(move.x, 0, move.y);
        Look();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Look()
    {
        if(input!= Vector3.zero)
        {
            var relative = (transform.position + input) - transform.position;
            var rotation = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = rotation;
        }
        
    }

    private void Move()
    {
        rb.MovePosition(transform.position + (transform.forward * input.magnitude * speed * Time.deltaTime));
    }
}
