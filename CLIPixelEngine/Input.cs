using CLIPixelEngine.Engine.Bus;

namespace CLIPixelEngine.Engine;

public class Input
{
  public static async void Start()
  {
    var keyinfo = new ConsoleKeyInfo();
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
        case ConsoleKey.E:
          Engine.bus.AddMessage(ActionType.INPUT, Actions.BUTTON_PRESS, "E");
          break;
        case ConsoleKey.Enter:
          if (Engine.activeOverlays.Contains("main menu"))
          {
            Engine.activeOverlays.Remove("main menu");
            Engine.renderer.Draw();
          }

          break;
      }
    } while (keyinfo.Key != ConsoleKey.Escape);
  }
}