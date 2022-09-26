using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;
using Game.EntityHandler.Items;
using Game.Maps;
using Game.Test;
using Timer = System.Timers.Timer;

namespace CLIPixelEngine.Engine;

public class Engine
{
  public static MessageBus bus = new();
  public static Dictionary<string, List<Entity>> entities = new();
  public static Dictionary<string, Overlay> overlays = new();
  public static List<string> activeOverlays = new();
  public static Renderer renderer = new();
  public static Camera camera = new();
  public static Logic logicEngine = new();
  public static MessageLinker messageLinker = new();
  public static MessageReceiver messageReceiver = new();
  public static Logger logger = new();


  /// <summary>
  ///   start the engine and contained the required setup to start the game
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

    var aTimer = new Timer();

    aTimer.Interval = 20 * 1000;
    aTimer.Elapsed += logicEngine.CanSpawnEnemy;
    aTimer.Enabled = true;

    Console.Clear();
    renderer.Draw();
    Input.Start();
  }
}