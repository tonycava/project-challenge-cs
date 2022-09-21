using System.Drawing;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
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

    private Camera _camera;
    private Map _map;

    public void SetupCamera(Camera camera)
    {
      _camera = camera;
    }

    public void PutCameraAt(Vector2Int position)
    {
      _camera.Position = position;
    }

    public void Draw()
    {
      ConsoleHelper.FontInfo info = new ConsoleHelper.FontInfo();
      ConsoleHelper.SetCurrentFont("Consolas", 10);

      Bitmap Map = GetMap(_map.Path);

      if (handle == IntPtr.Zero) SetupConsole();

      int StartAtX = _camera.Position.x - _camera.Fov < 0 ? 0 : _camera.Position.x - _camera.Fov;
      int EndAtX = _camera.Position.x + _camera.Fov > _map.Size.x ? _map.Size.x : _camera.Position.x + _camera.Fov;

      int StartAtY = _camera.Position.y - _camera.Fov < 0 ? 0 : _camera.Position.y - _camera.Fov;
      int EndAtY = _camera.Position.y + _camera.Fov > _map.Size.y ? _map.Size.y : _camera.Position.y + _camera.Fov;

      Console.Write(Color.Black);

      foreach (var entity in Engine.entities)
      {
        for (int x = 0; x < 8; x++)
        {
          for (int y = 0; y < 8; y++)
          {
            Color spriteColor = entity.Sprite.GetPixel(x, y);
            Console.Write(spriteColor);
            if (spriteColor.R != 0 || spriteColor.G != 0 || spriteColor.B != 0)
            {
               Map.SetPixel(entity.Position.x - 4 + x, entity.Position.y - 4 + y, spriteColor);
            }
          }
        }
      }


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
    }

    public void SetMap(Map map)
    {
      _map = map;
    }
  }
}