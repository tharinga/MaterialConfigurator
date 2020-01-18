using System.Collections.Generic;
using UnityEngine;

namespace MakeAShape
{
    public class MaterialController : MonoBehaviour, IMaterialApplier
    {
        private Dictionary<string, Material> _materials = new Dictionary<string, Material>();

        private Renderer _targetRenderer;

        public void SetMaterials(List<MaterialProperties> materialProperties)
        {
            
        }

        public void SetTargetRenderer(Renderer targetRenderer)
        {
            _targetRenderer = targetRenderer;
        }

        public void ApplyMaterial(string materialName)
        {
            _targetRenderer.sharedMaterial = _materials[materialName];
        }
    }
}