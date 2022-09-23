using System.Drawing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;
using Game.Maps;

namespace CLIPixelEngine.Engine
{
  public class Renderer
  {
    public static IntPtr _handle;
    public Map _map;
    private static int _mode;

    private int _startAtX;
    private int _endAtX;

    private int _startAtY;
    private int _endAtY;

    private string _frame;
    
    public bool IsInCombat;
    public int Life = 90;

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GetConsoleMode(IntPtr handle, out int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(int handle);

    /// <summary>
    /// Create an handle to the console to use colors
    /// </summary>
    private static void SetupConsole()
    {
      _handle = GetStdHandle(-11);
      GetConsoleMode(_handle, out _mode);
      SetConsoleMode(_handle, _mode | 0x4);
    }

    /// <summary>
    /// Create the Bitmap of the selected map
    /// </summary>
    /// <param name="pathToMap">the name of the map directory</param>
    /// <returns>return the bitmap of the map</returns>
    static Bitmap GetMap(string pathToMap) => new Bitmap(pathToMap);

    /// <summary>
    /// Select the map to use
    /// </summary>
    /// <param name="map">name of the map directory</param>
    public void SetMap(Map map) => _map = map;

    /// <summary>
    /// set camera to a new position
    /// </summary>
    /// <param name="position">Vector2Int of the new position</param>
    public void PutCameraAt(Vector2Int position) => Engine.camera.Position = position;

    /// <summary>
    /// Draw the current frame
    /// </summary>
    /// <returns></returns>
    public Task Draw()
    {
      //Console.Clear();
      ConsoleHelper.SetCurrentFont("Consolas", 10);

      Bitmap Map = GetMap(_map.Path);
      if (_handle == IntPtr.Zero) SetupConsole();

      // Draw enemy and my sprites
      DrawEntities(Map);
      
      // Clear frame to redraw the new updated map
      Console.CursorTop = 0;
      _frame = "";

      _startAtX = Engine.camera.Position.x - Engine.camera.Fov.x;
      _endAtX = Engine.camera.Position.x + Engine.camera.Fov.x;

      _startAtY = Engine.camera.Position.y - Engine.camera.Fov.y;
      _endAtY = Engine.camera.Position.y + Engine.camera.Fov.y;

      _endAtX = _endAtX > _map.Size.y ? _map.Size.y : _endAtX;
      _startAtX = _endAtX == _map.Size.y ? _map.Size.y - Engine.camera.Fov.x * 2 : _startAtX;

      _endAtY = _endAtY > _map.Size.x ? _map.Size.x : _endAtY;
      _startAtY = _endAtY == _map.Size.x ? _map.Size.x - Engine.camera.Fov.y * 2 : _startAtY;

      _startAtX = _startAtX < 0 ? 0 : _startAtX;
      _endAtX = _startAtX == 0 ? _startAtX + Engine.camera.Fov.x * 2 : _endAtX;

      _startAtY = _startAtY < 0 ? 0 : _startAtY;
      _endAtY = _startAtY == 0 ? _startAtY + Engine.camera.Fov.y * 2 : _endAtY;
      
      DrawOverlay(Map,_startAtX,_startAtY);
      
      
      
      for (int y = _startAtX; y < _endAtX; y++)
      {
        for (int x = _startAtY; x < _endAtY; x++)
        {
        
          byte r = Map.GetPixel(x, y).R;
          byte g = Map.GetPixel(x, y).G;
          byte b = Map.GetPixel(x, y).B;

          _frame += "\x1b[48;2;" + r + ";" + g + ";" + b + "m  ";
        }

        _frame += "\x1b[48;2;" + 0 + ";" + 0 + ";" + 0 + "m\n";
      }
      
      Console.Write(_frame);
      return Task.CompletedTask;
    }
    
    
    private bool _invertX = false;
    /// <summary>
    /// Draw all entities that are present in the Engine.entities list
    /// </summary>
    /// <param name="Map">the current map</param>
    public void DrawEntities(Bitmap map)
    {
      foreach (var list in Engine.entities)
      {
        foreach (var entity in list.Value)
        {
          DrawEntity(map,entity);
        }
      }
    }

    public void DrawEntity(Bitmap map, Entity entity)
    {
      for (int x = 0; x < 8; x++)
      {
        for (int y = 0; y < 8; y++)
        {
          _invertX = entity.Rotation == 3 ? true : _invertX;
          _invertX = entity.Rotation == 1 ? false : _invertX;

          if (entity != Engine.entities["player"][0])
          {
            Engine.logger.Log("blubber rotation = " + entity.Rotation +"\n");
          }
          
          //Check if pixel is OOB
          if (entity.Position.x - 4 + x < _map.Size.x
              && entity.Position.y - 4 + y < _map.Size.y
              && entity.Position.x - 3 + x > 0
              && entity.Position.y - 3 + y > 0)
          {
            Color spriteColor = entity.Sprite.GetPixel(_invertX ? 7 - x : 0 + x, y);
            if (spriteColor.R != 0 || spriteColor.G != 0 || spriteColor.B != 0)
            {
              map.SetPixel(entity.Position.x - 4 + x
                ,entity.Position.y - 3 + y
                ,spriteColor);
            }
          }
        }
      }
    }

    public void DrawOverlay(Bitmap map,int startX,int startY)
    {
      Bitmap overlay;
      foreach (var overlayName in Engine.activeOverlays)
      {
        overlay = Engine.overlays[overlayName].Image;
        for (int y = 0; y < Engine.camera.Fov.x*2;y ++)
        {
          for (int x = 0; x < Engine.camera.Fov.y*2; x++)
          {
            Color spriteColor = overlay.GetPixel(x,y);
            if (spriteColor.R != 0 || spriteColor.G != 0 || spriteColor.B != 0)
            {
              map.SetPixel(startY + x,startX + y,spriteColor);
            }
          }
        }
      }
    }
  }
}