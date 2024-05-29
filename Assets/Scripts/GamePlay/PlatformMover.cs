using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlatformMover:MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private float _speed;

        private bool _pause = false;
        
        public void SetPause(bool pause)
        {
            _pause = pause;
        }
        public void FixedUpdate()
        {
            
            if(!_pause)
                _rigidbody2D.MovePosition((Vector2)transform.position + _speed * Vector2.left);
            
        }
    }
}