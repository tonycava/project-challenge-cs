using System;

namespace CLIPixelEngine.Engine.Generic
{
  public class Calc
  {
    public static double Distance(Vector2Int a, Vector2Int b)
    {
      Vector2Int diff = new Vector2Int(a.x - b.x, a.y - b.y);
      double sqrdDistance = diff.x * diff.x + diff.y * diff.y;
      return Math.Sqrt(sqrdDistance);
    }
    
    public static double Distance(Vector2 a, Vector2 b)
    {
      Vector2 diff = new Vector2(a.x - b.x, a.y - b.y);
      return Math.Sqrt(diff.x * diff.x + diff.y * diff.y);
    }

    public static double DotProduct(Vector2Int a, Vector2Int b)
    {
      return (a.x * b.x + a.y * b.y) / (Math.Sqrt(a.x * a.x + a.y * a.y) * Math.Sqrt(b.x * b.x + b.y * b.y));
    }
    
    public static double DotProduct(Vector2 a, Vector2 b)
    {
      return (a.x * b.x + a.y * b.y) / (Math.Sqrt(a.x * a.x + a.y * a.y) * Math.Sqrt(b.x * b.x + b.y * b.y));
    }
  }
}