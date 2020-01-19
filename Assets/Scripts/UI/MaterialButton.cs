using MakeAShape.Data;
using MakeAShape.Factories;
using MakeAShape.MaterialEditing;
using UnityEngine;
using UnityEngine.UI;

namespace MakeAShape.UI
{
    [RequireComponent(typeof(Button))]
    public class MaterialButton : MonoBehaviour
    {
        private Button _button;

        public void Setup(IMaterialApplier materialApplier, MaterialProperties properties)
        {
            _button = GetComponent<Button>();
            _button.image.sprite = SpriteFactory.CreateSprite(properties.AlbedoTexture);
            _button.transform.Find("Text").GetComponent<Text>().text = properties.Name;
            _button.onClick.AddListener(() => materialApplier.ApplyMaterial(properties.Name));
        }
    }
}