using SocketIO;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

namespace Assets.Scripts
{

    class Control
    {
        public string Name;
        public string PlayerName;
        public Control (string name, string player_name)
        {
            Name = name;
            PlayerName = player_name;
        }
    }

    static class network
    {
        private static SocketIOComponent socket;
        private static List<Control> controls;

        public static bool GetControlDown(Control control)
        {
            var _control = controls.Find((c) =>
            {
                return c.Name == control.Name && c.PlayerName == control.PlayerName;
            });
            return controls.Remove(_control);
        }

        public static void Down(Control control)
        {
            var json = new JSONObject();
            json.AddField("name", control.Name);
            json.AddField("player_name", control.PlayerName);
            socket.Emit("down", json);
        }

        public static void init()
        {
            var go = GameObject.Find("SocketIO");
            socket = go.GetComponent<SocketIOComponent>();

            socket.On("open", (e) =>
            {
                Debug.Log("Network connection established");
            });

            socket.On("error", (e) =>
            {
                Debug.LogError(e.name + " " + e.data);
            });

            socket.On("close", (e) =>
            {
                Debug.Log("Network connection closed");
            });

            socket.On("down", (e) =>
            {
                string name,
                       player_name;

                e.data.ToDictionary().TryGetValue("name", out name);
                e.data.ToDictionary().TryGetValue("player_name", out player_name);
                controls.Add(new Control(name, player_name));

                Debug.Log("Controls: " + controls.Count);
            });

        }
    }
}
