using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepScript : MonoBehaviour
{
    [SerializeField] public float movementSpeed;
    Rigidbody rb;
    private GameObject player;

    public Transform sheep;
    public bool isScared;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        if (isScared)
        {
        RunAway();
        MaxSpeedControl();
        } else
        {
        Walk();
        MaxSpeedControl();
        }
    }

    private void Walk()
    {
        rb.AddForce(transform.forward * movementSpeed);
        if (Random.Range(0, 5) == 0)
        {
            sheep.Rotate(Random.Range(-16f, 16f) * new Vector3(0, 1, 0));
        }
    }

    public void RunAway()
    {
        Vector3 direction = player.transform.position - sheep.position;
        sheep.rotation = Quaternion.LookRotation(-direction, Vector3.up);

        rb.AddForce(transform.forward * movementSpeed * 3f);
        if (Vector3.Distance(sheep.position, player.transform.position) > 4.75f)
        {
            isScared = false;
        }
    }

    private void MaxSpeedControl()
    {
        Vector3 flatVelocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        if (flatVelocity.magnitude > movementSpeed)
        {
            Vector3 limitedVelocity = flatVelocity.normalized * movementSpeed;
            rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            rb.AddForce(-transform.forward * movementSpeed * 10f);
            switch (collision.gameObject.name)
            {
                case "Wall 1":
                    sheep.rotation = Quaternion.Euler(0, -90, 0);
                    break;
                case "Wall 2":
                    sheep.rotation = Quaternion.Euler(0, 90, 0);
                    break;
                case "Wall 3":
                    sheep.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                case "Wall 4":
                    sheep.rotation = Quaternion.Euler(0, 0, 0);
                    break;
            }
            rb.AddForce(-transform.forward * movementSpeed * 10f);
        }
    }
}
