using UnityEngine;
using UnityEngine.UI;

namespace MakeAShape
{
    [RequireComponent(typeof(Button))]
    public class MaterialButton : MonoBehaviour
    {
        private Button _button;

        void Start()
        {
            _button = GetComponent<Button>();
        }

        public void Setup(IMaterialApplier materialApplier, MaterialProperties properties)
        {
            _button.image.sprite = CreateSprite(properties.AlbedoTexture);
            _button.transform.Find("Text").GetComponent<Text>().text = properties.Name;
            _button.onClick.AddListener(() => materialApplier.ApplyMaterial(properties.Name));
        }

        Sprite CreateSprite(Texture2D texture)
        {
            return Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f),
                100.0f);
        }
    }
}