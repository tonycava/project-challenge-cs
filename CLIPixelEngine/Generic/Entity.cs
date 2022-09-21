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

        public Entity(Vector2 position,string name,Scripts script)
        {
            this.position = new Vector2(0, 0);
            this.sprite = new Bitmap("./Assets/Sprites/" + name);
            this.script = null;
        }
    }
}