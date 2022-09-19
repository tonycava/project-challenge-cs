namespace Project_CS.Data;

public struct Color
{
  public static Color RED { get { return new Color(255, 0, 0); } }
  public static Color GREEN { get { return new Color(0, 255, 0); } }
  
  public static Color GRAY { get { return new Color(128, 128, 128); } }
  public static Color BLUE { get { return new Color(0, 0, 255); } }
  
  public static Color WHITE { get { return new Color(0, 0, 0); } }


  public int R;
  public int G;
  public int B;
  
  public Color(int r, int g, int b)
  {
    this.R = r;
    this.G = g;
    this.B = b;
  }
  
  public static bool operator== (Color b, Color c) {
    return Equals(b, c);
  }
  
  public static bool operator!= (Color b, Color c) {
    return !Equals(b, c);
  }

  public override bool Equals(object? obj)
  {
    if (obj == null)
      return false;
    if (obj.GetType() != this.GetType())
      return false;
    Color otherColor = (Color) obj;
    return otherColor.R == R && otherColor.G == G && otherColor.B == B;
  }
}