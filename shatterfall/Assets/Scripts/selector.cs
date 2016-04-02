using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class selector : MonoBehaviour {
	
	public static int option;
	public List<GameObject> uiChoices;
	private float ready = 0;
    private float READY_DELAY = 0.2f;
	public bool selectable;
	public GameObject howToPlay;

	public AudioClip selectSound;
	private AudioSource source;

    private float TOGGLE_THRESHOLD = 0.6f;


    // Use this for initialization
    void Start () {
		source = GetComponent<AudioSource>();
		option = 0;
		transform.localScale = uiChoices [0].transform.localScale * 9f;
		selectable = true;
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

        if (ready > 0)
            ready -= Time.deltaTime;

		if ((Input.GetKey (KeyCode.UpArrow) || (Input.GetAxis ("MoveVertical") > TOGGLE_THRESHOLD)) && ready <= 0 && selectable) {
			source.PlayOneShot (selectSound, 1F);
			ready = READY_DELAY;
			if (option == 0) {
				option = uiChoices.Count - 1;
			} else {
				option--;
			}
		}
        if ((Input.GetKey(KeyCode.DownArrow) || (Input.GetAxis("MoveVertical") < -TOGGLE_THRESHOLD)) && ready <= 0 && selectable)
        {
            source.PlayOneShot (selectSound, 1F);
			ready = READY_DELAY;
            if (option == uiChoices.Count - 1) {
				option = 0;
			} else {
				option++;
			}
		}

		transform.position = uiChoices [option].transform.position + new Vector3 (-uiChoices [option].transform.localScale.x * 0.55f, uiChoices [option].transform.localScale.x * 0.2f, 0);

		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetAxis ("Jump") > 0)) {
			if (option < 3) {
				source.PlayOneShot (selectSound, 1F);
				Application.LoadLevel ("main");
			} else {
				source.PlayOneShot (selectSound, 1F);
				toggleInstructions ();
			}
		}
	}

}