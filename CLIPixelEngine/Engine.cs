using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;
using Game.EntityHandler.Items;
using Game.Maps;
using Game.Test;


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
      logger.CreateLogFile();
      new EquipmentManager();

      overlays["main menu"] = new Overlay("main menu", "./Assets/Scene/StartMenu.png");
      overlays["inventory"] = new Overlay("inventory", "./Assets/Sprites/Inventory.png");

      camera.Fov = new Vector2Int(20, 42);

      renderer.SetMap(MapsHandler.GetMap(MapsHandler.MapKeys.BIG_DEBUG_MAP));

      renderer.PutCameraAt(new Vector2Int(64, 64));

      entities["player"] = new List<Entity> {new Character(new Vector2Int(64, 64), "purple_warrior.png")};
      entities["enemy"] = new List<Entity> {new Blubble(new Vector2Int(64, 100), "Blubble.png")};
      entities["items"] = new List<Entity>();

      activeOverlays.Add("main menu");
      
      var aTimer = new System.Timers.Timer();
      
      aTimer.Interval = 20 * 1000;
      aTimer.Elapsed += logicEngine.CanSpawnEnemy;
      aTimer.Enabled = true;

      Console.Clear();
      renderer.Draw();
      Input.Start();
    }


  }
}