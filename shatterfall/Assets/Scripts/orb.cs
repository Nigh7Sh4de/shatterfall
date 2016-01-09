using UnityEngine;
using System.Collections;

public class orb : MonoBehaviour {

    Rigidbody rigidbody;

    const int SPEED = 500;

    // Use this for initialization
    void Start () {
        rigidbody = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update ()
    {
        var angle = Mathf.Deg2Rad * (transform.rotation.eulerAngles.y + 90);
        rigidbody.velocity = new Vector3(Mathf.Sin(angle) * SPEED * Time.deltaTime, 0, SPEED * Time.deltaTime * Mathf.Cos(angle));

    }
}
