using System.Drawing;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CLIpixelEngine.Engine.Bus;
using CLIpixelEngine.Engine.Generic;
using Color = CLIpixelEngine.Engine.Generic.Color;

namespace CLIpixelEngine.Engine.Render {
	public class Renderer {

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

		static Bitmap GetMap()
		{
	    	//TODO: return selected map
			return new Bitmap("./Assets/map.png");
		}

		public static void Draw()
		{
			//TODO: GET MAP
			Bitmap Map = GetMap();

			if(handle == IntPtr.Zero)SetupConsole();

			for (int x = 0; x < Map.Width;	 x++)
			{
				for (int y = 0; y < Map.Height; y++)
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
	}
}