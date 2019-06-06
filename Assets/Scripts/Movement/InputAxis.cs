using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSD.Movement
{
    public enum InputAxis
    {
        Horizontal,
        Vertical
    }

    public static class InputAxisExtensions
    {
        public static string GetStringValue(this InputAxis inputAxis)
        {
            switch (inputAxis)
            {
                case InputAxis.Horizontal:
                    return "Horizontal";
                case InputAxis.Vertical:
                    return "Vertical";
                default:
                    Debug.LogError("Invalid inputAxis value");
                    return null;
            }
        }
    }
}
