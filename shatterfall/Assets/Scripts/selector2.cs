using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class selector2 : MonoBehaviour {
	
	public static int option;
	public List<GameObject> uiChoices;
	public Text PlayerWin;
	public static int winner;
	public bool selectable;

	public AudioClip selectSound;
	private AudioSource source;
	
	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource>();
		option = 0;
		transform.localScale = uiChoices [0].transform.localScale * 9f;
		selectable = true;
        ready = 0;
	}
	
	float ready;
    float READY_DELAY = 0.2f;
    float TOGGLE_THRESHOLD = 0.6f;

	IEnumerator loadMainScene() {
		selectable = false;
		float fadeTime = GameObject.Find ("Fader").GetComponent<Fading> ().BeginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel ("main");
	}

	// Update is called once per frame
	void Update () {

		PlayerWin.text = "P L A Y E R   " + winner + "   W I N S !";
        if (ready > 0)
            ready -= Time.deltaTime;

        if ((Input.GetKey(KeyCode.UpArrow) || (Input.GetAxis("MoveVertical") > TOGGLE_THRESHOLD)) && ready <= 0 && selectable)
        {
            source.PlayOneShot(selectSound, 1F);
            ready = READY_DELAY;
            if (option == 0)
            {
                option = uiChoices.Count - 1;
            }
            else {
                option--;
            }
        }
        if ((Input.GetKey(KeyCode.DownArrow) || (Input.GetAxis("MoveVertical") < -TOGGLE_THRESHOLD)) && ready <= 0 && selectable)
        {
            source.PlayOneShot(selectSound, 1F);
            ready = READY_DELAY;
            if (option == uiChoices.Count - 1)
            {
                option = 0;
            }
            else {
                option++;
            }
        }

        transform.position = uiChoices[option].transform.position + new Vector3(-uiChoices[option].transform.localScale.x * 0.55f, uiChoices[option].transform.localScale.x * 0.2f, 0);
		
		if ((Input.GetKeyDown (KeyCode.Space) || Input.GetAxis("Jump1") > 0) && ready <= 0) {
            ready = READY_DELAY;
			if(option == 0 && selectable){
				source.PlayOneShot (selectSound, 1F);
				StartCoroutine(loadMainScene());
			}
			else {
				source.PlayOneShot (selectSound, 1F);
				Application.LoadLevel ("MainMenu");
			}
		}
	}
}