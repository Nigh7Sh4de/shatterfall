using UnityEngine;
using System.Collections.Generic;

public class player : MonoBehaviour
{

    public GameObject floor;
    public GameObject orb;
    orb _orb;
    public bool Active = true;


	//player direction
	public float mouseX1;
	public float mouseY1;
	public float mouseX2;
	public float mouseY2;
	public float mouseOffsetX;
	public float mouseOffsetY;
	public float direction;

    private Vector3 knockback = Vector3.zero;
    private int knockback_counter = 0;
    new Rigidbody rigidbody;
    float MOVE_SPEED = 5f;
    int TURN_SPEED = 1000;
    //turnForceScale;
    Collider thisCollider, floorCollider;
    List<Collider> collisions = new List<Collider>();
	new Animation armsUp;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.layer == 8)
        {
            var p = col.gameObject.GetComponent<player>();
            if (p != null)
            {
                p.Push(col.impulse);
                return;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (collisions.Find(o => o.GetInstanceID() == other.GetInstanceID()) == null)
            collisions.Add(other);
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("LEFT:" + other.name);
        if (!collisions.Remove(other)) ;
            //Debug.LogError("HOLY FLYING FUCK KILL YOURSELF!");
    }

    public void Die()
    {
        _orb.Die();
        Destroy(gameObject);
    }

    public void Push(Vector3 force)
    {
        knockback_counter = 1;
        knockback = force.normalized * 8;
    }

    // Use this for initialization
    void Start()
    {
        //turnForceScale = 1;
		armsUp = GetComponent<Animation> ();

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

        if (this.Active)
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
				armsUp["Arms_Up2"].speed = 4.5f;
				armsUp.Play("Arms_Up2");
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

            if (Mathf.Abs(mouseOffsetX) > 2 || Mathf.Abs(mouseOffsetY) > 2)
            {
                direction = -Mathf.Atan2(mouseOffsetY, mouseOffsetX) * (180 / Mathf.PI);
            }
            if (direction < 0)
            {
                direction = 360 - Mathf.Abs(direction);
            }

            var curDirection = (int)gameObject.transform.eulerAngles.y;
            var tarDirection = (int)direction;

            if (curDirection != tarDirection)
            {
                mouseX1 = mouseX2;
                mouseY1 = mouseY2;

                var delta = 0;
                if (tarDirection - curDirection < -180)
                    delta = 1;
                else if (tarDirection - curDirection < 0)
                    delta = -1;
                else if (tarDirection - curDirection < 180)
                    delta = 1;
                else
                    delta = -1;

                var angle = Time.deltaTime * TURN_SPEED * delta;

                if (Mathf.Abs(tarDirection - curDirection) < 15)
                    gameObject.transform.eulerAngles = new Vector3(0, tarDirection, 0);
                else
                    gameObject.transform.eulerAngles = new Vector3(0, curDirection + angle, 0);
            }
            else
                rigidbody.angularVelocity = Vector3.zero;

        }

        if (knockback_counter-- > 0)
            rigidbody.velocity += knockback;

        var s = "";
        collisions.ForEach(c => s += c.name);

        //Debug.Log(collisions.Count + ":::" + s);

        if (collisions.Count < 1 && transform.position.y < 0.511)
        {
            Physics.IgnoreCollision(thisCollider, floorCollider, true);
        }
    }
}
