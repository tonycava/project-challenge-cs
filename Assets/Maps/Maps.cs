using CLIPixelEngine.Engine.Generic;

namespace Game.Maps
{
  public class Map
  {
    public string Path;
    public Vector2Int Size;

    public Map()
    {
      Path = "./Assets/Maps/DebugMAP/DebugMAP.png";
      Size = new Vector2Int(32, 32);
    }

    public Map(string path, Vector2Int size)
    {
      Path = path;
      Size = size;
    }
  }

  public class MapsHandler
  {
    public enum MapKeys
    {
      DEBUG_MAP,
      BIG_DEBUG_MAP,
    }

    public static Map GetMap(MapKeys key)
    {
      switch (key)
      {
        case MapKeys.DEBUG_MAP:
          return new Map("./Assets/Maps/DebugMAP/DebugMAP.png", new Vector2Int(32, 32));
        
        case MapKeys.BIG_DEBUG_MAP:
          return new Map("./Assets/Maps/BigDebugMAP/BigDebugMAP.png", new Vector2Int(128, 128));
        
        default:
          return new Map("./Assets/Maps/DebugMAP/DebugMAP.png", new Vector2Int(32, 32));
      }
    }
  }
}