using System.Collections.Generic;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;
using CLIPixelEngine.Engine.Render;
using CLIPixelEngine.Engine.FrameWork;

namespace CLIPixelEngine.Engine
{
    public class Engine
    {
        public static MessageBus bus = new MessageBus();
        public List<Entity> Entities;
    }
}