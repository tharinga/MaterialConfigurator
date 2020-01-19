using MakeAShape.Data;
using UnityEngine;

namespace MakeAShape.Factories
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
