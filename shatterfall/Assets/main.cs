using UnityEngine;
using System.Collections;

public class main : MonoBehaviour {

    public GameObject triangle;
    public GameObject player;

    // Use this for initialization
    void Start () {
        CreateFloor();
        CreatePlayer();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void CreatePlayer()
    {
        GameObject.Instantiate(player, new Vector3(0, 1, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    void CreateFloor()
    {
        const int MAX = 20;
        for (int j = 0; j < MAX; j++)
            for (int i = 0; i < MAX - j; i++)
            {
                GameObject.Instantiate(triangle, new Vector3(0.375f * j + 0.866f * i, 0, 0.75f * j), Quaternion.Euler(new Vector3(-90, 0, 0)));
                GameObject.Instantiate(triangle, new Vector3(0.433f + 0.375f * j + 0.866f * i, 0, 0.25f + 0.75f * j), Quaternion.Euler(new Vector3(90, 0, 0)));
            }

    }
}
