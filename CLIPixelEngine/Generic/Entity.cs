using System.Drawing;

namespace CLIPixelEngine.Engine.Generic
{
    public class Entity
    {
        public Vector2 Position;
        public Bitmap Sprite;
        public Scripts Scripts;

        public Entity()
        {
            Position = new Vector2(0, 0);
            Sprite = new Bitmap("./Assets/Sprites/debugSprite.png");
            Scripts = null;
        }
    }
}