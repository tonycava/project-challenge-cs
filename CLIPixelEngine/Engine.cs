using System.Collections.Generic;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;
using Game.Maps;

namespace CLIPixelEngine.Engine
{
    public class Engine
    {
        public static MessageBus bus = new MessageBus();
        public static List<Entity> entities = new List<Entity>();
        public static Clock clock = new Clock();
        public static Renderer renderer = new Renderer();
        public static Camera camera = new Camera();
        public static Logic logicEngine = new Logic();
        public static MessageLinker messageLinker = new MessageLinker();
        public static MessageReceiver messageReceiver = new MessageReceiver();
        public static void StartEngine()
        {
            camera.Fov = new Vector2Int(20,30);
            renderer.SetMap(MapsHandler.GetMap(MapsHandler.MapKeys.BIG_DEBUG_MAP));
            renderer.PutCameraAt(new Vector2Int(64, 64));
            entities.Add(new Entity(new Vector2Int(120, 120), "purple_warrior.png", null));
            
            // clock.Start();
            // clock.Update();

            renderer.Draw();
            Input.Start();
        }
        
    }
}