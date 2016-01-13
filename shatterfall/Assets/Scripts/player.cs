using UnityEngine;
using System.Collections.Generic;

public class player : MonoBehaviour
{

    public GameObject floor;
    public GameObject orb;
    orb _orb;

    new Rigidbody rigidbody;
    float MOVE_SPEED = 5f;
    //turnForceScale;
    Collider thisCollider, floorCollider;
    List<Collider> collisions = new List<Collider>();
    
    void OnTriggerEnter(Collider other)
    {
        if (collisions.Find(o => o.GetInstanceID() == other.GetInstanceID()) == null)
            collisions.Add(other);

        Debug.Log(collisions.Count);
    }

    void OnTriggerExit(Collider other)
    {

        collisions.Remove(other);

        Debug.Log(collisions.Count);

        if (collisions.Count <= 1)
        {
            Physics.IgnoreCollision(thisCollider, floorCollider);
        }
    }

    // Use this for initialization
    void Start()
    {
        //turnForceScale = 1;

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

        var x = 0f;
        var y = rigidbody.velocity.y / MOVE_SPEED;
        var z = 0f;

        if (Input.GetKey(KeyCode.W))
            z = 1;
        else if (Input.GetKey(KeyCode.S))
            z = -1;
        if (Input.GetKey(KeyCode.A))
            x = -1;
        else if (Input.GetKey(KeyCode.D))
            x = 1;

        if (x != 0 && z != 0)
        {
            x *= 0.707f;
            z *= 0.707f;
        }

        rigidbody.velocity = new Vector3(x, y, z) * MOVE_SPEED;

        if (Input.GetMouseButtonDown(0))
        {
            _orb.Activate(transform.position + new Vector3(0, 2, 0), transform.rotation);
        }

        if (Input.GetMouseButtonUp(0))
        {
            _orb.Explode();
        }
        


    }
}
