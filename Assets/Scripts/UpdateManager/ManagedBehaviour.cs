using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSD.UpdateManager
{
    public abstract class ManagedBehaviour : MonoBehaviour
    {
        [SerializeField]
        private UpdateMethod _updateMethod = UpdateMethod.Update;

        protected virtual void OnEnable()
        {
            UpdateManager.Instance.Register(this, _updateMethod);
        }

        protected virtual void OnDisable()
        {
            if (UpdateManager.Exists)
            {
                UpdateManager.Instance.Unregister(this, _updateMethod);
            }
        }

        public abstract void OnUpdate();
    }
}
