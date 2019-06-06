using System.Collections;
using System.Collections.Generic;
using LSD.Movement;
using UnityEngine;

namespace LSD.Rotation
{
    public class TargetRotation : Rotation
    {
        [SerializeField]
        private Transform _target = null;

        private float _zVelocity;

        public override Quaternion GetRotation()
        {
            if (Speed < 0)
            {
                return _target.rotation;
            }
            float zAngle = Mathf.SmoothDampAngle(transform.eulerAngles.z, _target.eulerAngles.z, ref _zVelocity, 1f / Speed);
            return Quaternion.Euler(0f, 0f, zAngle);
        }
    }
}
