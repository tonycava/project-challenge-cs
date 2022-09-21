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
        public static void StartEngine()
        {
            camera.Fov = 24;
            renderer.SetMap(MapsHandler.GetMap(MapsHandler.MapKeys.DEBUG_MAP));
            renderer.SetupCamera(camera);
            clock.Start();
            clock.Update();
            
        }
        
    }
}