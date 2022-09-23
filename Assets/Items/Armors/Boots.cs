using System.Drawing;

namespace Game.EntityHandler.Items.Armors;

public class Boots : Equipment
{
    public Bitmap sprite
    {
        get { return new Bitmap("./Assets/Items/Armors/Boots.png"); }
    }
    public int damage_bonus { get {return 5;} }
    public int defense_bonus { get {return 5;} }

    public Boots()
    {

    }
}