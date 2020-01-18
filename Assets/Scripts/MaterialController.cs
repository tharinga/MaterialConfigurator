using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace MakeAShape
{
    public class MaterialController : MonoBehaviour, IMaterialApplier
    {
        private Dictionary<string, Material> _materials = new Dictionary<string, Material>();

        private Renderer _targetRenderer;
        private MaterialFactory _materialFactory;

        [Inject]
        public void Construct(MaterialFactory materialFactory)
        {
            _materialFactory = materialFactory;
        }
        
        public void LoadMaterials(List<MaterialProperties> materialProperties)
        {
            foreach (var material in materialProperties)
            {
                _materials[material.Name] = _materialFactory.CreateMaterial(material);
            }
        }

        public void SetTargetRenderer(Renderer targetRenderer)
        {
            _targetRenderer = targetRenderer;
        }

        public void ApplyMaterial(string materialName)
        {
            if (_targetRenderer == null)
            {
                return;
            }
            _targetRenderer.sharedMaterial = _materials[materialName];
        }
    }
}