using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;
using Game.Maps;


namespace CLIPixelEngine.Engine
{
  public class Engine
  {
    public static MessageBus bus = new MessageBus();
    public static Dictionary<string, List<Entity>> entities = new Dictionary<string, List<Entity>>();
    public static Dictionary<string, Overlay> overlays = new Dictionary<string, Overlay>();
    public static List<string> activeOverlays = new List<string>();
    public static Renderer renderer = new Renderer();
    public static Camera camera = new Camera();
    public static Logic logicEngine = new Logic();
    public static MessageLinker messageLinker = new MessageLinker();
    public static MessageReceiver messageReceiver = new MessageReceiver();
    public static Logger logger = new Logger();


    /// <summary>
    /// start the engine and contained the required setup to start the game
    /// </summary>
    public static void StartEngine()
    {
      //setup
      Console.Clear();
      logger.CreateLogFile();
      overlays["main menu"] = new Overlay("main menu","./Assets/Scene/StartMenu.png");
      camera.Fov = new Vector2Int(20, 42);
      renderer.SetMap(MapsHandler.GetMap(MapsHandler.MapKeys.BIG_DEBUG_MAP));
      renderer.PutCameraAt(new Vector2Int(64, 64));
      entities["player"] = new List<Entity>();
      entities["enemy"] = new List<Entity>();
      entities["items"] = new List<Entity>();
      
      activeOverlays.Add("main menu");

      entities["player"].Add(new Entity(new Vector2Int(64, 64), "purple_warrior.png"));
      entities["enemy"].Add(new Entity(new Vector2Int(64, 100) , "Blubble.png"));

      Console.Clear();
      renderer.Draw();
      Input.Start();
    }
  }
}