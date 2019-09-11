using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 1500;
    public float rotationSpeed = 15;

    public WheelJoint2D backWheel;
    public WheelJoint2D frontWheel;

    public Rigidbody2D rb;

    private float movement = 0f;
    private float rotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement = -Input.GetAxisRaw("Vertical") * speed; // - as negative value = forward
        rotation = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (movement == 0f)
        {
            backWheel.useMotor = false;
            frontWheel.useMotor = false;
        }
        else {
            backWheel.useMotor = true;
            frontWheel.useMotor = true;
            JointMotor2D motor = new JointMotor2D { motorSpeed = movement, maxMotorTorque = backWheel.motor.maxMotorTorque };
            backWheel.motor = motor;
            frontWheel.motor = motor;
        }

        rb.AddTorque(-rotation * rotationSpeed * Time.fixedDeltaTime);

    }
}
