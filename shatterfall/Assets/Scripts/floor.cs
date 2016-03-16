using UnityEngine;
using System.Collections;

public class floor : MonoBehaviour {

    public Material OriginalMaterial;
    //public Material HighlightedMaterial;

    Rigidbody rigidbody;
    BoxCollider collider;
    Renderer renderer;

    public void Highlight(Material material)
    {
        renderer.material = material;
    }

    public void UnHighlight()
    {
        renderer.material = OriginalMaterial;
    }

    public void Drop()
    {
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
        //collider.isTrigger = false;
        //gameObject.layer = 12;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        collider = gameObject.GetComponent<BoxCollider>();
        renderer = gameObject.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y > 0)
            transform.position = new Vector3(transform.position.x * 1, transform.position.y - 1, transform.position.z * 1);


    }
}
