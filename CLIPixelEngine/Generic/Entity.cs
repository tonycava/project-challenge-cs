using System.Drawing;
using Game.Test;

namespace CLIPixelEngine.Engine.Generic
{
  public class Entity
  {
    public Vector2Int Position;
    public Bitmap Sprite;

    public int Rotation;
    public bool invertX = false;

    public Enemy.EnemyStats Script;

    public Entity()
    {
      Position = new Vector2Int(0, 0);
      Sprite = new Bitmap("./Assets/Sprites/debugSprite.png");
      Rotation = 0;
    }

    public Entity(Vector2Int position, string path, Enemy.EnemyStats script)
    {
      Position = new Vector2Int(position.x, position.y);
      Sprite = new Bitmap("./Assets/Sprites/" + path);
      Rotation = 0;
      Script = script;
    }
  }
}