using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
    public float moveHorizontal;
    public float moveVertical;

    private Rigidbody rb;
    public float speed;
    public float tilt;
    public Boundary boundary;

    // models
    public GameObject[] models;

    // Ship face mouse function
    public Transform CharacterTransform;
    public float RotationSmoothingCoef;

    // Abilities
    private float maxSpeed;
    public float boostSpeed;
    private Vector3 mousePos;
    private Vector3 mouseDir;

    [SerializeField]
    private ParticleSystem jetCore;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update() // once a frame
    {
        BoostAbility(boostSpeed);
    }
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        faceMouse();
        followMouse();
        Boundary();
        
    }
    public void Boundary()
    {
        rb.position = new Vector3
        (
            Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)
        );
    }
    public void faceMouse() // I basically have zero idea what this code does
    {
        var groundPlane = new Plane(Vector3.up, -CharacterTransform.position.y);
        var mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDistance;

        if (groundPlane.Raycast(mouseRay, out hitDistance))
        {
            var lookAtPosition = mouseRay.GetPoint(hitDistance);
            Debug.DrawLine(mouseRay.origin, lookAtPosition);
            var targetRotation = Quaternion.LookRotation(lookAtPosition - CharacterTransform.position, Vector3.up);
            var rotation = Quaternion.Lerp(CharacterTransform.rotation, targetRotation, RotationSmoothingCoef);
            rotation.z = rb.velocity.x * -tilt;
            CharacterTransform.rotation = rotation;
        }
    }
    public void BoostAbility(float boostSpeed)
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += boostSpeed;
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= boostSpeed;
        }
    }
    public void followMouse()
    {
        if (moveVertical > 0.0)
        {
            jetCore.Play();
            //Move the Rigidbody forwards constantly at speed you define (the blue arrow axis in Scene view)
            rb.AddForce(transform.forward * speed);
        }
        if (moveVertical < 0.0)
        {
            jetCore.Play();
            //Move the Rigidbody backwards constantly at the speed you define (the blue arrow axis in Scene view)
            rb.AddForce(-transform.forward * speed);
        }
        if (moveHorizontal > 0.0)
        {
            jetCore.Play();
            rb.AddForce(transform.right * speed);
            //Rotate the sprite about the Y axis in the positive direction
            //transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * speed, Space.World);
        }
        if (moveHorizontal < 0.0)
        {
            jetCore.Play();
            rb.AddForce(-transform.right * speed);
            //Rotate the sprite about the Y axis in the negative direction
            //transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * speed, Space.World);
        }
        if (moveHorizontal == 0.0 && moveVertical == 0)
        {
            jetCore.Stop();
        }
    }
}
