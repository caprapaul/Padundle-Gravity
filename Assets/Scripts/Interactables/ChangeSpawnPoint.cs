using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSD.Interactables
{
    public class ChangeSpawnPoint : MonoBehaviour
    { 
        public void ChangePoint(Collider2D other)
        {
            SpawnPoint spawnPoint = other.GetComponent<SpawnPoint>();
            if (other == null)
            {
                return;
            }

            spawnPoint.Point = transform;
        }
    }
}
