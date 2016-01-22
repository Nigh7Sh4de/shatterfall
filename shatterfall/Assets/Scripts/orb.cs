using UnityEngine;
using System.Collections.Generic;

public class orb : MonoBehaviour {

    new Rigidbody rigidbody;
    Vector3 velocity;
    Quaternion direction;

    private int exploding = 0;

    private const int SPEED = 1000;
    private const int EXPLODE_DURATION = 60;
    private const int EXPLODE_RATE = 1000;

    void Awake() {
        rigidbody = GetComponent<Rigidbody>();
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

    void OnTriggerExit(Collider other)
    {
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
        else
        {
            rigidbody.velocity = velocity * Time.deltaTime;
            rigidbody.angularVelocity = Vector3.zero;
        }
    }
}
