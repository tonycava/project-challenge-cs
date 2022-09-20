using System.Drawing;

namespace CLIPixelEngine.Engine.Generic
{
    public class Entity
    {
        public Vector2 position;
        public Bitmap sprite;
        public Scipts script;

        public Entity()
        {
            position = new Vector2(0, 0);
            sprite = new Bitmap()
        }
    }
}