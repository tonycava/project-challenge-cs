using System.Drawing;

namespace Game.EntityHandler.Items.Armors;

public class Chestplate : Equipment
{
    public override Bitmap sprite
    {
        get { return new Bitmap("./Assets/Items/Armors/Chestplate.png"); }
    }
    public int damage_bonus { get {return 10;} }
    public int defense_bonus { get {return 10;} }

    public Chestplate()
    {

    }
}