using UnityEngine;
using System.Collections.Generic;

public class player : MonoBehaviour
{

    public GameObject floor;
    public GameObject orb;
    orb _orb;

	//player direction
	public float mouseX1;
	public float mouseY1;
	public float mouseX2;
	public float mouseY2;
	public float mouseOffsetX;
	public float mouseOffsetY;
	public float direction;
	
    new Rigidbody rigidbody;
    float MOVE_SPEED = 5f;
    //turnForceScale;
    Collider thisCollider, floorCollider;
    List<Collider> collisions = new List<Collider>();
    
    void OnTriggerEnter(Collider other)
    {
        if (collisions.Find(o => o.GetInstanceID() == other.GetInstanceID()) == null)
            collisions.Add(other);
    }

    void OnTriggerExit(Collider other)
    {
        collisions.Remove(other);
    }

    public void Die()
    {
        _orb.Die();
        Destroy(gameObject);
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

		mouseX1 = Input.mousePosition.x;
		mouseY1 = Input.mousePosition.y;
		Cursor.visible = false;

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

		if (Input.GetKey(KeyCode.Space) && transform.position.y > 0.509 && transform.position.y < 0.519) 
		{
			rigidbody.velocity = Vector3.up * 0;
			rigidbody.velocity += Vector3.up * 5;
		}

		//player direction
		mouseX2 = Input.mousePosition.x;
		mouseY2 = Input.mousePosition.y; 
		mouseOffsetX = mouseX2 - mouseX1;
		mouseOffsetY = mouseY2 - mouseY1;
		
		if (Mathf.Abs (mouseOffsetX) > 5 || Mathf.Abs (mouseOffsetY) > 5) {
			direction = -Mathf.Atan2 (mouseOffsetY, mouseOffsetX) * (180 / Mathf.PI);
		}
		if (direction < 0) {
			direction = 360 - Mathf.Abs (direction);
		}
		//direction = Vector2.Angle (new Vector2 (mouseX2, mouseY2), new Vector2 (mouseX1, mouseY1));
		
		mouseX1 = mouseX2;
		mouseY1 = mouseY2;
		//Debug.Log (direction);
		//Debug.Log (gameObject.transform.eulerAngles.y);
		/*
		float angle = (gameObject.transform.eulerAngles.y - direction) % 360;
		if (angle >= 180) {
			angle = angle - 360; 
		}
		if (angle <= -180) { 
			angle = angle + 360;
		}

		if (Mathf.Abs (angle) > 1) {
			if (angle >= 30) {
				gameObject.transform.eulerAngles = new Vector3 (0, gameObject.transform.eulerAngles.y - 30, 0);
			} 
			else if (angle > 0 && angle < 30) {
				gameObject.transform.eulerAngles = new Vector3 (0, gameObject.transform.eulerAngles.y - Mathf.Abs (angle), 0);
			}
		} */
		gameObject.transform.eulerAngles = new Vector3 (0, direction, 0);

        var s = "";
        collisions.ForEach(c => s += c.name);

		Debug.Log(collisions.Count + ":::" + s);

		if (collisions.Count < 1 && transform.position.y < 0.511)
		{
			Physics.IgnoreCollision(thisCollider, floorCollider, true);
		}
    }
}
