﻿using System.ComponentModel;
using System.Runtime.InteropServices;

namespace CLIPixelEngine.Engine.Generic;

public static class ConsoleHelper
{
  private const int FixedWidthTrueType = 54;
  private const int StandardOutputHandle = -11;


  private static readonly IntPtr ConsoleOutputHandle = GetStdHandle(StandardOutputHandle);

  [DllImport("kernel32.dll", SetLastError = true)]
  internal static extern IntPtr GetStdHandle(int nStdHandle);

  [return: MarshalAs(UnmanagedType.Bool)]
  [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
  internal static extern bool SetCurrentConsoleFontEx(IntPtr hConsoleOutput, bool MaximumWindow,
    ref FontInfo ConsoleCurrentFontEx);

  [return: MarshalAs(UnmanagedType.Bool)]
  [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
  internal static extern bool GetCurrentConsoleFontEx(IntPtr hConsoleOutput, bool MaximumWindow,
    ref FontInfo ConsoleCurrentFontEx);

  public static FontInfo[] SetCurrentFont(string font, short fontSize = 0)
  {
    var before = new FontInfo
    {
      cbSize = Marshal.SizeOf<FontInfo>()
    };

    if (GetCurrentConsoleFontEx(ConsoleOutputHandle, false, ref before))
    {
      var set = new FontInfo
      {
        cbSize = Marshal.SizeOf<FontInfo>(),
        FontIndex = 0,
        FontFamily = FixedWidthTrueType,
        FontName = font,
        FontWeight = 400,
        FontSize = fontSize > 0 ? fontSize : before.FontSize
      };

      // Get some settings from current font.
      if (!SetCurrentConsoleFontEx(ConsoleOutputHandle, false, ref set))
      {
        var ex = Marshal.GetLastWin32Error();
        Console.WriteLine("Set error " + ex);
        throw new Win32Exception(ex);
      }

      var after = new FontInfo
      {
        cbSize = Marshal.SizeOf<FontInfo>()
      };
      GetCurrentConsoleFontEx(ConsoleOutputHandle, false, ref after);

      return new[] {before, set, after};
    }

    var er = Marshal.GetLastWin32Error();
    Console.WriteLine("Get error " + er);
    throw new Win32Exception(er);
  }

  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
  public struct FontInfo
  {
    internal int cbSize;
    internal int FontIndex;
    internal short FontWidth;
    public short FontSize;
    public int FontFamily;
    public int FontWeight;

    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
    //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.wc, SizeConst = 32)]
    public string FontName;
  }
}