using UnityEngine;

namespace MakeAShape.UI
{
    [RequireComponent(typeof(Animator))]
    public class ShapePanelAnimator : MonoBehaviour
    {
        private int _showPanelHash = Animator.StringToHash("ShowPanel");
        private int _hidePanelHash = Animator.StringToHash("HidePanel");
        private Animator _animator;

        void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void ShowPanel()
        {
            _animator.SetTrigger(_showPanelHash);
        }

        public void HidePanel()
        {
            _animator.SetTrigger(_hidePanelHash);
        }
    }
}
