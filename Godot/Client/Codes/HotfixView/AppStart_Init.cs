using Godot;

namespace ET
{
    public class AppStart_Init: AEvent<EventType.AppStart>
    {
        protected override async void Run(EventType.AppStart args)
        {
            GD.Print("Start AppStart_Init");
            RunAsync(args).Coroutine();
        }
        
        private async ETTask RunAsync(EventType.AppStart args)
        {
            //GD.Print("Start AppStart_Init11111");
            GD.Print(Game.Scene.Id);
            Game.Scene.AddComponent<TimerComponent>();
            Game.Scene.AddComponent<CoroutineLockComponent>();
            //GD.Print("Start AppStart_Init11111");
            // 加载配置
            //Game.Scene.AddComponent<ResourcesComponent>();
            //await ResourcesComponent.Instance.LoadBundleAsync("config.unity3d");
            //Game.Scene.AddComponent<ConfigComponent>();
            //ConfigComponent.Instance.Load();
            //ResourcesComponent.Instance.UnloadBundle("config.unity3d");

            Game.Scene.AddComponent<OpcodeTypeComponent>();
            Game.Scene.AddComponent<MessageDispatcherComponent>();
            
            Game.Scene.AddComponent<NetThreadComponent>();
            Game.Scene.AddComponent<SessionStreamDispatcher>();
            Game.Scene.AddComponent<ZoneSceneManagerComponent>();
            
            Game.Scene.AddComponent<GlobalComponent>();
            Game.Scene.AddComponent<NumericWatcherComponent>();
            Game.Scene.AddComponent<AIDispatcherComponent>();
            // await ResourcesComponent.Instance.LoadBundleAsync("unit.unity3d");
            GD.Print("Start AppStart_Init 222222");
            Scene zoneScene = SceneFactory.CreateZoneScene(1, "Game", Game.Scene);
            
            Game.EventSystem.Publish(new EventType.AppStartInitFinish() { ZoneScene = zoneScene });

            await ETTask.CompletedTask;
        }
    }
}
