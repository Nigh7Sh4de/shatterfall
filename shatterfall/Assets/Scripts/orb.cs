using UnityEngine;
using System.Collections.Generic;

public class orb : MonoBehaviour {

    Rigidbody rigidbody;
    SphereCollider collider;

    const int SPEED = 500;
    List<floor> collisions;
    private int exploding = 0;

    // Use this for initialization
    void Start () {
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
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update ()
    {
        if (exploding > 20)
        {
            Explode();
            exploding = 0;
            gameObject.SetActive(false);
        }
        else if (exploding > 0)
        {
            collider.radius += 0.025f;
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
