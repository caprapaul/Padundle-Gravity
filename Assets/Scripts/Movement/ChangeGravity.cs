using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSD.Movement
{
    public class ChangeGravity : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 10f;

        public void ChangeMovement(Collider2D collider)
        {
            Gravity gravity = collider.GetComponent<Gravity>();
            if (gravity == null)
            {
                return;
            }
            GravityDirection newDirection = GravityDirectionExtensions.FromAngle(transform.eulerAngles.z);

            if (newDirection != gravity.Direction)
            {
                gravity.Direction = GravityDirectionExtensions.FromAngle(transform.eulerAngles.z);
                gravity.OnChange();
            }

            gravity.Force = _speed;
        }

        public void ResetMovement(Collider2D collider)
        {
            Gravity gravity = collider.GetComponent<Gravity>();
            if (gravity == null)
            {
                return;
            }

            gravity.ResetToDefault();
            gravity.OnChange();
        }
    }
}
