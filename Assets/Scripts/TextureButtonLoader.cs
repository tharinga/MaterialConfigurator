using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MakeAShape
{
    public class TextureButtonLoader : MonoBehaviour
    {
        [SerializeField] private Transform _scrollView;
        [SerializeField] private GameObject _buttonPrefab;
        private IMaterialApplier _materialApplier;

        [Inject]
        public void Construct(IMaterialApplier materialApplier)
        {
            _materialApplier = materialApplier;
        }

        public void LoadButtons(List<MaterialProperties> materials)
        {
            foreach (var material in materials)
            {
                var button = Instantiate(_buttonPrefab, _scrollView);
                button.GetComponent<MaterialButton>().Setup(_materialApplier, material);
            }
        }
    }
}