using UnityEngine;

namespace MakeAShape
{
    public class StandardMaterialFactory : MaterialFactory
    {
        private readonly Shader _shader;
        private readonly int _bumpMapId;
        private readonly int _bumpScaleId;
        private readonly int _smoothnessId;
        private readonly int _metallicId;
        private readonly int _highlightsId;

        public StandardMaterialFactory()
        {
            _shader = Shader.Find("Standard");
            _bumpMapId = Shader.PropertyToID("_BumpMap");
            _bumpScaleId = Shader.PropertyToID("_BumpScale");
            _smoothnessId = Shader.PropertyToID("_Glossiness");
            _metallicId = Shader.PropertyToID("_Metallic");
            _highlightsId = Shader.PropertyToID("_SpecularHighlights");
        }

        protected override Material Create(MaterialProperties properties)
        {
            var material = new Material(_shader);
            material.name = properties.Name;
            material.mainTexture = properties.AlbedoTexture;
            material.mainTextureScale = properties.Tiling;
            material.SetTexture(_bumpMapId, properties.NormalMap);
            material.SetFloat(_bumpScaleId, properties.BumpScale);
            material.SetFloat(_smoothnessId, properties.Smoothness);
            material.SetFloat(_metallicId, properties.Metallic);
            material.SetFloat(_highlightsId, properties.SpecularHighlights);

            return material;
        }
    }
}