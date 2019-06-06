using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace LSD
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _deathCountText = null;
        [SerializeField]
        private TextMeshProUGUI _scoreText = null;

        void Update()
        {
            _deathCountText.text = GameManager.Instance.DeathCount.ToString();
            _scoreText.text = GameManager.Instance.Score.ToString();
        }
    }
}
