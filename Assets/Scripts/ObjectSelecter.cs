using System;
using UnityEngine;
using Zenject;


namespace MakeAShape
{
    [RequireComponent(typeof(Renderer))]
    public class ObjectSelecter : MonoBehaviour
    {
        private Renderer _renderer;
        private SelectionCircle _selectionCircle;
        private IMaterialTargetSetter _targetSetter;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _selectionCircle = transform.parent.GetComponent<SelectionCircle>();
        }

        [Inject]
        public void Construct(IMaterialTargetSetter targetSetter)
        {
            _targetSetter = targetSetter;
        }

        private void OnMouseUpAsButton()
        {
            _targetSetter.SetTargetRenderer(_renderer);
            _selectionCircle.Show();
        }
    }
}
