using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace Game.EntityHandler.Scene
{
  public class StartGame
  {
    
    public static IntPtr _handle;
    private static int _mode;
    
    private static string _frame;
    
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
    
    
    public static void StartMenu()
    {
      if (_handle == IntPtr.Zero) SetupConsole();

      Bitmap start = new Bitmap("./Assets/Scene/startGame.png");

      for (int x = 0; x < start.Height; x++)
      {
        for (int y = 0; y < start.Width; y++)
        {
          byte r = start.GetPixel(y, x).R;
          byte g = start.GetPixel(y, x).G;
          byte b = start.GetPixel(y, x).B;

          _frame += "\x1b[48;2;" + r + ";" + g + ";" + b + "m  ";
        }
        _frame += "\x1b[48;2;" + 0 + ";" + 0 + ";" + 0 + "m\n";
      }
      
      Console.Write(_frame);
      Console.Write("Hello enter a class :");
      
      string classes = Console.ReadLine();
      
      Console.Clear();
    }
  }
}