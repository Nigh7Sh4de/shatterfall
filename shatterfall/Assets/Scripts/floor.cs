using UnityEngine;
using System.Collections;

public class floor : MonoBehaviour {

    public Material OriginalMaterial;
    //public Material HighlightedMaterial;

    new Rigidbody rigidbody;
    new Renderer renderer;

    public void Highlight(Material material)
    {
        renderer.material = material;
    }

    public void UnHighlight()
    {
        renderer.material = OriginalMaterial;
    }

    public void Drop(bool end = false)
    {
        if (end)
        {
            rigidbody.velocity = new Vector3(Random.value, -2 * Random.value, Random.value) * 2;
            rigidbody.angularVelocity = new Vector3(Random.value, Random.value, Random.value) * 45 * Time.deltaTime;
        }
        rigidbody.isKinematic = false;
        rigidbody.useGravity = true;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

	// Use this for initialization
	void Start () {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        renderer = gameObject.GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y > 0)
            transform.position = new Vector3(transform.position.x * 1, transform.position.y - 1, transform.position.z * 1);


        else if (transform.position.y < -200)
            Die();
    }
}
