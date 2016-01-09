using UnityEngine;
using System.Collections;

public class orb : MonoBehaviour {

    Rigidbody rigidbody;

    const int SPEED = 500;
    ArrayList collisions;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();
        collisions = new ArrayList();
    }

    void OnTriggerEnter(Collider other)
    {
        collisions.Add(other.GetComponent<floor>());

        //Debug.Log("orb->" + other.name + " " + collisions.Count);
    }

    void OnTriggerExit(Collider other)
    {
        collisions.Remove(other.GetComponent<floor>());

        Debug.Log("orb->" + other.name + " " + collisions.Count);


    }

    public void Explode()
    {

        foreach (floor other in collisions)
        {
            if (other != null)
                other.Drop();
        }


        gameObject.SetActive(false);
    }

    public void Activate(Vector3 position, Quaternion rotation)
    {
        collisions = new ArrayList();
        transform.position = position;
        transform.rotation = rotation;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update ()
    {
        var angle = Mathf.Deg2Rad * (transform.rotation.eulerAngles.y + 90);
        rigidbody.velocity = new Vector3(Mathf.Sin(angle) * SPEED * Time.deltaTime, 0, SPEED * Time.deltaTime * Mathf.Cos(angle));

    }
}
