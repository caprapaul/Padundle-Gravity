using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LSD.UpdateManager;
using UnityEngine;

namespace LSD.Rotation
{
    public class Rotate : ManagedBehaviour
    {
        [SerializeField]
        private Rotation _rotation;

        [SerializeField]
        private bool _useRigidbody = false;

        private Rigidbody2D _rb;

        private void Awake()
        {
            if (_useRigidbody)
            {
                _rb = GetComponent<Rigidbody2D>();
            }
        }

        public override void OnUpdate()
        {
            if (_useRigidbody)
            {
                _rb.rotation = _rotation.GetRotation().eulerAngles.z;
            }
            else
            {
                transform.rotation = _rotation.GetRotation();
            }
        }
    }
}
