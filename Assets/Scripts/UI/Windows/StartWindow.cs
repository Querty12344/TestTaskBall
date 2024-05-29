using UnityEngine;

namespace DefaultNamespace
{
    public class StartWindow:MonoBehaviour
    {
        [SerializeField] private WindowAnimation _windowAnimation;
        [SerializeField] private UIMediator _uiMediator;
        
        public void Init()
        {
            _windowAnimation.FadeIn();
        }

        public void StartGame()
        {
            _windowAnimation.FadeOut();
            _uiMediator.StartGame();
        } 
    }
}