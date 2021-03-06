﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SocketIO;

public class main : MonoBehaviour
{

    public GameObject triangle;
    public GameObject player;
    public GameObject floor;
    public Material[] PlayerMaterial = new Material[4];
    static GameObject floorInstance;
    private static List<GameObject> Players = new List<GameObject>();
    public static string WinnerName;
	

    public static void PlayerDied(GameObject deadPlayer)
    {
        Players.Remove(deadPlayer);

        if (Players.Count == 1) {
			//Debug.Log ("WIN " + Players [0].name);
            Players[0].GetComponent<player>().Win();
            WinnerName = Players[0].name;
            Players.Remove(Players[0]);
            BreakFloor();
		}
    }

    static void BreakFloor()
    {
        var go = GameObject.FindObjectsOfType<GameObject>();
        foreach (var g in go)
        {
            var f = g.GetComponent<floor>();
            if (f == null)
                continue;

            f.Drop(true);
        }
    }

    // Use this for initialization
    void Start()
    {
        //var go = GameObject.Find("SocketIO");
        //var socket = go.GetComponent<SocketIOComponent>();
        //socket.On("open", (e) => {
        //    Debug.Log(e.name + " " + e.data);
        //    var json = new JSONObject();
        //    json.AddField("prop", "some value");
        //    Debug.Log("emitting 'beep'");
        //    socket.Emit("beep", json);
        //});
        //socket.On("boop", (e) => {
        //    Debug.Log(e.name + " " + e.data);
        //});
        //socket.On("error", (e) => {
        //    Debug.Log(e.name + " " + e.data);
        //});
        //socket.On("close", (e) => {
        //    Debug.Log(e.name + " " + e.data);
        //});


        Players.Clear();
        CreateFloor(8);
        var playerCount = selector.option + 2;
        CreatePlayer(playerCount);
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
		if (Input.GetKeyDown (KeyCode.R) || Input.GetAxis("Start") > 0) {
			Application.LoadLevel ("MainMenu");
		}
    }

    public static GameObject GetFloor()
    {
        return floorInstance;
    }

    private class PlayerPosition
    {
        public PlayerPosition(Vector3 pos, Vector3 rot)
        {
            position = pos;
            rotation = rot;
        }
        public Vector3 position;
        public Vector3 rotation;
    }

    private PlayerPosition GeneratePlayerPosition(int i)
    {
        if (i > 3)
            throw new UnityException("Cannot have more than 4 players.");
        var map_width = FloorConstants.s_x1 * (0 + 31) + FloorConstants.t_x1;
        var position = new Vector3(
                i % 2 != 0 ? map_width - 5 : 5,
                0.7f,
                i < 2 ? 5 : -5
            );
        var rotation = new Vector3(
                0,
                i % 2 == 0 ? 0 : 180,
                0
            );
        return new PlayerPosition(position, rotation); 

    }

    void CreatePlayer(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var playerPos = GeneratePlayerPosition(i);
            var created_player = (GameObject)Instantiate(player, playerPos.position, Quaternion.Euler(playerPos.rotation));
            created_player.GetComponent<player>().InitPlayer(this.GetComponent<Camera>(), i + 1, PlayerMaterial[i], i == 0);
            Players.Add(created_player);
        }
    }

    private static class FloorConstants {
        public const float t_x1 = 0.5f;
        public const float t_y1 = 0.5f;
        public const float t_y2 = -0.345f;
        public const float t_y3 = -0.85f;
        public const float s_x1 = 1f;
        public const float s_y1 = -1.7f;
        public const float s_y2 = -s_y1;
    };

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

        const float t_x1 = FloorConstants.t_x1;
        const float t_y1 = FloorConstants.t_y1;
        const float t_y2 = FloorConstants.t_y2;
        const float t_y3 = FloorConstants.t_y3;
        const float s_x1 = FloorConstants.s_x1;
        const float s_y1 = FloorConstants.s_y1;
        const float s_y2 = FloorConstants.s_y2;

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
