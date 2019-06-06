using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LSD
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        public static GameManager Instance
        {
            get
            {
                if (_instance)
                {
                    return _instance;
                }

                _instance = FindObjectOfType<GameManager>();
                if (_instance)
                {
                    return _instance;
                }

                GameObject obj = new GameObject(typeof(GameManager).Name);
                _instance = obj.AddComponent<GameManager>();
                return _instance;
            }
        }

        private int _deathCount = 0;
        private int _score = 0;

        public int DeathCount { get => _deathCount; }
        public int Score { get => _score; }

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

        public void IncrementDeathCount()
        {
            _deathCount++;
        }

        public void IncrementScore()
        {
            _score++;
        }
    }
}
