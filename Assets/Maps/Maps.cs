using CLIPixelEngine.Engine.Generic;

namespace Game.Maps
{
  public class Map
  {
    private const string _mapPath = "./Assets/Maps/";
  
    public string Path;
    public string ColPath = "";
    public Vector2Int Size;
    

    public Map()
    {
      Path = _mapPath + "DebugMap/map.png";
      Size = new Vector2Int(32, 32);
    }

    public Map(string name, Vector2Int size)
    {
      Path = _mapPath + name + "/map.png";
      Size = size;
      ColPath = _mapPath + name + "/collision.png";
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
          return new Map("DebugMAP", new Vector2Int(32, 32));
        
        case MapKeys.BIG_DEBUG_MAP:
          return new Map("BigDebugMAP", new Vector2Int(128, 128));
        
        default:
          return new Map("DebugMAP", new Vector2Int(32, 32));
      }
    }
  }
}