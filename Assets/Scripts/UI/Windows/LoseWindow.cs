using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class LoseWindow:MonoBehaviour
    {
        [SerializeField] private WindowAnimation _animator;
        [SerializeField] private TMP_Text _tmp;
        [SerializeField] private UIMediator _uiMediator;
        private Action _showHUD;

        public void SetPoints(int points)
        {
            _animator.FadeIn();
            _tmp.text = points.ToString();
        }

        public void Replay()
        {
            _uiMediator.Replay();
            _animator.FadeOut();
        }
        
    }
}