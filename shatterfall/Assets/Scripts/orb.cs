using UnityEngine;
using System.Collections.Generic;

public class orb : MonoBehaviour {

    Rigidbody rigidbody;
    SphereCollider collider;

    List<floor> collisions;
    private int exploding = 0;

    private const int SPEED = 1000;
    private const int EXPLODE_DURATION = 20;
    private const float EXPLODE_RATE = 0.05f;

    // Use this for initialization
    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
        collider = GetComponent<SphereCollider>();
        collisions = new List<floor>();
    }

    void OnTriggerEnter(Collider other)
    {
        collisions.Add(other.GetComponent<floor>());

        //Debug.Log("orb->" + other.name + " " + collisions.Count);
    }

    void OnTriggerExit(Collider other)
    {
        collisions.Remove(other.GetComponent<floor>());

        //Debug.Log("orb->" + other.name + " " + collisions.Count);

    }

    public void Explode()
    {

        while (collisions.Count > 0)
        {
            var other = collisions[0];
            if (other != null)
                other.Drop();
            collisions.Remove(other);
        }
        exploding++;


    }

    public void Activate(Vector3 position, Quaternion rotation)
    {
        collisions = new List<floor>();
        transform.position = position;
        transform.rotation = rotation;
        Reset();
        gameObject.SetActive(true);
    }

    void Reset()
    {
        exploding = 0;
        collider.radius = 0.2f;

    }

    // Update is called once per frame
    void Update ()
    {
        if (exploding > EXPLODE_DURATION)
        {
            Explode();
            Reset();
            gameObject.SetActive(false);
        }
        else if (exploding > 0)
        {
            collider.radius += EXPLODE_RATE;
            Explode();
            rigidbody.velocity = Vector3.zero;
        }
        else
        {
            var angle = Mathf.Deg2Rad * (transform.rotation.eulerAngles.y + 90);
            rigidbody.velocity = new Vector3(Mathf.Sin(angle) * SPEED * Time.deltaTime, 0, SPEED * Time.deltaTime * Mathf.Cos(angle));
        }
    }
}
