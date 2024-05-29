using System;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class PauseWindow:MonoBehaviour
    {
        [SerializeField] private UIMediator _uiMediator;
        [SerializeField] private WindowAnimation _windowAnimation;
        private Action _onClose;

        public void Init(Action onClose)
        {
            _onClose = onClose;
            _windowAnimation.FadeIn();
        }

        public void Continue()
        {
            _windowAnimation.FadeOut();
            _uiMediator.Continue();
            _onClose.Invoke();
        }
    }
}