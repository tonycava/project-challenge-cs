namespace CLIPixelEngine.Engine.Generic;

public class Camera
{
  public Vector2Int Fov;
  public Vector2Int Position;

  public Camera()
  {
    Position = new Vector2Int();
    Fov = new Vector2Int(16, 9);
  }

  public Camera(Vector2Int position, Vector2Int fov)
  {
    Position = position;
    Fov = fov;
  }

  public void ChangeFov(Vector2Int fov)
  {
    Fov = fov;
  }

  public void ChangePos(Vector2Int position)
  {
    Position = position;
  }
}