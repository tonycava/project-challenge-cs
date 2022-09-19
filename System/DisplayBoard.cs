using System.Drawing;
using System;
using System.Runtime.InteropServices;
using Project_CS;
using Project_CS.Data;
using Color = Project_CS.Data.Color;

namespace Game.Engine
{
  public class Board
  {
    public enum CharacterAttributes
    {
      FOREGROUND_BLUE = 0x0001,
      FOREGROUND_GREEN = 0x0002,
      FOREGROUND_RED = 0x0004,
      FOREGROUND_INTENSITY = 0x0008,
      BACKGROUND_BLUE = 0x0010,
      BACKGROUND_GREEN = 0x0020,
      BACKGROUND_RED = 0x0040,
      BACKGROUND_INTENSITY = 0x0080,
      COMMON_LVB_LEADING_BYTE = 0x0100,
      COMMON_LVB_TRAILING_BYTE = 0x0200,
      COMMON_LVB_GRID_HORIZONTAL = 0x0400,
      COMMON_LVB_GRID_LVERTICAL = 0x0800,
      COMMON_LVB_GRID_RVERTICAL = 0x1000,
      COMMON_LVB_REVERSE_VIDEO = 0x4000,
      COMMON_LVB_UNDERSCORE = 0x8000,
    }
    
    private static bool _isFirstTime = true;
    private static string _Username = "";

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool SetConsoleTextAttribute(IntPtr hConsoleOutput, CharacterAttributes wAttributes);

    [DllImport("kernel32.dll")]
    private static extern IntPtr GetStdHandle(int nStdHandle);

    protected static void DisplayGame()
    {
      if (_isFirstTime)
      {
        Console.Write("Enter username: ");
        _Username = Console.ReadLine();
        _isFirstTime = false;
      }

      Bitmap imageLevel = new Bitmap("./Assets/map.png");

      for (int x = 0; x < imageLevel.Width; x++)
      {
        for (int y = 0; y < imageLevel.Height; y++)
        {
          byte r = imageLevel.GetPixel(x, y).R;
          byte g = imageLevel.GetPixel(x, y).G;
          byte b = imageLevel.GetPixel(x, y).B;

          CharacterAttributes nearest = new Color(r, g, b).getCharacterAttributes();

          if (nearest == CharacterAttributes.FOREGROUND_BLUE)
            nearest = CharacterAttributes.BACKGROUND_INTENSITY;

          Write("  ", nearest);
        }

        Console.WriteLine("\t");
      }

      static void Write(string str, CharacterAttributes wAttributes)
      {
        SetConsoleTextAttribute(GetStdHandle(-11), wAttributes);
        Console.Write(str);
      }
    }
  }
};