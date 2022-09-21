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

      int StartAtX = Engine.camera.Position.x - Engine.camera.Fov.x;
      int EndAtX = Engine.camera.Position.x + Engine.camera.Fov.x;


      int StartAtY = Engine.camera.Position.y - Engine.camera.Fov.y;
      int EndAtY = Engine.camera.Position.y + Engine.camera.Fov.y;
      
      EndAtX = EndAtX > _map.Size.y ? _map.Size.y : EndAtX;
      StartAtX = EndAtX == _map.Size.y ? _map.Size.y - Engine.camera.Fov.x * 2 : StartAtX;

      EndAtY = EndAtY > _map.Size.x ? _map.Size.x : EndAtY;
      StartAtY = EndAtY == _map.Size.x ? _map.Size.x - Engine.camera.Fov.y * 2 : StartAtY;

      StartAtX = StartAtX < 0 ? 0 : StartAtX;
      EndAtX = StartAtX == 0 ? StartAtX + Engine.camera.Fov.x * 2 : EndAtX;
      
      StartAtY = StartAtY < 0 ? 0 : StartAtY;
      EndAtY = StartAtY == 0 ? StartAtY + Engine.camera.Fov.y * 2 : EndAtY;

      DrawEntities(Map);

      string frame = "";

      for (int x = StartAtX; x < EndAtX; x++)
      {
        for (int y = StartAtY; y < EndAtY; y++)
        {
          byte r = Map.GetPixel(y, x).R;
          byte g = Map.GetPixel(y, x).G;
          byte b = Map.GetPixel(y, x).B;

          frame += "\x1b[48;2;" + r + ";" + g + ";" + b + "m  ";
        }

        frame += "\x1b[48;2;" + 0 + ";" + 0 + ";" + 0 + "m\n";
      }
      Console.Write(frame);
      Console.Write(frame.Length);

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

    public void SetMap(Map map)
    {
      _map = map;
    }
  }
}