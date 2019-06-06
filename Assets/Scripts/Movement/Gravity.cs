using System.Collections;
using System.Collections.Generic;
using LSD.Events;
using LSD.UpdateManager;
using UnityEngine;
using UnityEngine.Events;

namespace LSD.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Gravity : ManagedBehaviour
    {
        [SerializeField]
        private GravityDirection _defaultDirection = GravityDirection.Down;
        [SerializeField]
        private float _defaultForce = 10f;
        [SerializeField]
        private float _maxSpeed = 10f;
        [SerializeField]
        private IntEvent _onChange = null;

        private GravityDirection _direction = GravityDirection.Down;
        private GravityDirection _oldDirection = GravityDirection.Down;
        private float _force = 10f;


        public float Force { get => _force; set => _force = value; }
        public GravityDirection Direction { get => _direction; set => _direction = value; }

        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            ResetToDefault();
        }

        public override void OnUpdate()
        {
            Vector2 direction = Direction.ToVector2();

            float directionSpeed = Vector2.Dot(_rb.velocity, direction);
            float force = Mathf.Lerp(_force, 0f, directionSpeed / _maxSpeed);
            _rb.AddForce(force * direction);
        }

        public void OnChange()
        {
            _onChange.Invoke((int)Direction);
        }

        public void ResetToDefault()
        {
            _direction = _defaultDirection;
            _force = _defaultForce;
        }
    }
}
