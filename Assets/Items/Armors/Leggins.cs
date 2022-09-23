using System.Drawing;

namespace Game.EntityHandler.Items.Armors;

public class Leggins : Equipment
{
    public Bitmap sprite
    {
        get { return new Bitmap("./Assets/Items/Armors/Leggins.png"); }
    }
    public int damage_bonus { get {return 5;} }
    public int defense_bonus { get {return 5;} }

    public Leggins()
    {

    }
}