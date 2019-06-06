using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LSD.Events
{
    public class OnTrigger2D : MonoBehaviour
    {
        [SerializeField]
        private Collider2DEvent _onTriggerEnter2D;
        [SerializeField]
        private Collider2DEvent _onTriggerStay2D;
        [SerializeField]
        private Collider2DEvent _onTriggerExit2D;

        private void OnTriggerEnter2D(Collider2D other)
        {
            _onTriggerEnter2D.Invoke(other);
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            _onTriggerStay2D.Invoke(other);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            _onTriggerExit2D.Invoke(other);
        }
    }
}
