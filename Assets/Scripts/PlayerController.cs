using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float movementSpeed;
    [SerializeField] public float rotateSpeed;
    Rigidbody rb;

    public Transform player;

    void FixedUpdate()
    {
        GetInput();
        MaxSpeedControl();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void GetInput()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * movementSpeed * 5f);
        }   
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-transform.forward * movementSpeed * 5f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            player.Rotate(-rotateSpeed * new Vector3(0, 1, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.Rotate(rotateSpeed * new Vector3(0, 1, 0));
        }
    }

    private void MaxSpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if(flatVelocity.magnitude > movementSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * movementSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }
}
