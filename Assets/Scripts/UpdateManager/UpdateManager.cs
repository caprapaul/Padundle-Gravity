using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSD.UpdateManager
{
    public class UpdateManager : MonoBehaviour
    {
        private static UpdateManager _instance;

        public static UpdateManager Instance
        {
            get
            {
                if (_instance)
                {
                    return _instance;
                }

                _instance = FindObjectOfType<UpdateManager>();
                if (_instance)
                {
                    return _instance;
                }

                GameObject obj = new GameObject(typeof(UpdateManager).Name);
                _instance = obj.AddComponent<UpdateManager>();
                return _instance;
            }
        }

        private readonly List<ManagedBehaviour> _updateBehaviours = new List<ManagedBehaviour>();
        private readonly List<ManagedBehaviour> _lateUpdateBehaviours = new List<ManagedBehaviour>();
        private readonly List<ManagedBehaviour> _fixedUpdateBehaviours = new List<ManagedBehaviour>();

        public static bool Exists { get => _instance; }

        private void Awake()
        {
            if (!_instance)
            {
                _instance = this;
            }
            else if (_instance != this)
            {
                Destroy(this);
            }
        }

        private void Update()
        {
            for (int i = 0; i < _updateBehaviours.Count; i++)
            {
                _updateBehaviours[i].OnUpdate();
            }
        }

        private void LateUpdate()
        {
            for (int i = 0; i < _lateUpdateBehaviours.Count; i++)
            {
                _lateUpdateBehaviours[i].OnUpdate();
            }
        }

        private void FixedUpdate()
        {
            for (int i = 0; i < _fixedUpdateBehaviours.Count; i++)
            {
                _fixedUpdateBehaviours[i].OnUpdate();
            }
        }

        public void Register(ManagedBehaviour managerBehaviour, UpdateMethod updateMethod)
        {
            switch (updateMethod)
            {
                case UpdateMethod.Update:
                    _updateBehaviours.Add(managerBehaviour);
                    break;
                case UpdateMethod.LateUpdate:
                    _lateUpdateBehaviours.Add(managerBehaviour);
                    break;
                case UpdateMethod.FixedUpdate:
                    _fixedUpdateBehaviours.Add(managerBehaviour);
                    break;
                default:
                    Debug.LogError("Register: Invalid update method.");
                    break;
            }
        }

        public void Unregister(ManagedBehaviour managerBehaviour, UpdateMethod updateMethod)
        {
            switch (updateMethod)
            {
                case UpdateMethod.Update:
                    _updateBehaviours.Remove(managerBehaviour);
                    break;
                case UpdateMethod.LateUpdate:
                    _lateUpdateBehaviours.Remove(managerBehaviour);
                    break;
                case UpdateMethod.FixedUpdate:
                    _fixedUpdateBehaviours.Remove(managerBehaviour);
                    break;
                default:
                    Debug.LogError("Register: Invalid update method.");
                    break;
            }
        }

    }
}