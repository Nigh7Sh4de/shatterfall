using UnityEngine;
using System.Collections;

public class FloorHexScript : MonoBehaviour {

    public Transform FloorPiece;

	// Use this for initialization
	void Start () {
        var pos = gameObject.transform.position;
        Instantiate(FloorPiece, RelativeVector(pos, 0, 0, 0), Quaternion.Euler(0, 0, 0));
        Instantiate(FloorPiece, RelativeVector(pos, -0.43f, 0, 0.25f), Quaternion.Euler(0, 60, 0));
        Instantiate(FloorPiece, RelativeVector(pos, -0.43f, 0, 0.75f), Quaternion.Euler(0, 120, 0));
        Instantiate(FloorPiece, RelativeVector(pos, 0, 0, 1), Quaternion.Euler(0, 180, 0));
        Instantiate(FloorPiece, RelativeVector(pos, 0.43f, 0, 0.75f), Quaternion.Euler(0, 240, 0));
        Instantiate(FloorPiece, RelativeVector(pos, 0.43f, 0, 0.25f), Quaternion.Euler(0, 300, 0));
	}

    private Vector3 RelativeVector(Vector3 pos, float x, float y, float z)
    {
        return new Vector3(pos.x + x, pos.y + y, pos.z + z);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
