using System;
using System.Collections.Generic;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;

namespace CLIPixelEngine.Engine
{
  
  public class Input
  {
    public async static void Start()
    {
      ConsoleKeyInfo keyinfo = new ConsoleKeyInfo();
      do
      {
        keyinfo = Console.ReadKey();
        switch (keyinfo.Key)
        {
          case ConsoleKey.Z:
            Engine.bus.AddMessage(ActionType.INPUT, Actions.BUTTON_PRESS, "Z");
            break;
          case ConsoleKey.D:
            Engine.bus.AddMessage(ActionType.INPUT, Actions.BUTTON_PRESS, "D");
            break;
          case ConsoleKey.S:
            Engine.bus.AddMessage(ActionType.INPUT, Actions.BUTTON_PRESS, "S");
            break;
          case ConsoleKey.Q:
            Engine.bus.AddMessage(ActionType.INPUT, Actions.BUTTON_PRESS, "Q");
            break;
        }
      } while (keyinfo.Key != ConsoleKey.Escape);
    }
  }
}