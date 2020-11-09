using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    // get ref to rigit body
    Rigidbody rigidbody;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        // rigidbody.mass = 0.1;
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput(){
        if (Input.GetKey(KeyCode.Space)) {
            // print("thrust");
            // need to access rigid body component
            rigidbody.AddRelativeForce(Vector3.up);
        } 
        
        if (Input.GetKey(KeyCode.A)) {
            // print("left");
            rigidbody.AddRelativeForce(Vector3.left)
        } else if (Input.GetKey(KeyCode.D)){
            // print("right");

            rigidbody.AddRelativeForce(Vector3.right)
        }
    }
}
