using System.Drawing;

namespace CLIPixelEngine.Engine.Generic
{
    public class Entity
    {
        public Vector2 position;
        public Bitmap sprite;
        public Scripts script;

        public Entity()
        {
            position = new Vector2(0, 0);
            sprite = new Bitmap("./Assets/Sprites/debugSprite.png");
            script = null;
        }

        public Entity(Vector2 position,string name,Scripts script)
        {
            this.position = new Vector2(0, 0);
            this.sprite = new Bitmap("./Assets/Sprites/" + name);
            this.script = null;
        }
    }
}