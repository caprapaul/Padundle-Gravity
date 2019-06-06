using UnityEngine;
using UnityEngine.Events;

namespace LSD.Events
{
    [System.Serializable]
    public class Collider2DEvent : UnityEvent<Collider2D> { }

    [System.Serializable]
    public class Collision2DEvent : UnityEvent<Collision2D> { }

    [System.Serializable]
    public class IntEvent: UnityEvent<int> { }
}
