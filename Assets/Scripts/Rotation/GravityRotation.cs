using System.Collections;
using System.Collections.Generic;
using LSD.Movement;
using UnityEngine;

namespace LSD.Rotation
{
    [RequireComponent(typeof(Gravity))]
    public class GravityRotation : Rotation
    {
        [SerializeField]
        private Gravity _gravity = null;

        public override Quaternion GetRotation()
        {
            Vector2 direction = _gravity.Direction.ToVector2();
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90f;
            Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));

            return Quaternion.RotateTowards(transform.rotation, targetRotation, Speed * Time.deltaTime);
        }
    }
}
