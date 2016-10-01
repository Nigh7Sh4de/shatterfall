using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class KeyMap
    {
        public KeyMap(string name, string x, KeyCode p, KeyCode? n = null)
        {
            Name = name;
            XBOXkey = x;
            PCkey = p;
            PreviousFrame = 10;
            nPCkey = n;
        }
        public string Name;
        public string XBOXkey;
        public KeyCode PCkey;
        public KeyCode? nPCkey;
        public float PreviousFrame;
    }
}
