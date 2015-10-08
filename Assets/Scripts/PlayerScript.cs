using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private Rigidbody rb;
    private float MUL = 500;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.W))
        {
            var v3 = Vector3.one;
            v3.Scale(new Vector3(0, 0, MUL));
            rb.AddRelativeForce(v3);
        }
	}
}
