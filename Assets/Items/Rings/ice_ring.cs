using System.Drawing;

namespace Game.EntityHandler.Items.Rings;

public class ice_ring : Equipment
{
    public override Bitmap sprite { get { return new Bitmap("./Assets/Items/Rings/ice_ring.png"); } }
    public int damage_bonus { get {return 5;} }
    public int defense_bonus { get {return 5;} }

    public ice_ring()
    {
        
    }
}
