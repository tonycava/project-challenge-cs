using System.Drawing;

namespace Game.EntityHandler.Items.Rings;

public class fire_ring : Equipment
{
    public override Bitmap sprite
    {
        get { return new Bitmap("./Assets/Items/Rings/fire_ring.png"); }
    }
    public int damage_bonus { get {return 5;} }
    public int defense_bonus { get {return 5;} }

    public fire_ring()
    {

    }
}