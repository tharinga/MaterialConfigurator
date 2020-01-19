using UnityEngine;

namespace MakeAShape.Factories
{
    public static class SpriteFactory
    {
        public static Sprite CreateSprite(Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f),
                100.0f);
        }
    }
}