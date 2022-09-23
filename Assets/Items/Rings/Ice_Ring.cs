using System.Drawing;

namespace Game.EntityHandler.Items.Rings;

public class IceRing : Equipment
{
    public override Bitmap sprite { get { return new Bitmap("./Assets/Items/Rings/Ice_Ring.png"); } }
    public int damage_bonus { get {return 5;} }
    public int defense_bonus { get {return 5;} }

    public IceRing()
    {
        
    }
}
