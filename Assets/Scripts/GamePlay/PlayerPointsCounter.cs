using System;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerPointsCounter:MonoBehaviour
    {
        [SerializeField] private float _pointsPerSecond;
        private float _timer;
        private bool _pause;

        public void StartCount()
        {
            if(!_pause)
                _timer += Time.time;
        }

        public int GetPoints()
        {
            return (int)Math.Floor(_timer / _pointsPerSecond);
        }

        public void SetPause(bool pause)
        {
            _pause = pause;
        }
    }
}