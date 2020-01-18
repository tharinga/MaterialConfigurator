using System.Collections.Generic;
using UnityEngine;

namespace MakeAShape
{
    public class ButtonLoader : MonoBehaviour
    {
        [SerializeField] private Transform _scrollView;
        [SerializeField] private GameObject _buttonPrefab;
        private IMaterialApplier _materialApplier;

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