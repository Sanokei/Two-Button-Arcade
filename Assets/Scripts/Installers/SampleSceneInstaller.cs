using UnityEngine;
using Zenject;

public class SampleSceneInstaller : MonoInstaller
    {
    public GameObject HierarchyElement;
    public GameObject RightClickMenu;
    public GameObject Option;

    public RectTransform GameObjectRectTransform;
    public Transform Transform;
    public Canvas ScreenCanvas; 
    public Camera Camera;
    public RectTransform ScreenCanvasRectTransform;
    public override void InstallBindings()
    {
        Container.Bind<FileManager>().AsSingle(); // needs factory

        Container.Bind<RectTransform>()
                .WithId("DragUI_GameObjectRectTransform")
                .FromInstance(GameObjectRectTransform);

        Container.Bind<Transform>()
                .WithId("DragUI_ScreenCanvas")
                .FromInstance(Transform);

        Container.Bind<Canvas>()
            .WithId("DragUI_ScreenCanvas")
            .FromInstance(ScreenCanvas);
        
        Container.Bind<RectTransform>()
            .WithId("DragUI_ScreenCanvasRectTransform")
            .FromInstance(ScreenCanvasRectTransform);
        
        Container.Bind<Camera>()
            .WithId("MainCamera")
            .FromInstance(Camera);

        Container.Bind<DragUI>();
    }
}