using MakeAShape.Factories;
using MakeAShape.MaterialEditing;
using MakeAShape.UI;
using MakeAShape.Web;
using Zenject;

namespace MakeAShape.Config
{
    public class DependencyInstaller : MonoInstaller<DependencyInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<WebApiService>().AsSingle();
            Container.Bind<TextureButtonLoader>().FromComponentInHierarchy().AsSingle();
            Container.Bind<MaterialController>().FromComponentInHierarchy().AsSingle();
            Container.Bind<IMaterialApplier>().To<MaterialController>().FromResolve();
            Container.Bind<IMaterialTargetSetter>().To<MaterialController>().FromResolve();
            Container.Bind<IUndoRedoHandler>().To<MaterialController>().FromResolve();
            Container.Bind<MaterialFactory>().To<StandardMaterialFactory>().AsSingle();
            Container.Bind<MementoCaretaker>().AsSingle();
            Container.Bind<ShapePanelAnimator>().FromComponentInHierarchy().AsSingle();
            Container.Bind<MaterialDownloader>().FromComponentInHierarchy().AsSingle();
        }
    }
}
