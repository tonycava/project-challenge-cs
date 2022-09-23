using System.Collections.Generic;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;
using Game.Maps;


namespace CLIPixelEngine.Engine
{
  public class Engine
  {
    public static MessageBus bus = new MessageBus();
    public static Dictionary<string, Entity> entities = new Dictionary<string, Entity>();
    public static Renderer renderer = new Renderer();
    public static Camera camera = new Camera();
    public static Logic logicEngine = new Logic();
    public static MessageLinker messageLinker = new MessageLinker();
    public static MessageReceiver messageReceiver = new MessageReceiver();
    public static Logger logger = new Logger();


    public static void StartEngine()
    {
      logger.CreateLogFile();

      camera.Fov = new Vector2Int(20, 42);

      renderer.SetMap(MapsHandler.GetMap(MapsHandler.MapKeys.BIG_DEBUG_MAP));

      renderer.PutCameraAt(new Vector2Int(64, 64));

      entities.Add("player", new Entity(new Vector2Int(64, 64), "purple_warrior.png", 0));


      entities.Add("enemy", new Entity(new Vector2Int(70, 90), "Blubble.png", 1));

      renderer.Draw();
      Input.Start();
    }
  }
}