using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSD.Movement
{
    public enum GravityDirection
    {
        Up = 2,
        Down = -2,
        Right = 1,
        Left = -1
    }

    public static class GravityDirectionExtensions
    {
        public static Vector2 ToVector2(this GravityDirection gravityDirection)
        {
            switch (gravityDirection)
            {
                case GravityDirection.Up:
                    return Vector2.up;
                case GravityDirection.Down:
                    return Vector2.down;
                case GravityDirection.Right:
                    return Vector2.right;
                case GravityDirection.Left:
                    return Vector2.left;
                default:
                    Debug.LogError("Invalid gravityDirection value.");
                    return Vector2.zero;
            }
        }

        public static GravityDirection FromAngle(float angle)
        {
            int intAngle = (int)angle;
            switch (intAngle)
            {
                case 0:
                    return GravityDirection.Down;
                case 90:
                    return GravityDirection.Right;
                case 180:
                    return GravityDirection.Up;
                case 270:
                    return GravityDirection.Left;
                case -90:
                    return GravityDirection.Left;
                default:
                    Debug.LogError("Invalid angle value.");
                    return GravityDirection.Down;
            }
        }
    }
}
