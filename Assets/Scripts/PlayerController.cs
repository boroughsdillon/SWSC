using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody))]
public class PlayerController : MonoBehaviour
{
    Vector3 velocity;
    Rigidbody myRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        //defines the rigidbody that will be used
        myRigidBody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 _velocity)
    {
        //sets the delivered moveSpeed from the player script
        velocity = _velocity;
    }

    public void LookAt (Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(heightCorrectedPoint);
    }

    public void FixedUpdate()
    {
        //moves the character, where and how fast
        myRigidBody.MovePosition(myRigidBody.position + velocity * Time.fixedDeltaTime);
    }
}
