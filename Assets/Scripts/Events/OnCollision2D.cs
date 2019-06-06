using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LSD.Events
{
    public class OnCollision2D : MonoBehaviour
    {
        [SerializeField]
        private Collision2DEvent _onCollisionEnter2D;
        [SerializeField]
        private Collision2DEvent _onCollisionStay2D;
        [SerializeField]
        private Collision2DEvent _onCollisionExit2D;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _onCollisionEnter2D.Invoke(collision);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            _onCollisionStay2D.Invoke(collision);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            _onCollisionExit2D.Invoke(collision);
        }
    }
}
