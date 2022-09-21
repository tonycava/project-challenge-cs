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
    public static IntPtr handle;

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GetConsoleMode(IntPtr handle, out int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(int handle);

    private static void SetupConsole()
    {
      handle = GetStdHandle(-11);
      int mode;
      GetConsoleMode(handle, out mode);
      SetConsoleMode(handle, mode | 0x4);
    }

    static Bitmap GetMap(string pathToMap)
    {
      return new Bitmap(pathToMap);
    }
    
    private Map _map;
    
    public void PutCameraAt(Vector2Int position)
    {
      Engine.camera.Position = position;
    }
    
    public Task Draw()
    {
      Console.Clear();
      
      ConsoleHelper.FontInfo info = new ConsoleHelper.FontInfo();
      ConsoleHelper.SetCurrentFont("Consolas", 10);
      Bitmap Map = GetMap(_map.Path);

      if (handle == IntPtr.Zero) SetupConsole();

      
      int StartAtX = Engine.camera.Position.x - Engine.camera.Fov.x < 0 ?
        0 : Engine.camera.Position.x - Engine.camera.Fov.x;
      int EndAtX = Engine.camera.Position.x + Engine.camera.Fov.x > _map.Size.x ?
        _map.Size.x : Engine.camera.Position.x + Engine.camera.Fov.x;

      
      int StartAtY = Engine.camera.Position.y - Engine.camera.Fov.y < 0 ? 
        0 : Engine.camera.Position.y - Engine.camera.Fov.y;
      
      int EndAtY = Engine.camera.Position.y + Engine.camera.Fov.y > _map.Size.y ?
        _map.Size.y : Engine.camera.Position.y + Engine.camera.Fov.y;
      
      // StartAtX = StartAtX + Engine.camera.Fov.x * 2 < _map.Size.x ?
      //   StartAtX : _map.Size.x - Engine.camera.Fov.x * 2;
      // EndAtX = EndAtX > _map.Size.x ? _map.Size.x : EndAtX;
      //
      // StartAtY = StartAtY + Engine.camera.Fov.y * 2 < _map.Size.y ?
      //   StartAtY : _map.Size.y - Engine.camera.Fov.y * 2;
      // EndAtX = EndAtY > _map.Size.y ? _map.Size.y : EndAtY;
      
      
      DrawEntities(Map);
      
      for (int x = StartAtX; x < EndAtX; x++)
      {
        for (int y = StartAtY; y < EndAtY; y++)
        {
          byte r = Map.GetPixel(y, x).R;
          byte g = Map.GetPixel(y, x).G;
          byte b = Map.GetPixel(y, x).B;

          Console.Write("\x1b[48;2;" + r + ";" + g + ";" + b + "m  ");
        }

        Console.Write("\x1b[48;2;" + 0 + ";" + 0 + ";" + 0 + "m");
        Console.Write("\n");
      }
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
            Color spriteColor = entity.Sprite.GetPixel(x, y);
            if (spriteColor.R != 0 || spriteColor.G != 0 || spriteColor.B != 0)
            {
              Map.SetPixel(entity.Position.x - 4 + x, entity.Position.y - 4 + y, spriteColor);
            }
          }
        }
      }
    }
    
    public void SetMap(Map map)
    {
      _map = map;
    }
  }
}