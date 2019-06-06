using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSD.Interactables
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField]
        private Transform _point = null;

        public Transform Point { get => _point; set => _point = value; }

        public void ResetPosition()
        {
            transform.position = Point.position;
        }
    }
}
