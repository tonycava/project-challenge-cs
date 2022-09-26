namespace CLIPixelEngine.Engine.Generic;

public class Calc
{
  public static double Distance(Vector2Int a, Vector2Int b)
  {
    var diff = new Vector2Int(a.x - b.x, a.y - b.y);
    double sqrdDistance = diff.x * diff.x + diff.y * diff.y;
    return Math.Sqrt(sqrdDistance);
  }

  public static double Distance(Vector2 a, Vector2 b)
  {
    var diff = new Vector2(a.x - b.x, a.y - b.y);
    return Math.Sqrt(diff.x * diff.x + diff.y * diff.y);
  }

  public static double DistanceToBox(Vector2Int p, Vector2Int box, Vector2Int boxSize)
  {
    var dist = new Vector2Int(Math.Abs(p.x - box.x), Math.Abs(p.y - box.y));
    double dx = dist.x - boxSize.x;
    double dy = dist.y - boxSize.y;
    return Math.Max(dx, dy);
  }

  public static double DistanceToBox(Vector2 p, Vector2 box, Vector2 boxSize)
  {
    var dist = new Vector2(Math.Abs(p.x - box.x), Math.Abs(p.y - box.y));
    double dx = Math.Min(dist.x + boxSize.x, dist.x - boxSize.x);
    double dy = Math.Min(dist.y + boxSize.y, dist.y - boxSize.y);
    return Math.Min(dx, dy);
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