using UnityEngine;

namespace MakeAShape
{
    public class MaterialProperties
    {
        public string Name { get; }
        public Texture2D AlbedoTexture { get; }
        public Texture2D NormalMap { get; }
        public float Metallic { get; }
        public float Smoothness { get; }
        public Vector2 Tiling { get; }
        public float BumpScale { get; }
        public int SpecularHighlights { get; }

        public MaterialProperties(
            MaterialDto dto,
            Texture2D albedoTexture,
            Texture2D normalMap)
        {
            Name = dto.Name;
            Metallic = dto.Specularity;
            Smoothness = dto.Smoothness;
            Tiling = new Vector2(dto.TilingX, dto.TilingY);
            BumpScale = dto.BumpScale;
            SpecularHighlights = dto.Type == 0 ? 1 : 0;
            AlbedoTexture = albedoTexture;
            NormalMap = normalMap;
        }
    }

}