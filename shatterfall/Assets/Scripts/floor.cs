using UnityEngine;
using System.Collections;

public class floor : MonoBehaviour {

    public Material OriginalMaterial;
    //public Material HighlightedMaterial;

    new Rigidbody rigidbody;
    new Renderer renderer;

	private AudioSource source;
	public AudioClip shatterSound;
	public AudioClip glassSound;
	private float pitchLowRange = 1f;
	private float pitchHighRange = 1.1f;

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
		float pitch = Random.Range (pitchLowRange, pitchHighRange);
		float vol = Random.Range (0.1f, 0.2f);
		source.volume = vol;
		source.pitch = pitch;
		source.PlayOneShot(shatterSound,pitch);
		source.PlayOneShot(glassSound, pitch);

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
		source = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (transform.position.y > 0)
            transform.position = new Vector3(transform.position.x * 1, transform.position.y - 1, transform.position.z * 1);


        else if (transform.position.y < -200)
            Die();
    }
}
