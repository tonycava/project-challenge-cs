using System.Collections.Generic;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;

namespace CLIPixelEngine.Engine
{
    public class Engine
    {
        public static MessageBus bus = new MessageBus();
        public static List<Entity> entities = new List<Entity>();
        public static Clock clock = new Clock();
        public static Renderer renderer = new Renderer();

        public static void StartEngine()
        {
            clock.Start();
            clock.Update();
        }
    }
}