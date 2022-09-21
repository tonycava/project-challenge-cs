using System.Drawing;

namespace CLIPixelEngine.Engine.Generic
{
  public class Entity
  {
    public Vector2Int Position;
    public Bitmap Sprite;
    public Scripts Script;

    public Entity()
    {
      Position = new Vector2Int(0, 0);
      Sprite = new Bitmap("./Assets/Sprites/debugSprite.png");
      Script = null;
    }

    public Entity(Vector2Int position, string name, Scripts script)
    {
      Position = new Vector2Int(position.x, position.y);
      Sprite = new Bitmap("./Assets/Sprites/" + name);
      Script = null;
    }
  }
}