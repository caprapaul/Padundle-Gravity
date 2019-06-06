using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSD.Rotation
{
    [RequireComponent(typeof(Rotate))]
    public abstract class Rotation : MonoBehaviour
    {
        [SerializeField]
        private float _speed; // < 0 values means instant rotation

        public float Speed{ get => _speed; set => _speed = value; }

        public abstract Quaternion GetRotation();
    }
}