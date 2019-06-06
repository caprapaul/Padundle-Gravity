using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSD.Movement
{
    [RequireComponent(typeof(Move))]
    public abstract class Movement : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 10f;

        public float Speed
        {
            get => _speed;

            set => _speed = value;
        }

        public abstract Vector2 GetVelocity();
    }
}
