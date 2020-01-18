using UnityEngine;

namespace MakeAShape
{
    public abstract class MaterialFactory
    {
        public Material CreateMaterial(MaterialProperties properties)
        {
            return Create(properties);
        }

        protected abstract Material Create(MaterialProperties properties);
    }
}
