using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class WindowsOpener:MonoBehaviour
    {
        [SerializeField] private LoseWindow _loseWindow;
        [SerializeField] private PauseWindow _pauseWindow;
        [SerializeField] private StartWindow _startWindow;
        [SerializeField] private GameObject _hud;

        public void OpenLose(int points)
        {
            _loseWindow.gameObject.SetActive(true);
            _loseWindow.SetPoints(points);
        }

        public void OpenPause()
        {
            _pauseWindow.gameObject.SetActive(true);
            _pauseWindow.Init(ShowHUD);
        }

        public void OpenStart()
        {
            _startWindow.gameObject.SetActive(true);
            _startWindow.Init();
        }

        public void ShowHUD()
        {
            _hud.SetActive(true);
        }

        public void HideHUD()
        {
            _hud.SetActive(false);
        }
    }                   
}