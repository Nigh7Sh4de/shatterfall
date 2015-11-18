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

        var x = 0;
        var z = 0;

        if (Input.GetKey(KeyCode.W))
            z = 1;
        else if (Input.GetKey(KeyCode.S))
            z = -1;
        if (Input.GetKey(KeyCode.A))
            x = -1;
        else if (Input.GetKey(KeyCode.D))
            x = 1;

        if (x != 0 || z != 0)
            rigidbody.velocity = new Vector3(x, 0, z) * moveForceScale;

    }
}
