using System;
using UnityEngine;

namespace Script.UIs
{
    public class UiEvents : MonoBehaviour
    {
        public static readonly GameOverEvent GameOverEvent = new();
    }

    public class GameOverEvent : GameEvent
    {
        public bool Result;
    }
}