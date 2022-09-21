using System.Drawing;

namespace CLIPixelEngine.Engine.Generic
{
  public class Entity
  {
    public Vector2 Position;
    public Bitmap Sprite;
    public Scripts Script;

    public Entity()
    {
      Position = new Vector2(0, 0);
      Sprite = new Bitmap("./Assets/Sprites/debugSprite.png");
      Script = null;
    }

    public Entity(Vector2 position, string name, Scripts script)
    {
      Position = new Vector2(0, 0);
      Sprite = new Bitmap("./Assets/Sprites/" + name);
      Script = null;
    }
  }
}