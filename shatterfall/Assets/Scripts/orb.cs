using UnityEngine;
using System.Collections.Generic;
using System;

public class orb : MonoBehaviour {

    new Rigidbody rigidbody;
    Vector3 velocity;
    Quaternion direction;
    Material HighlightMaterial;

    private int exploding = 0;

    private const int SPEED = 500;
    private const int EXPLODE_DURATION = 10;
    private const int EXPLODE_RATE = 1000;

    public void SetHighlightMaterial(Material material)
    {
        HighlightMaterial = material;
    }

    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerExit(Collider other)
    {
        var floor = other.GetComponent<floor>();
        if (floor != null)
            floor.UnHighlight();
    }

    void OnTriggerEnter(Collider other)
    {
        var floor = other.GetComponent<floor>();
        if (floor != null)
            floor.Highlight(HighlightMaterial);
    }

    void OnTriggerStay(Collider other)
    {
        if (exploding > 0)
        {
            floor floor = null;
            if ((floor = other.GetComponent<floor>()) != null)
                floor.Drop();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Explode()
    {
        exploding++;
        rigidbody.velocity = Vector3.zero;
    }

    public void Activate(Vector3 position, Quaternion rotation)
    {
        Reset();
        position.y = 2.51f;
        transform.position = position;
        transform.rotation = direction = rotation;
        gameObject.SetActive(true);
        var angle = Mathf.Deg2Rad * (transform.rotation.eulerAngles.y + 90);
        velocity = new Vector3(Mathf.Sin(angle) * SPEED, 0, SPEED * Mathf.Cos(angle));
    }

    void Reset()
    {
        exploding = 0;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
        gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update ()
    {
        if (exploding > EXPLODE_DURATION)
        {
            Reset();
        }
        else if (exploding > 0)
        {
            rigidbody.velocity = Vector3.down * Time.deltaTime * EXPLODE_RATE;
            exploding++;
        }
        else if (OutOfBounds())
        {
            Reset();
        }
        else
        {
            rigidbody.velocity = velocity * Time.deltaTime;
            rigidbody.angularVelocity = Vector3.zero;
        }
    }

    private bool OutOfBounds()
    {
        return (
                transform.position.x < -2 ||
                transform.position.x > 35 ||
                transform.position.z < -17 ||
                transform.position.z > 17
            );
    }
}
