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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            var go = GameObject.FindObjectsOfType<GameObject>();
            foreach (var g in go)
            {
                var pcomp = g.GetComponent<player>();
                if (pcomp != null)
                {
                    pcomp.Die();
                    continue;
                }
                var fcomp = g.GetComponent<floor>();
                if (fcomp != null)
                {
                    fcomp.Die();
                    continue;
                }

                if (g.name != "Plane" && g.name != "Directional Light" && g.name != "Main Camera")
                    Destroy(g);
            }
            Start();
        }
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

        var tile = (Object) null;
        int floorCounter = 0;
        int i = 0;

        int MAXi = MAP_SIZE * 4 + 1;

        int MAX = MAXi;

        const int angle1 = 225;
        const int angle2 = 45;
        const int angleHorizontal = -90;

        const float t_x1 = 0.5f;
        const float t_y1 = 0.5f;
        const float t_y2 = -0.345f;
        const float t_y3 = -0.85f;
        const float s_x1 = 1f;
        const float s_y1 = -1.7f;
        const float s_y2 = -s_y1;

        for (int j = 0; j < MAP_SIZE; j++)
        {
            tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (0 + j) - t_x1, 0, s_y1 * j + t_y1), Quaternion.Euler(new Vector3(angleHorizontal, angle2, 0)));
            tile.name = "tile" + (floorCounter++).ToString();

            for (i = 0; i < MAX; i++)
            {
                tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (i + j), 0, s_y1 * j), Quaternion.Euler(new Vector3(angleHorizontal, angle1, 0)));
                tile.name = "tile" + (floorCounter++).ToString();
                tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (i + j) + t_x1, 0, s_y1 * j + t_y1), Quaternion.Euler(new Vector3(angleHorizontal, angle2, 0)));
                tile.name = "tile" + (floorCounter++).ToString();
                tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (i + j), 0, s_y1 * j + t_y2), Quaternion.Euler(new Vector3(angleHorizontal, angle2, 0)));
                tile.name = "tile" + (floorCounter++).ToString();
                tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (i + j) + t_x1, 0, s_y1 * j + t_y3), Quaternion.Euler(new Vector3(angleHorizontal, angle1, 0)));
                tile.name = "tile" + (floorCounter++).ToString();
            }
            MAX -= 2;

            tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (i + j), 0, s_y1 * j), Quaternion.Euler(new Vector3(angleHorizontal, angle1, 0)));
            tile.name = "tile" + (floorCounter++).ToString();
            tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (i + j), 0, s_y1 * j + t_y2), Quaternion.Euler(new Vector3(angleHorizontal, angle2, 0)));
            tile.name = "tile" + (floorCounter++).ToString();

            tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (i + j) + t_x1, 0, s_y1 * j + t_y1), Quaternion.Euler(new Vector3(angleHorizontal, angle2, 0)));
            tile.name = "tile" + (floorCounter++).ToString();


        }

        MAX = MAXi;

        for (int j = 1; j < MAP_SIZE + 1 ; j++)
        {
            tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (-1 + j) - t_x1, 0, s_y2 * j + t_y3), Quaternion.Euler(new Vector3(angleHorizontal, angle1, 0)));
            tile.name = "tile" + (floorCounter++).ToString();

            for (i = -1; i < MAX - 1; i++)
            {
                tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (i + j), 0, s_y2 * j), Quaternion.Euler(new Vector3(angleHorizontal, angle1, 0)));
                tile.name = "tile" + (floorCounter++).ToString();
                tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (i + j) + t_x1, 0, s_y2 * j + t_y1), Quaternion.Euler(new Vector3(angleHorizontal, angle2, 0)));
                tile.name = "tile" + (floorCounter++).ToString();
                tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (i + j), 0, s_y2 * j + t_y2), Quaternion.Euler(new Vector3(angleHorizontal, angle2, 0)));
                tile.name = "tile" + (floorCounter++).ToString();
                tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (i + j) + t_x1, 0, s_y2 * j + t_y3), Quaternion.Euler(new Vector3(angleHorizontal, angle1, 0)));
                tile.name = "tile" + (floorCounter++).ToString();
            }
            MAX -= 2;

            tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (i + j), 0, s_y2 * j), Quaternion.Euler(new Vector3(angleHorizontal, angle1, 0)));
            tile.name = "tile" + (floorCounter++).ToString();
            tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (i + j), 0, s_y2 * j + t_y2), Quaternion.Euler(new Vector3(angleHorizontal, angle2, 0)));
            tile.name = "tile" + (floorCounter++).ToString();

            tile = GameObject.Instantiate(triangle, new Vector3(s_x1 * (i + j) + t_x1, 0, s_y2 * j + t_y3), Quaternion.Euler(new Vector3(angleHorizontal, angle1, 0)));
            tile.name = "tile" + (floorCounter++).ToString();


        }


    }
}
