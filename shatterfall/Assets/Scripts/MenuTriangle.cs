using UnityEngine;
using System.Collections;

public class MenuTriangle : MonoBehaviour {

	public float xPosition;
	public float zPosition;

	public float positionChange;
	public float angleChange;



	// Use this for initialization
	void Start () {
		xPosition = transform.position.x;
		zPosition = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponent<Renderer>().isVisible == false && transform.position.y < -4) {
			transform.position = new Vector3 (xPosition, 7.5f, zPosition);
		}

		float xNewPos = transform.position.x + positionChange;
		float yNewPos = transform.position.y;
		float zNewPos = transform.position.z + positionChange;
		transform.position = new Vector3 (xNewPos, yNewPos, zNewPos);

		transform.Rotate(new Vector3 (angleChange, angleChange, angleChange));
	}
}
