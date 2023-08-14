using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    public float speed;
    public KeyCode up;
    public KeyCode down;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool pressedUp = Input.GetKey(up);
        bool pressedDown = Input.GetKey(down);

        if (pressedUp)
        {
            rb.velocity = Vector3.forward * speed;
        }
        else if (pressedDown)  // Use "else if" here to avoid conflicting movement
        {
            rb.velocity = Vector3.back * speed;
        }
        else
        {
            rb.velocity = Vector3.zero;  // Stop the object's movement
        }
    }
}