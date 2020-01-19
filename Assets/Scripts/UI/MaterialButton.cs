using MakeAShape.Data;
using MakeAShape.Factories;
using MakeAShape.MaterialEditing;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace MakeAShape.UI
{
    public class MaterialButton : Button
    {
        private Outline _outline;

        public void Setup(IMaterialApplier materialApplier, MaterialProperties properties)
        {
            _outline = GetComponent<Outline>();
            _outline.enabled = false;
            image.sprite = SpriteFactory.CreateSprite(properties.AlbedoTexture);
            transform.Find("Text").GetComponent<Text>().text = properties.Name;
            onClick.AddListener(() => materialApplier.ApplyMaterial(properties.Name));
        }

        public override void OnSelect(BaseEventData eventData)
        {
            _outline.enabled = true;
        }
        
        public override void OnDeselect(BaseEventData eventData)
        {
            _outline.enabled = false;
        }
    }
}