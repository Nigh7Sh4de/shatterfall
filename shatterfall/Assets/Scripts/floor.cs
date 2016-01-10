using UnityEngine;
using System.Collections;

public class floor : MonoBehaviour {

    Rigidbody rigidbody;
    BoxCollider collider;

    public void Drop()
    {
        rigidbody.isKinematic = false;
    }

	// Use this for initialization
	void Start () {
        rigidbody = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
