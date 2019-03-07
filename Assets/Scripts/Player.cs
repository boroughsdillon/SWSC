using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveSpeed = 5;
    Camera viewCamera;
    PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        //defines the controller script
        controller = GetComponent<PlayerController>();
        //defines the camera
        viewCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetAxis: "Horizontal" and "Vertical" are mapped to joystick, A, W, S, D and the arrow keys, what keys are being pushed for a direction
        Vector3 moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //Debug.Log("Direction: " + moveInput);
        //Vectors have a direction and magnitude (distance), normalized sets the magnitude to 1.0, so the character is moving at moveSpeed in the direction of the keys
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        //Debug.Log("Velocity: " + moveVelocity);
        //calls the controller script and gives it a speed and direction vector
        controller.Move(moveVelocity);

        //moving character to face mouse
        Ray ray = viewCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        if (groundPlane.Raycast(ray,out rayDistance))
        {
            Vector3 point = ray.GetPoint(rayDistance);
            //Debug.DrawLine(ray.origin, point, Color.red);
            controller.LookAt(point);
        }
    }
}
