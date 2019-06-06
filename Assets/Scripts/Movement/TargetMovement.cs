using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSD.Movement
{
    public class TargetMovement : Movement
    {
        [SerializeField]
        private Transform _target;

        [Tooltip("Should it move faster the further from target?\n 0 = normal movement,\n1 = fully dependent on distance")]
        [Range(0, 1)]
        [SerializeField]
        private float _distanceMultiplier;

        [SerializeField]
        private float _maxSpeed;

        [SerializeField]
        private float _smoothTime;

        private Vector3 _currentVelocity;

        public override Vector2 GetVelocity()
        {
            float currentSpeed = Mathf.Min(Speed * Mathf.Pow((_target.position - transform.position).magnitude, _distanceMultiplier), _maxSpeed);
            Vector3.SmoothDamp(transform.position, _target.position, ref _currentVelocity, _smoothTime, currentSpeed);
            return _currentVelocity;
        }
    }
}