using UnityEngine;
using System.Collections;

public class player : MonoBehaviour
{

    public GameObject floor;
    public GameObject orb;
    orb _orb;

    Rigidbody rigidbody;
    float moveForceScale, turnForceScale;
    int triggerCount = 0;
    Collider thisCollider, floorCollider;

    void OnTriggerEnter(Collider other)
    {
<<<<<<< HEAD
        triggerCount++;

        //Debug.Log(triggerCount);
=======
        //Debug.Log(triggerCount++);
>>>>>>> 2ec30d7f59c83e0c5706f3d50d60397c4d2a1b7e
    }

    void OnTriggerExit(Collider other)
    {
<<<<<<< HEAD
        triggerCount--;
        //Debug.Log(triggerCount);
=======
        //Debug.Log(triggerCount--);
>>>>>>> 2ec30d7f59c83e0c5706f3d50d60397c4d2a1b7e

        if (triggerCount <= 1)
        {
            Physics.IgnoreCollision(thisCollider, floorCollider);
        }
    }

    // Use this for initialization
    void Start()
    {
        moveForceScale = 2f;
        turnForceScale = 1;

        rigidbody = GetComponent<Rigidbody>();

        thisCollider = GetComponent<BoxCollider>();
        floorCollider = main.GetFloor().GetComponent<BoxCollider>();

        var clone = Instantiate(orb);
        clone.SetActive(false);
        _orb = clone.GetComponent<orb>();
    }

    // Update is called once per frame
    void Update()
    {

        var x = 0;
        var y = rigidbody.velocity.y / moveForceScale;
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
            rigidbody.velocity = new Vector3(x, y, z) * moveForceScale;

        if (Input.GetMouseButtonDown(0))
        {
            _orb.Activate(transform.position + new Vector3(0, 1, 0), transform.rotation);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _orb.Explode();
        }
        


    }
}
