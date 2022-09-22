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
    private Map _map;
    private static int _mode;

    private int _startAtX;
    private int _endAtX;

    private int _startAtY;
    private int _endAtY;

    private string _frame;


    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GetConsoleMode(IntPtr handle, out int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(int handle);

    private static void SetupConsole()
    {
      _handle = GetStdHandle(-11);
      GetConsoleMode(_handle, out _mode);
      SetConsoleMode(_handle, _mode | 0x4);
    }

    static Bitmap GetMap(string pathToMap) => new Bitmap(pathToMap);
    public void SetMap(Map map) => _map = map;
    public void PutCameraAt(Vector2Int position) => Engine.camera.Position = position;
    
    public Task Draw()
    {
      Console.Clear();
      ConsoleHelper.SetCurrentFont("Consolas", 10);

      Bitmap Map = GetMap(_map.Path);
      if (_handle == IntPtr.Zero) SetupConsole();

      // Draw enemy and my sprites
      DrawEntities(Map);

      // Clear frame to redraw the new updated map
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
      

      for (int x = _startAtX; x < _endAtX; x++)
      {
        for (int y = _startAtY; y < _endAtY; y++)
        {
          byte r = Map.GetPixel(y, x).R;
          byte g = Map.GetPixel(y, x).G;
          byte b = Map.GetPixel(y, x).B;

          _frame += "\x1b[48;2;" + r + ";" + g + ";" + b + "m  ";
        }

        _frame += "\x1b[48;2;" + 0 + ";" + 0 + ";" + 0 + "m\n";
      }
      Console.Clear();
      Console.Write(_frame);

      return Task.CompletedTask;
    }

    public void DrawEntities(Bitmap Map)
    {
      const int sizeOfSprite = 8;
      foreach (var entity in Engine.entities)
      {
        for (int x = 0; x < sizeOfSprite; x++)
        {
          for (int y = 0; y < sizeOfSprite; y++)
          {
            if (entity.Position.x - 4 + x < _map.Size.x
                && entity.Position.y - 4 + y < _map.Size.y
                && entity.Position.x + 4 + x > 0
                && entity.Position.y + 4 + y > 0)
            {
              Color spriteColor = entity.Sprite.GetPixel(x, y);
              if (spriteColor.R != 0 || spriteColor.G != 0 || spriteColor.B != 0)
              {
                Map.SetPixel(entity.Position.x - 4 + x, entity.Position.y - 4 + y, spriteColor);
              }
            }
          }
        }
      }
    }
  }
}