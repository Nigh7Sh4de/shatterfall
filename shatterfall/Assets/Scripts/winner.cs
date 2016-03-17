using UnityEngine;
using System.Collections;

public class winner : MonoBehaviour {
	
	public float amplitudeY = 0.24f;
	public float omegaY = 5.0f;
	float xPos;
	public static int winnerNumber;
	public float indexPos;
	public float indexRot;
	Material material;


	public Material[] PlayerMaterial = new Material[4];

	// Use this for initialization
	void Start () {
		Debug.Log (main.WinnerName);
		if(string.Compare(main.WinnerName, "Player1") == 0) 
			winnerNumber = 1;
		else if(string.Compare(main.WinnerName, "Player2") == 0) 
			winnerNumber = 2;
		else if(string.Compare(main.WinnerName, "Player3") == 0) 
			winnerNumber = 3;
		else if(string.Compare(main.WinnerName, "Player4") == 0) 
			winnerNumber = 4;

		xPos = transform.position.x;
		material = PlayerMaterial[winnerNumber - 1];
		var renderers = GetComponentsInChildren<Renderer>();
		foreach (var r in renderers)
			r.material = material;

		setWinnerNum ();
	}

	void setWinnerNum(){
		selector2.winner = winnerNumber;
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
