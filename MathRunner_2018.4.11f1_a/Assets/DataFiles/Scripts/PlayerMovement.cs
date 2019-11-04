using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpRayCastDistance;

    //we can use get rgid body but rather we use cache system
    //because if it is refernce then per frame update is ok  but if it is value type then 
    //
    //for the cache
    //______________________________________________________________________________________________
    private Rigidbody rb;

    private void Start()        //this at first frame
    {
        rb = GetComponent<Rigidbody>();//state have been saved here
    }
    //_______________________________________________________________________________________________
    private void Update()       //this at every frame
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded())
            {
                rb.AddForce(0, jumpForce, 0, ForceMode.Impulse);
            }
        }
    }

    private bool isGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * jumpRayCastDistance, Color.blue);//just to show in debug
        return Physics.Raycast(transform.position, Vector3.down, jumpRayCastDistance);
    }

    //________________________________________________________________________________________________
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");

        var movement = new Vector3(hAxis, 0, vAxis) * speed * Time.fixedDeltaTime;
        var newPosition = rb.position + rb.transform.TransformDirection(movement);//transforms direction 
        rb.MovePosition(newPosition);
    }
}