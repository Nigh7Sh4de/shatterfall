using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    public GameObject floor;

    Rigidbody rigidbody;
    float moveForceScale, turnForceScale;
    int triggerCount = 0;
    Collider thisCollider, floorCollider;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(triggerCount++);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log(triggerCount--);

        if (triggerCount <= 1)
        {
            Physics.IgnoreCollision(thisCollider, floorCollider);
        }
    }

    // Use this for initialization
    void Start () {
        moveForceScale = 2f;
        turnForceScale = 1;

        rigidbody = GetComponent<Rigidbody>();

        thisCollider = GetComponent<BoxCollider>();
        floorCollider = main.GetFloor().GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update () {

        
        if (Input.GetKey(KeyCode.W))
        {
            var x = new Vector3(0, 0, 1) * moveForceScale;
            //rigidbody.AddForce(x, ForceMode.VelocityChange);
            rigidbody.velocity = x;
        }
        if (Input.GetKey(KeyCode.S))
        {
            var x = new Vector3(0, 0, -1) * moveForceScale;
            //rigidbody.AddForce(x, ForceMode.VelocityChange);
            rigidbody.velocity = x;
        }
        if (Input.GetKey(KeyCode.A))
        {
            var x = new Vector3(-1, 0, 0) * moveForceScale;
            //rigidbody.AddForce(x, ForceMode.VelocityChange);
            rigidbody.velocity = x;
        }
        if (Input.GetKey(KeyCode.D))
        {
            var x = new Vector3(1, 0, 0) * moveForceScale;
            //rigidbody.AddForce(x, ForceMode.VelocityChange);
            rigidbody.velocity = x;
        }


    }
}
