using System.Drawing;

namespace CLIPixelEngine.Engine.Generic;

public class Entity
{
  public bool invertX = false;
  public Vector2Int Position;

  public int Rotation;
  public Bitmap Sprite;

  public Entity()
  {
    Position = new Vector2Int();
    Sprite = new Bitmap("./Assets/Sprites/debugSprite.png");
    Rotation = 0;
  }

  public Entity(Vector2Int position, string path)
  {
    Position = new Vector2Int(position.x, position.y);
    Sprite = new Bitmap("./Assets/Sprites/" + path);
    Rotation = 0;
  }
}