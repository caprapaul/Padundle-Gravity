using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSD.Interactables
{
    public class ResetOnCollision : MonoBehaviour
    {
        public void ResetOther(Collision2D collision)
        {
            Resettable resettable = collision.collider.GetComponent<Resettable>();
            if (resettable == null)
            {
                return;
            }

            resettable.OnReset();
        }
    }
}
