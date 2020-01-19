using MakeAShape.UI;
using UnityEngine;
using Zenject;

namespace MakeAShape.MaterialEditing
{
    [RequireComponent(typeof(Renderer))]
    public class MaterialTarget : MonoBehaviour
    {
        private Renderer _renderer;
        private SelectionCircle _selectionCircle;
        private IMaterialTargetSetter _targetSetter;

        public Material Material => _renderer.sharedMaterial;

        [Inject]
        public void Construct(IMaterialTargetSetter targetSetter)
        {
            _targetSetter = targetSetter;
        }
        
        private void Start()
        {
            _renderer = GetComponent<Renderer>();
            _selectionCircle = transform.parent.GetComponent<SelectionCircle>();
        }

        private void OnMouseUpAsButton()
        {
            _targetSetter.SetMaterialTarget(this);
            _selectionCircle.Show();
        }
        
        public void SetMaterial(Material material)
        {
            _renderer.sharedMaterial = material;
            _selectionCircle.Show();
        }
    }
}
