using System.Drawing;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CLIPixelEngine.Engine.Bus;
using CLIPixelEngine.Engine.Generic;
using Game.EntityHandler.Maps.DebugMAP;

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

    public static void Draw()
    {
      const int fov = 5;
      Vector2Int camera = Camera.cordOfCharacter;
      Vector2Int sizeOfMap = DebugMap.sizeOfMap;


      Bitmap Map = GetMap("./Assets/Maps/DebugMAP/DebugMAP.png");

      if (handle == IntPtr.Zero) SetupConsole();


      int StartAtX = camera.x - fov < 0 ? 0 : camera.x - fov;
      
      int EndAtX = camera.x + sizeOfMap.x > sizeOfMap.x ? sizeOfMap.x : camera.x + sizeOfMap.x;      
      
      
      int StartAtY = camera.y - fov < 0 ? 0 : camera.y - fov;
      
      int EndAtY = camera.y + sizeOfMap.y > sizeOfMap.y ? sizeOfMap.y : camera.y + sizeOfMap.y;

      
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

    public void SetMap(string path)
    {
    }
  }
}