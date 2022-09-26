using System.Drawing;

namespace CLIPixelEngine.Engine.Generic;

public class Overlay
{
  public Bitmap Image;
  public string Name;

  public Overlay(string name, string path)
  {
    Image = new Bitmap(path);
    Name = name;
  }
}