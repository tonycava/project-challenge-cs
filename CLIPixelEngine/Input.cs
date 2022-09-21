using System;
using CLIPixelEngine.Engine.Bus;

namespace CLIPixelEngine.Engine
{
    public class Input
    {
        public async void Start()
        {
            ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();
            do
            {
                keyinfo = Console.ReadKey();
                switch (keyinfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        Engine.bus.AddMessage(ActionType.INPUT,Actions.BUTTON_PRESS,"up arrow");
                        break;
                    case ConsoleKey.RightArrow:
                        Engine.bus.AddMessage(ActionType.INPUT,Actions.BUTTON_PRESS,"right arrow");
                        break;
                    case ConsoleKey.DownArrow:
                        Engine.bus.AddMessage(ActionType.INPUT,Actions.BUTTON_PRESS,"down arrow");
                        break;
                    case ConsoleKey.LeftArrow:
                        Engine.bus.AddMessage(ActionType.INPUT,Actions.BUTTON_PRESS,"left arrow");
                        break;
                }
            } while (keyinfo.Key != ConsoleKey.Escape);
        }
    }
}