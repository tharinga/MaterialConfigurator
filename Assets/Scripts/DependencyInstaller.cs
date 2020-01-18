using System.Collections;
using System.Collections.Generic;
using MakeAShape;
using UnityEngine;
using Zenject;

public class DependencyInstaller : MonoInstaller<DependencyInstaller>
{
    public override void InstallBindings()
    {
        Container.Bind<WebApiService>().AsSingle();
        Container.Bind<TextureButtonLoader>().FromComponentInHierarchy().AsSingle();
    }
}
