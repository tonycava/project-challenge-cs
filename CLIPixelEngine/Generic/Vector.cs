namespace CLIPixelEngine.Engine.Generic;

public class Vector2Int
{
  public Vector2Int(int x = 0, int y = 0)
  {
    this.x = x;
    this.y = y;
  }

  public int x { get; set; }
  public int y { get; set; }
}

public class Vector2
{
  public Vector2(float x = 0, float y = 0)
  {
    this.x = x;
    this.y = y;
  }

  public float x { get; set; }
  public float y { get; set; }
}

public class Vector3Int
{
  public Vector3Int(int x = 0, int y = 0, int z = 0)
  {
    this.x = x;
    this.y = y;
    this.z = z;
  }

  public int x { get; set; }
  public int y { get; set; }
  public int z { get; set; }
}

public class Vector3
{
  public Vector3(float x = 0, float y = 0, float z = 0)
  {
    this.x = x;
    this.y = y;
    this.z = z;
  }

  public float x { get; set; }
  public float y { get; set; }
  public float z { get; set; }
}