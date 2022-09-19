using System.Drawing;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Project_CS;
using CLIpixelEngine.Engine.Generic;
using Color = CLIpixelEngine.Engine.Generic.Color;

namespace Game.Engine
{
  public class Board
  {
    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool SetConsoleMode(IntPtr hConsoleHandle, int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern bool GetConsoleMode(IntPtr handle, out int mode);

    [DllImport("kernel32.dll", SetLastError = true)]
    public static extern IntPtr GetStdHandle(int handle);

    private static void SetupConsole()
    {
      var handle = GetStdHandle(-11);
      int mode;
      GetConsoleMode(handle, out mode);
      SetConsoleMode(handle, mode | 0x4);
    }

    public static void DisplayGame()
    {
      SetupConsole();

      Bitmap imageLevel = new Bitmap("./Assets/map.png");

      for (int x = 0; x < imageLevel.Width; x++)
      {
        for (int y = 0; y < imageLevel.Height; y++)
        {
          byte r = imageLevel.GetPixel(y, x).R;
          byte g = imageLevel.GetPixel(y, x).G;
          byte b = imageLevel.GetPixel(y, x).B;

          Console.Write("\x1b[48;2;" + r + ";" + g + ";" + b + "m  ");
        }

        ResetColor();
        Console.Write("\n");
      }

      static void ResetColor()
      {
        Console.Write("\x1b[48;2;" + 0 + ";" + 0 + ";" + 0 + "m");
      }
    }
  }
}