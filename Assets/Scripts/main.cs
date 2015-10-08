using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

    public Transform FloorHex;
    public Transform Character;

	// Use this for initialization
	void Start () {
        //Physics.gravity = new Vector3(0, -1.0f, 0);
        BuildFloor(20);
        Instantiate(Character, new Vector3(0, 3, 0), Quaternion.Euler(Vector3.zero));
    }

    void BuildFloor(int width)
    {
        for (var i = (-width / 2); i < width / 2; i++)
        {
            for (var j = (-width / 2); j < width / 2; j++)
            {
                Instantiate(FloorHex, new Vector3((i + j) * 1.25f, 0f, (-i + j) * 0.75f), Quaternion.Euler(Vector3.zero));
            }
        }
    }
    /*
    void BuildFloor(int c = 0, int total = 1, float x = 0, float z = 0)
    {
        var pos = new Vector3(x, 0f, z);
        if (c >= total)
            return;
        if (c == 0)
        {
            Instantiate(FloorHex, pos, Quaternion.Euler(Vector3.zero));
            pos = new Vector3(0f + pos.x, 0f, 1.5f + pos.z);
        }
        else
            switch (c % 7)
            {
                //case 0:
                //    pos = new Vector3(0f + pos.x, 0f, 1.5f + pos.z);
                //    Instantiate(FloorHex, pos, Quaternion.Euler(Vector3.zero));
                //    break;
                case 0:
                    for (var i = 0; i <= Mathf.Floor(c / 6); i++)
                    {
                        pos = new Vector3(1.25f + pos.x, 0f, -0.75f + pos.z);
                        Instantiate(FloorHex, pos, Quaternion.Euler(Vector3.zero));
                    }
                    break;
                case 1:
                    for (var i = 0; i <= Mathf.Floor(c / 6); i++)
                    {
                        pos = new Vector3(0f + pos.x, 0f, -1.5f + pos.z);
                        Instantiate(FloorHex, pos, Quaternion.Euler(Vector3.zero));
                    }
                    break;
                case 2:
                    for (var i = 0; i <= Mathf.Floor(c / 6); i++)
                    {
                        pos = new Vector3(-1.25f + pos.x, 0f, -0.75f + pos.z);
                        Instantiate(FloorHex, pos, Quaternion.Euler(Vector3.zero));
                    }
                    break;
                case 3:
                    for (var i = 0; i <= Mathf.Floor(c / 6); i++)
                    {
                        pos = new Vector3(-1.25f + pos.x, 0f, +0.75f + pos.z);
                        Instantiate(FloorHex, pos, Quaternion.Euler(Vector3.zero));
                    }
                    break;
                case 4:
                    for (var i = 0; i <= Mathf.Floor(c / 6); i++)
                    {
                        pos = new Vector3(0f + pos.x, 0f, 1.5f + pos.z);
                        Instantiate(FloorHex, pos, Quaternion.Euler(Vector3.zero));
                    }
                    break;
                case 5:
                    for (var i = 0; i <= Mathf.Floor(c / 6); i++)
                    {
                        pos = new Vector3(1.25f + pos.x, 0f, 0.75f + pos.z);
                        Instantiate(FloorHex, pos, Quaternion.Euler(Vector3.zero));
                    }
                    pos = new Vector3(0f + pos.x, 0f, 1.5f + pos.z);
                    Instantiate(FloorHex, pos, Quaternion.Euler(Vector3.zero));
                    break;

            }

        BuildFloor(++c, total, pos.x, pos.z);
    }*/

    // Update is called once per frame
    void Update () {
	
	}
}
