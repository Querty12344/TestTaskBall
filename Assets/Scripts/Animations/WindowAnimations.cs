using System.Collections;
using System.Security.Cryptography.X509Certificates;
using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class WindowAnimation:MonoBehaviour
    {
        [SerializeField] private float _fadeTime = 1f;
        [SerializeField] private CanvasGroup _canvasGroup;
        [SerializeField] private RectTransform _window;
        [SerializeField] private float _fadeWaitTime = 0.25f;

        public void FadeIn()
        {
            _canvasGroup.alpha = 0;
            _window.transform.localPosition = new Vector3(0f, -1000f, 0f);
            _window.gameObject.SetActive(true);
            _canvasGroup.DOFade(1, _fadeTime);
            _window.DOAnchorPos(new Vector2(0, 0 ), _fadeTime , false ).SetEase(Ease.OutElastic);
            StartCoroutine(ChildrenAnim());
        }
        public void FadeOut()
        {
            _canvasGroup.alpha = 1f;
            _window.transform.localPosition = new Vector3(0f, 0f, 0f);
            _canvasGroup.DOFade(1, _fadeTime).OnComplete( () => _window.gameObject.SetActive(false));
            _window.DOAnchorPos(new Vector2(0, -1000f ), _fadeTime , false ).SetEase(Ease.InOutQuint);
        }

        private IEnumerator ChildrenAnim()
        {
            RectTransform[] children = GetComponentsInChildren<RectTransform>();
            foreach (var rectTransform in children)
            {
                rectTransform.localScale = Vector3.zero;
            } 
            foreach (var rectTransform in children)
            {
                rectTransform.DOScale(1f , _fadeTime).SetEase(Ease.OutBounce);
                yield return new WaitForSeconds(_fadeWaitTime);
            } 
        }

    }
}