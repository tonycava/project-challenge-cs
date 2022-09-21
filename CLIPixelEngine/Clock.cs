using CLIPixelEngine.Engine.Bus;

namespace CLIPixelEngine.Engine
{
    public class Clock
    {
        public void Start()
        {
            // Message startMapMessage = new Message(
            //     ActionType.INPUT, 
            //     Actions.CHANGE_MAP, 
            //     "./Assets/Maps/DebugMap/DebugMap.png");
            // Engine.bus.Mqueue.Enqueue(startMapMessage);
        }

        public void Update()
        {
            Engine.logicEngine.Update();
        }
    }
}