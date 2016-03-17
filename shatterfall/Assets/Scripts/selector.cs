using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class selector : MonoBehaviour {
	
	public static int option;
	public List<GameObject> uiChoices;
	public bool ready;
	public bool selectable;
	public GameObject howToPlay;

    // Use this for initialization
    void Start () {
		option = 0;
		transform.localScale = uiChoices [0].transform.localScale * 9f;
		selectable = true;
		//howToPlay = GameObject.Find ("Shatterfall_HowToPlay");
		howToPlay.SetActive (false);
	}

    
	void toggleInstructions() {
		if (!howToPlay.activeSelf) {
			selectable = false;
			howToPlay.SetActive(true);
		} else {
			howToPlay.SetActive(false);
			selectable = true;
		}
	}


	// Update is called once per frame
	void Update () {

		if (Input.GetAxis ("MoveVertical1") + Input.GetAxis ("MoveVertical2") + Input.GetAxis ("MoveVertical3") + Input.GetAxis ("MoveVertical4") == 0)
			ready = true;

		if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetAxis ("MoveVertical") > 0 && ready && selectable) {
			ready = false;
			if (option == 0) {
				option = uiChoices.Count - 1;
			} else {
				option--;
			}
		}
		if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetAxis ("MoveVertical") < 0 && ready) {
			ready = false;
			if (option == uiChoices.Count - 1) {
				option = 0;
			} else {
				option++;
			}
		}

		transform.position = uiChoices [option].transform.position + new Vector3 (-uiChoices [option].transform.localScale.x * 0.55f, uiChoices [option].transform.localScale.x * 0.2f, 0);

		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetAxis ("Jump") > 0)) {
			if (option < 3) {
				Application.LoadLevel ("main");
			} else {
				toggleInstructions ();
			}
		}
	}

}