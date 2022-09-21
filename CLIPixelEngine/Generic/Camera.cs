using CLIPixelEngine.Engine.Generic;

namespace CLIPixelEngine.Engine.Generic {
  public class Camera
  {
    public Vector2Int Position;
    public int Fov;

    public Camera()
    {
      Position = new Vector2Int(0, 0);
      Fov = 16;
    }

    public Camera(Vector2Int position,int fov)
    {
      Position = position;
      Fov = fov;
    }

    public void ChangeFov(int fov)
    {
      Fov = fov;
    }

    public void ChangePos(Vector2Int position)
    {
      Position = position;
    }
  }
}