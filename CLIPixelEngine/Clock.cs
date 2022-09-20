using CLIPixelEngine.Engine.Bus;
using Project_CS.CLIPixelEngine;

namespace CLIPixelEngine.Engine
{
    public class Clock
    {
        public void Start()
        {
            Message startMapMessage = new Message(
                ActionType.INPUT, 
                Actions.CHANGE_MAP, 
                "./Assets/Maps/DebugMAP.png");
            
            Engine.bus.Mqueue.Enqueue(startMapMessage);
            
        }

        public static void Update()
        {
            bool running = true;
            while (running)
            {
                Logic.Update();
            }
        }
    }
}