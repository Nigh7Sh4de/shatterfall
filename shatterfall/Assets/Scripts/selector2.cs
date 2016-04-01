using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class selector2 : MonoBehaviour {
	
	public static int option;
	public List<GameObject> uiChoices;
	public Text PlayerWin;
	public static int winner;

	public AudioClip selectSound;
	private AudioSource source;
	
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		option = 0;
		transform.localScale = uiChoices [0].transform.localScale * 9f;
	}
	
	bool ready;
	
	// Update is called once per frame
	void Update () {

		PlayerWin.text = "P L A Y E R   " + winner + "   W I N S !";
		if (Input.GetAxis("MoveVertical1") == 0)
			ready = true;
		
		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetAxis("MoveVertical1") > 0 && ready) {
			source.PlayOneShot (selectSound, 1F);
			ready = false;
			if (option == 0) {
				option = uiChoices.Count - 1;
			} else {
				option--;
			}
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetAxis("MoveVertical1") < 0 && ready) {
			source.PlayOneShot (selectSound, 1F);
			ready = false;
			if (option == uiChoices.Count - 1) {
				option = 0;
			} else {
				option++;
			}
		}
		
		transform.position = uiChoices[option].transform.position + new Vector3(-uiChoices[option].transform.localScale.x * 0.55f, uiChoices[option].transform.localScale.x * 0.2f, 0);
		
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetAxis("Jump1") > 0) {
			if(option == 0){
				source.PlayOneShot (selectSound, 1F);
				Application.LoadLevel ("main");
			}
			else {
				source.PlayOneShot (selectSound, 1F);
				Application.LoadLevel ("MainMenu");
			}
		}
	}
}