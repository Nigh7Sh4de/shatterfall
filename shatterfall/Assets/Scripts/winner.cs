using UnityEngine;
using System.Collections;

public class winner : MonoBehaviour {
	
	public float amplitudeY = 0.24f;
	public float omegaY = 5.0f;
	float xPos;
	public float indexPos;
	public float indexRot;
	Material material;
	public Material[] PlayerMaterial = new Material[4];

	// Use this for initialization
	void Start () {
		xPos = transform.position.x;
		material = PlayerMaterial[0];
		var renderers = GetComponentsInChildren<Renderer>();
		foreach (var r in renderers)
			r.material = material;
	}
	
	// Update is called once per frame
	void Update () {
		indexPos += Time.deltaTime;
		float yPos = amplitudeY*Mathf.Sin (omegaY*indexPos);
		transform.position = new Vector3(xPos,yPos-3.74f,0);

		indexRot += Time.deltaTime * 0.5f;
		float yRot = amplitudeY*Mathf.Sin (omegaY*indexRot);
		transform.eulerAngles = new Vector3(0,yRot * 150f + 90,0);
	}
}
