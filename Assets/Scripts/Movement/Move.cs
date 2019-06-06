using System.Collections;
using System.Collections.Generic;
using LSD.UpdateManager;
using UnityEngine;

namespace LSD.Movement
{
    public class Move : ManagedBehaviour
    {
        [SerializeField]
        private List<Movement> _movements = new List<Movement>();
        [SerializeField]
        private bool _useRigidbody = false;
        [SerializeField]
        private float _rbDrag = 0f;
        [SerializeField]
        private bool _ignoreVerticalZero = false;

        private Rigidbody2D _rb;
        private Gravity _gravity;

        private bool _changedGravity = false;

        public List<Movement> Movements { get => _movements; set => _movements = value; }
        public bool ChangedGravity { get => _changedGravity; set => _changedGravity = value; }

        private void Awake()
        {
            if (_useRigidbody)
            {
                _rb = GetComponent<Rigidbody2D>();
                _gravity = GetComponent<Gravity>();
            }
        }

        public override void OnUpdate()
        {
            Vector2 velocity = TotalVelocity();

            if (_useRigidbody)
            {
                Vector2 up = -_gravity.Direction.ToVector2();
                Vector2 right = Vector2.Perpendicular(-up);

                float upVelocity = Vector2.Dot(velocity, up);
                float rightVelocity = Vector2.Dot(velocity, right);

                // This will prevent a vertical velocity of 0 (no input) from overriding the gravity
                if (_ignoreVerticalZero && upVelocity < 1E-5 && upVelocity > -1E-5)
                {
                    upVelocity = Vector2.Dot(_rb.velocity, up);
                }

                if (ChangedGravity)
                {
                    if (rightVelocity < 1E-5 && rightVelocity > -1E-5)
                    {
                        rightVelocity = Vector2.Dot(_rb.velocity, right);
                        rightVelocity = Mathf.Sign(rightVelocity) * Mathf.Max(Mathf.Abs(rightVelocity) - _rbDrag, 0f);
                    }
                    else
                    {
                        ChangedGravity = false;
                    }
                }

                velocity = upVelocity * up + rightVelocity * right;
                _rb.velocity = velocity;
                _rb.angularVelocity = 0f;
            }
            else
            {
                transform.position = transform.position + (Vector3)(velocity * Time.deltaTime);
            }
        }

        private Vector2 TotalVelocity()
        {
            Vector2 velocity = Vector2.zero;
            for (int i = 0; i < Movements.Count; i++)
            {
                velocity += Movements[i].GetVelocity();
            }
            return velocity;
        }
    }
}
