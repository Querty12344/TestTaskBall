using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class LevelBound:MonoBehaviour
    {
        public event Action OnPlayerHit;
        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent<PlayerGravitation>(out var p))
            {
                OnPlayerHit?.Invoke();
            }
        }
    }
}