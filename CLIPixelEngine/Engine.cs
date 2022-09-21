using System.Collections.Generic;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;
using Game.Maps;

namespace CLIPixelEngine.Engine
{
    public class Engine
    {
        public static MessageBus bus = new MessageBus();
        public static List<Entity> entities = new List<Entity>
        {
            new Entity(new Vector2Int(64, 64), "purple_warrior.png", null)
        };
        public static Clock clock = new Clock();
        public static Renderer renderer = new Renderer();
        public static Camera camera = new Camera();
        public static Logic logicEngine = new Logic();
        public static void StartEngine()
        {
            camera.Fov = 35;
            renderer.SetMap(MapsHandler.GetMap(MapsHandler.MapKeys.BIG_DEBUG_MAP));
            renderer.SetupCamera(camera);
            renderer.PutCameraAt(new Vector2Int(64, 64));
            clock.Start();
            clock.Update();
            
        }
        
    }
}