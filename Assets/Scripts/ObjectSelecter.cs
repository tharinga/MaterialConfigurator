using System;
using UnityEngine;
using Zenject;


namespace MakeAShape
{
    [RequireComponent(typeof(Renderer))]
    public class ObjectSelecter : MonoBehaviour
    {
        private Renderer _renderer;
        private IMaterialTargetSetter _targetSetter;

        private void Start()
        {
            _renderer = GetComponent<Renderer>();
        }

        [Inject]
        public void Construct(IMaterialTargetSetter targetSetter)
        {
            _targetSetter = targetSetter;
        }

        private void OnMouseUpAsButton()
        {
            _targetSetter.SetTargetRenderer(_renderer);
        }
    }
}
