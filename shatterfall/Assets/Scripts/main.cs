using UnityEngine;
using System.Collections;

public class main : MonoBehaviour
{

    public GameObject triangle;
    public GameObject player;
    public GameObject floor;

    static GameObject floorInstance;

    // Use this for initialization
    void Start()
    {
        CreateFloor(8);
        CreatePlayer();
        //var x = (GameObject) GameObject.Instantiate(triangle, new Vector3(0, 0, 0), Quaternion.Euler(new Vector3(-90, 0, 0)));
        ////x.transform.localScale += new Vector3(10, 1, 10);
        //GameObject.Instantiate(player, new Vector3(0, 5, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static GameObject GetFloor()
    {
        return floorInstance;
    }

    void CreatePlayer()
    {
        GameObject.Instantiate(player, new Vector3(5, 0.7f, 5), Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    void CreateFloor(int MAP_SIZE)
    {
        floorInstance = (GameObject)GameObject.Instantiate(floor, new Vector3(13, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));

        int i = 0;

        //const int MAP_SIZE = 8;
        int MAXi = MAP_SIZE * 4 + 1;

        int MAX = MAXi;

        for (int j = 0; j < MAP_SIZE; j++)
        {
            GameObject.Instantiate(triangle, new Vector3(0.8765f * (0 + j) - 0.43825f, 0, -1.5f * j + 0.25f), Quaternion.Euler(new Vector3(-90, 160, 0)));

            //for (int i = 0; i < MAX - j; i++)
            for (i = 0; i < MAX; i++)
            {
                GameObject.Instantiate(triangle, new Vector3(0.8765f * (i + j), 0, -1.5f * j), Quaternion.Euler(new Vector3(-90, 345, 0)));
                GameObject.Instantiate(triangle, new Vector3(0.8765f * (i + j) + 0.43825f, 0, -1.5f * j + 0.25f), Quaternion.Euler(new Vector3(-90, 160, 0)));
                GameObject.Instantiate(triangle, new Vector3(0.8765f * (i + j), 0, -1.5f * j - 0.5f), Quaternion.Euler(new Vector3(-90, 160, 0)));
                GameObject.Instantiate(triangle, new Vector3(0.8765f * (i + j) + 0.43825f, 0, -1.5f * j - 0.75f), Quaternion.Euler(new Vector3(-90, 345, 0)));



            //GameObject.Instantiate(triangle, new Vector3(0.375f * j + 0.866f * i, 0, 0.75f * j), Quaternion.Euler(new Vector3(-90, 0, 0)));
            //GameObject.Instantiate(triangle, new Vector3(0.433f + 0.375f * j + 0.866f * i, 0, 0.25f + 0.75f * j), Quaternion.Euler(new Vector3(-90, 180, 0)));
            }
            MAX -= 2;

            GameObject.Instantiate(triangle, new Vector3(0.8765f * (i + j), 0, -1.5f * j), Quaternion.Euler(new Vector3(-90, 345, 0)));
            GameObject.Instantiate(triangle, new Vector3(0.8765f * (i + j), 0, -1.5f * j - 0.5f), Quaternion.Euler(new Vector3(-90, 160, 0)));

            GameObject.Instantiate(triangle, new Vector3(0.8765f * (i + j) + 0.43825f, 0, -1.5f * j + 0.25f), Quaternion.Euler(new Vector3(-90, 160, 0)));


        }

        MAX = MAXi;

        for (int j = 1; j < MAP_SIZE + 1 ; j++)
        {
            GameObject.Instantiate(triangle, new Vector3(0.8765f * (-1 + j) - 0.43825f, 0, 1.5f * j - 0.75f), Quaternion.Euler(new Vector3(-90, 345, 0)));


            //for (int i = 0; i < MAX - j; i++)
            for (i = -1; i < MAX - 1; i++)
            {
                GameObject.Instantiate(triangle, new Vector3(0.8765f * (i + j), 0, 1.5f * j), Quaternion.Euler(new Vector3(-90, 345, 0)));
                GameObject.Instantiate(triangle, new Vector3(0.8765f * (i + j) + 0.43825f, 0, 1.5f * j + 0.25f), Quaternion.Euler(new Vector3(-90, 160, 0)));
                GameObject.Instantiate(triangle, new Vector3(0.8765f * (i + j), 0, 1.5f * j - 0.5f), Quaternion.Euler(new Vector3(-90, 160, 0)));
                GameObject.Instantiate(triangle, new Vector3(0.8765f * (i + j) + 0.43825f, 0, 1.5f * j - 0.75f), Quaternion.Euler(new Vector3(-90, 345, 0)));



                //GameObject.Instantiate(triangle, new Vector3(0.375f * j + 0.866f * i, 0, 0.75f * j), Quaternion.Euler(new Vector3(-90, 0, 0)));
                //GameObject.Instantiate(triangle, new Vector3(0.433f + 0.375f * j + 0.866f * i, 0, 0.25f + 0.75f * j), Quaternion.Euler(new Vector3(-90, 180, 0)));
            }
            MAX -= 2;

            GameObject.Instantiate(triangle, new Vector3(0.8765f * (i + j), 0, 1.5f * j), Quaternion.Euler(new Vector3(-90, 345, 0)));
            GameObject.Instantiate(triangle, new Vector3(0.8765f * (i + j), 0, 1.5f * j - 0.5f), Quaternion.Euler(new Vector3(-90, 160, 0)));

            GameObject.Instantiate(triangle, new Vector3(0.8765f * (i + j) + 0.43825f, 0, 1.5f * j - 0.75f), Quaternion.Euler(new Vector3(-90, 345, 0)));


        }


    }
}
