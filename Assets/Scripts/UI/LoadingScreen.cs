using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using MakeAShape.Web;

namespace MakeAShape.UI
{
    public class LoadingScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _errorMessage;

        private MaterialDownloader _downloader;
        private Image[] _images;
        private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.01f);

        [Inject]
        public void Construct(MaterialDownloader downloader)
        {
            _downloader = downloader;
        }

        void Start()
        {
            _images = GetComponentsInChildren<Image>();
            _downloader.RegisterListeners(OnSuccess, OnFail);
        }

        private void OnSuccess()
        {
            StartCoroutine(FadeLoadingScreen());
        }

        private void OnFail()
        {
            _errorMessage.SetActive(true);
        }

        private IEnumerator FadeLoadingScreen()
        {
            while (_images[0].color.a > float.Epsilon)
            {
                for (int i = 0; i < _images.Length; i++)
                {
                    var color = _images[i].color;
                    color.a -= Time.deltaTime;
                    _images[i].color = color;
                }

                yield return _waitForSeconds;
            }

            gameObject.SetActive(false);
        }
    }
}
