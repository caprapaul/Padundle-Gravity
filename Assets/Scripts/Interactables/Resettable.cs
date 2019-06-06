using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LSD.Interactables
{
    public class Resettable : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent _onReset;

        public void OnReset()
        {
            _onReset.Invoke();
        }
    }
}
